#-------------------------------------------------
#
# Project created by QtCreator 2015-06-24T23:01:21
#
#-------------------------------------------------

QT       += core gui
QT       += xml

greaterThan(QT_MAJOR_VERSION, 4): QT += widgets

TARGET = Unity-Build-Manager-QT
TEMPLATE = app


SOURCES += main.cpp\
        mainwindow.cpp \
    customcommandbox.cpp \
    inputbox.cpp \
    ubmio.cpp

HEADERS  += mainwindow.h \
    customcommandbox.h \
    inputbox.h \
    ubmio.h

FORMS    += mainwindow.ui \
    customcommandbox.ui \
    inputbox.ui
