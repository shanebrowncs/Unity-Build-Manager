#include "inputbox.h"
#include "ui_inputbox.h"

#include <QFileDialog>
#include <QDir>
#include <QMessageBox>
#include <QFileInfo>
#include <QVector>

InputBox::InputBox(QWidget *parent) : QDialog(parent), ui(new Ui::InputBox)
{
    ui->setupUi(this);
}

InputBox::~InputBox()
{
    delete ui;
}

void InputBox::addToForm(QString projLoc, QString buildLoc, int combo)
{
	ui->projLocTxt->setText(projLoc);
	ui->buildLocTxt->setText(buildLoc);
	ui->buildTarCb->setCurrentIndex(combo);
}

QVector<QString> InputBox::fetchFormItems()
{
    QVector<QString> items;
    items.append(ui->buildTarCb->currentText());
    items.append(ui->projLocTxt->text());
    items.append(ui->buildLocTxt->text());
    return items;
}

void InputBox::on_projLocBtn_clicked()
{
    QString projectLoc = QFileDialog::getExistingDirectory();
    if(projectLoc != "")
        ui->projLocTxt->setText(projectLoc);
}

void InputBox::on_buildLocBtn_clicked()
{
    QString buildLoc = QFileDialog::getSaveFileName();
    if(buildLoc != "")
        ui->buildLocTxt->setText(buildLoc);
}

void InputBox::on_cancelBtn_clicked()
{
    QDialog::reject();
}

void InputBox::on_okBtn_clicked()
{
    QString errorList = "";
    if(ui->buildLocTxt->text().trimmed().length() < 1)
        errorList += "- Must Specify Build Path\r\n";
    else if(!QFileInfo(ui->buildLocTxt->text()).absoluteDir().exists())
        errorList += "- Build Location Doesn't Exist\r\n";

    if(ui->projLocTxt->text().trimmed().length() < 1)
        errorList += "- Must Specify Project Location\r\n";
    else if(!QDir(ui->projLocTxt->text()).exists())
        errorList += "- Project Location Doesn't Exist\r\n";

    if(errorList.length() > 0)
        QMessageBox::critical(NULL, "Error!", errorList);
    else // No errors, return data.
        QDialog::accept();
}
