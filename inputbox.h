#ifndef INPUTBOX_H
#define INPUTBOX_H

#include <QDialog>

namespace Ui {
class InputBox;
}

class InputBox : public QDialog
{
    Q_OBJECT

public:
    explicit InputBox(QWidget *parent = 0);
    ~InputBox();
    void addToForm(QString projLoc, QString buildLoc, int combo);
    QVector<QString> fetchFormItems();

private slots:
    void on_projLocBtn_clicked();

    void on_cancelBtn_clicked();

    void on_buildLocBtn_clicked();

    void on_okBtn_clicked();

private:
    Ui::InputBox *ui;
};

#endif // INPUTBOX_H
