#include "mainwindow.h"
#include "ui_mainwindow.h"
#include "inputbox.h" // Use Second Dialog
#include "ubmio.h" // Use IO Class

#include <QMessageBox>
#include <QVector>
#include <QFileDialog>
#include <QCloseEvent>

MainWindow::MainWindow(QWidget *parent) : QMainWindow(parent), ui(new Ui::MainWindow)
{
    ui->setupUi(this);

    pendingChanges = false;
    openFilePath = "";
    setDefaultConfig();
}

MainWindow::~MainWindow()
{
    delete ui;
}

/* LIST INTERATION BTNS */

void MainWindow::on_addBtn_clicked()
{
    addListItem();
}

void MainWindow::on_editBtn_clicked()
{
    int index = ui->listWgt->currentRow();
    if(index == -1)
        return;

    QString wholeString = ui->listWgt->item(index)->text();
    QStringList items = wholeString.split('-');

    for(int i = 0; i < items.length(); i++)
        items[i] = items[i].trimmed();

    int tarIndex = getIndexFromTarget(items[0]);

    addListItem(true, index, items[1], items[2], tarIndex);
}

void MainWindow::on_removeBtn_clicked()
{
    int index = ui->listWgt->currentRow();
    if(index == -1)
        return;

    delete ui->listWgt->item(index);

    setPendingChanges(true);
}

void MainWindow::on_upBtn_clicked()
{
    int index = ui->listWgt->currentRow();
    if(index < 1)
        return;

    QString tempItem = ui->listWgt->item(index)->text();
    delete ui->listWgt->item(index);
    ui->listWgt->insertItem(index - 1, tempItem);
    ui->listWgt->setCurrentRow(index - 1);

    setPendingChanges(true);
}

void MainWindow::on_downBtn_clicked()
{
    int index = ui->listWgt->currentRow();
    if(index == -1 || index >= ui->listWgt->count() - 1)
        return;


    QString tempItem = ui->listWgt->item(index)->text();
    delete ui->listWgt->item(index);
    ui->listWgt->insertItem(index + 1, tempItem);
    ui->listWgt->setCurrentRow(index + 1);

    setPendingChanges(true);
}

/* LIST INTERATION BTNS */

/* ADDITIONAL SAVE STATE EVENT HANDLERS */

void MainWindow::on_buildNameTxt_textChanged()
{
    setPendingChanges(true);
}

void MainWindow::on_archiveBuildsCb_clicked()
{
    setPendingChanges(true);
}

/* ADDITIONAL SAVE STATE EVENT HANDLERS */

void MainWindow::setDefaultConfig(bool force)
{
    UBMIO io;
    QVector<QString> items = io.loadConfigFile();

    if(items.count() < 1 || force)
    {
        QString unityPath;

        if(OS > 1) // OSX
            unityPath = QFileDialog::getOpenFileName(this, "Select Unity Executable", NULL, "Unity Executable (*.app)") + "/MacOS/Unity";
        else // WINDOWS AND LINUX(WINE)
            unityPath = QFileDialog::getOpenFileName(this, "Select Unity Executable", NULL, "Unity Executable (*.exe)");

        if(unityPath.trimmed() != "")
        {
            if(force && items.count() >= 2)
                io.saveConfigFile(unityPath, items[1]);
            else
                io.saveConfigFile(unityPath);
        }
    }
    else
    {
        unityPath = items[0];
        if(items.count() >= 2)
        {
            UBMIO::UBMFile file = io.loadFile(items[1]);
            openFile(file.archive, file.buildName, file.items, items[1]);
        }
    }
}

bool MainWindow::saveHandler()
{
    QVector<QString> items;
    for(int i = 0; i < ui->listWgt->count(); i++)
    {
        items.append(ui->listWgt->item(i)->text());
    }

    if(ui->buildNameTxt->text().trimmed() != "")
    {
        if(openFilePath.trimmed() == "")
        {
            openFilePath = QFileDialog::getSaveFileName(NULL, "Select UBM Location", NULL, "Unity Build Manager File (*.ubm)");
            if(openFilePath == "")
                return false;

            if(!openFilePath.endsWith(".ubm"))
                openFilePath += ".ubm";

        }
        UBMIO ioObj;
        if(ioObj.saveFile(items, openFilePath, ui->buildNameTxt->text(), ui->archiveBuildsCb->isChecked()))
        {
            setPendingChanges(false);
            QString title = this->windowTitle().split(" -")[0];
            this->setWindowTitle(title.append(" - " + openFilePath));
            return true;
        }
        else
        {
            QMessageBox::critical(NULL, "Error!", "Could not save file!");
            return false;
        }

    }
    else
    {
        QMessageBox::critical(NULL, "Error!", "Build name has not been specified!");
        return false;
    }

}

