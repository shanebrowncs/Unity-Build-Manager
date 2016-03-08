#include "ubmio.h"

#include <QtXml>
#include <QDebug>



UBMIO::UBMIO()
{

}

UBMIO::UBMFile UBMIO::loadFile(QString path)
{
    UBMFile fileSettings;


    QDomDocument document;

    QFile file(path);

    if(!file.open(QIODevice::ReadOnly | QIODevice::Text))
    {
        UBMFile defReturn;
        defReturn.buildName = "false";
        return defReturn;
    }

    if(!document.setContent(&file))
    {
        UBMFile defReturn;
        defReturn.buildName = "false";
        return defReturn;
    }

    file.close();

    QDomElement root = document.firstChildElement();

    if(root.attribute("archive") == "1")
        fileSettings.archive = true;
    else
        fileSettings.archive = false;

    fileSettings.buildName = root.attribute("buildName");

    QDomNodeList nodes = root.childNodes();

    for(int i = 0; i < nodes.count(); i++)
    {
        fileSettings.items.append(nodes.at(i).firstChild().nodeValue());
    }

    return fileSettings;
}

QVector<QString> UBMIO::loadConfigFile()
{
    QVector<QString> items;

    QFile file(".ubmconfig");

    if(!file.open(QIODevice::ReadOnly | QIODevice::Text))
        return items;

    QDomDocument document;

    if(!document.setContent(&file))
        return items;

    file.close();

    QDomElement root = document.firstChildElement();

    items.append(root.attribute("unityDir"));
    items.append(root.attribute("defaultFile"));

    return items;
}

bool UBMIO::saveConfigFile(QString unityDir, QString defaultFile)
{
    QDomDocument document;

    QDomElement root = document.createElement("Config");
    root.setAttribute("unityDir", unityDir);
    if(defaultFile != "")
        root.setAttribute("defaultFile", defaultFile);

    document.appendChild(root);

    QFile file(".ubmconfig");

    if(!file.open(QIODevice::WriteOnly | QIODevice::Text))
        return false;

    QTextStream stream(&file);
    stream << document.toString();
    file.close();
    return true;
}

bool UBMIO::saveFile(QVector<QString> items, QString path, QString buildName, bool archive)
{
    QDomDocument document;

    QDomElement root = document.createElement("Builds");
    if(archive)
        root.setAttribute("archive", true);
    else
        root.setAttribute("archive", false);

    root.setAttribute("buildName", buildName);

    document.appendChild(root);

    for(int i = 0; i < items.count(); i++)
    {
        QDomElement node = document.createElement("Build");
        QDomText text = document.createTextNode(items[i]);
        node.appendChild(text);
        root.appendChild(node);
    }

    QFile file(path);

    if(file.open(QIODevice::WriteOnly | QIODevice::Text))
    {
        QTextStream stream(&file);
        stream << document.toString();
        file.close();
        return true;
    }
    else
        return false;
}
