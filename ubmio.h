#ifndef UBMIO_H
#define UBMIO_H

#include <QString>
#include <QVector>

class UBMIO
{
    public:
        struct UBMFile
        {
            QString buildName;
            bool archive;
            QVector<QString> items;
        };

        UBMIO();

        UBMFile loadFile(QString path);
        bool saveFile(QVector<QString> items, QString path, QString buildName, bool archive);
        QVector<QString> loadConfigFile();
        bool saveConfigFile(QString unityDir, QString defaultFile = "");
};

#endif // UBMIO_H
