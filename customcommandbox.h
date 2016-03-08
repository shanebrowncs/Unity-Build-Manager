#ifndef CUSTOMCOMMANDBOX_H
#define CUSTOMCOMMANDBOX_H

#include <QDialog>

namespace Ui {
class CustomCommandBox;
}

class CustomCommandBox : public QDialog
{
    Q_OBJECT

public:
    explicit CustomCommandBox(QWidget *parent = 0);
    ~CustomCommandBox();

private:
    Ui::CustomCommandBox *ui;
};

#endif // CUSTOMCOMMANDBOX_H