void MainWindow::addListItem(bool edit, int index, QString projLoc, QString buildLoc, int cbIndex)
{
    InputBox inbox;

    if(edit)
        inbox.addToForm(projLoc, buildLoc, cbIndex);

    if(inbox.exec())
    {
        QVector<QString> items = inbox.fetchFormItems();
        if(edit)
            ui->listWgt->item(index)->setText(items[0] + " - " + items[1] + " - " + items[2]);
        else
            ui->listWgt->addItem(items[0] + " - " + items[1] + " - " + items[2]);

        setPendingChanges(true);
    }
}

int MainWindow::getIndexFromTarget(QString target)
{
    if(target == "Linux_x64") return 0;
    else if(target == "Linux_x86") return 1;
    else if(target == "Mac_OSX_x64") return 2;
    else if(target == "Mac_OSX_x86") return 3;
    else if(target == "Windows_x64") return 4;
    else if(target == "Windows_x86") return 5;
    else return -1;
}

void MainWindow::setPendingChanges(bool state)
{
    if(state)
    {
        if(state != pendingChanges)
            this->setWindowTitle("*" + this->windowTitle());
    }


    else
        this->setWindowTitle(this->windowTitle().replace("*", ""));

    pendingChanges = state;
}

void MainWindow::on_actionNew_triggered()
{
    if(pendingChanges)
    {
        QMessageBox::StandardButton reply;
        reply = QMessageBox::warning(NULL, "Warning!", "You have unsaved changes, would you like to save them?", QMessageBox::Yes | QMessageBox::No | QMessageBox::Cancel);
        if(reply == QMessageBox::Yes)
        {
            if(!saveHandler())
                return;
        }
        else if(reply == QMessageBox::Cancel)
            return;
    }

    ui->listWgt->clear();
    ui->buildNameTxt->clear();
    ui->archiveBuildsCb->setChecked(false);

    openFilePath = "";

    setPendingChanges(false);
    this->setWindowTitle(this->windowTitle().split(" -")[0]);
}

void MainWindow::on_actionOpen_triggered()
{
    UBMIO ioManager;
    UBMIO::UBMFile file;

    QString path = QFileDialog::getOpenFileName(this, "Select UBM File to Open", NULL, "Unity Build Manager File (*.ubm)");
    if(path == "")
        return;

    file = ioManager.loadFile(path);

    openFile(file.archive, file.buildName, file.items, path);
}

void MainWindow::openFile(bool archive, QString buildName, QVector<QString> items, QString filePath)
{
    ui->archiveBuildsCb->setChecked(archive);
    ui->buildNameTxt->setText(buildName);

    for(int i = 0; i < items.count(); i++)
        ui->listWgt->addItem(items[i]);

    setPendingChanges(false);

    openFilePath = filePath;

    QString title = this->windowTitle().split(" -")[0];
    this->setWindowTitle(title.append(" - " + openFilePath));
}

void MainWindow::on_actionSave_triggered()
{
    saveHandler();
}

void MainWindow::on_actionExit_triggered()
{
    this->close();
}

void MainWindow::on_actionChange_Unity_Path_triggered()
{
    setDefaultConfig(true);
}

void MainWindow::on_actionSet_Current_As_Default_triggered()
{
    if(openFilePath.isEmpty())
        QMessageBox::critical(this, "Error!", "No File Open");
    else if(pendingChanges)
    {
        int result = QMessageBox::warning(this, "Warning!", "You must save your changes to set this file as default, would you like to save?", QMessageBox::No | QMessageBox::Yes, QMessageBox::Yes);

        if(result == QMessageBox::Yes)
        {
            if(saveHandler())
            {
                UBMIO ioManager;

                QVector<QString> items = ioManager.loadConfigFile();
                ioManager.saveConfigFile(items[0], openFilePath);
            }
        }
    }

}

void MainWindow::closeEvent(QCloseEvent *event)
{
    if(pendingChanges)
    {
        int result = QMessageBox::warning(this, "Warning!", "You have unsaved changes, would you like to save before closing?", QMessageBox::Cancel | QMessageBox::No | QMessageBox::Yes, QMessageBox::Yes);


        if(result == QMessageBox::Yes)
        {
            if(!saveHandler())
                event->ignore();
        }
        else if(result == QMessageBox::Cancel)
        {
            event->ignore();
        }
    }
}
