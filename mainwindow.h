#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();
    bool pendingChanges;
    QString openFilePath;
    QString unityPath;

private slots:
    void on_addBtn_clicked();

    void on_editBtn_clicked();

    void on_removeBtn_clicked();

    void on_upBtn_clicked();

    void on_downBtn_clicked();

    void on_actionNew_triggered();

    void on_actionOpen_triggered();

    void on_actionSave_triggered();

    void on_actionExit_triggered();

    void on_actionChange_Unity_Path_triggered();

    void on_actionSet_Current_As_Default_triggered();

    void on_buildNameTxt_textChanged();

    void on_archiveBuildsCb_clicked();

    void addListItem(bool edit = false, int index = -1, QString projLoc = NULL, QString buildLoc = NULL, int cbIndex = -1);

    int getIndexFromTarget(QString target);

    void setPendingChanges(bool state);

    bool saveHandler();

    void setDefaultConfig(bool force = false);

    void closeEvent(QCloseEvent *event);

    void openFile(bool archive, QString buildName, QVector<QString> items, QString filePath);

#ifdef Q_OS_LINUX
#define OS 0
#elif Q_OS_WINDOWS
#define OS 1
#else
#define OS 2
#endif

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
