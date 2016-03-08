#include "customcommandbox.h"
#include "ui_customcommandbox.h"

CustomCommandBox::CustomCommandBox(QWidget *parent) :
    QDialog(parent),
    ui(new Ui::CustomCommandBox)
{
    ui->setupUi(this);
}

CustomCommandBox::~CustomCommandBox()
{
    delete ui;
}
