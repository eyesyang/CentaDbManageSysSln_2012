<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="CentaDbManageSys.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CentaDb维护系统--中原地产</title>
    <link href="Content/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="Content/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/main.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
</head>
<%--<body class="easyui-layout" onbeforeunload="return '';">--%>
<body class="easyui-layout">
    <div id="north" region="north" border="false" split="false">
        <div id="north-left">
            <div>
                CentaDB</div>
            维护系统
        </div>
        <div id="north-right">
            <div id="north-right-top">
                用户名：<%=this.UserInfo.UserName %>
                <img src="Content/img/menu_seprator.gif" />
                角 色：<%=this.UserInfo.Role.ToString() %>
                <img src="Content/img/menu_seprator.gif" />
                退出系统
            </div>
            <div id="north-right-bottom">
                <span id="north-clock"></span>
                <img src="Content/img/menu_seprator.gif" />
                <img src="Content/img/nav_changePassword.gif" />重新登录
                <img src="Content/img/nav_resetPassword.gif" />修改密码
                <img src="Content/img/nav_help.gif" />帮助
            </div>
        </div>
        <div class="clear"></div>
    </div>
    <div region="west" split="true" title="系统菜单" style="width: 180px">
        <div id="accordion" class="easyui-accordion" animate="true" collapsed="true" fit="true" border="false">
            <div title="楼盘框架" style="padding: 10px; padding-left: 5px">
                <ul id="tree">
                </ul>
            </div>
            <div title="内容维护" style="padding: 10px; padding-left: 5px"> 
            to do..               
            </div>
            <div title="网页同步" style="padding: 10px; padding-left: 5px">                
            to do..
            </div>
            <div title="报表管理" style="padding: 10px; padding-left: 5px">                
            to do..
            </div>
            <div title="导出功能" style="padding: 10px; padding-left: 5px">                
            to do..
            </div>
            <div title="用户管理" style="padding: 10px; padding-left: 5px">                
            to do..
            </div>
            <div title="系统管理" style="padding: 10px; padding-left: 5px">                
            to do..
            </div>
        </div>
    </div>
    <div region="center" border="false" style="padding: 5px;">
        <div id="tabs" class="easyui-tabs" fit="true" plain="true">
            <div title="我的信息">
                <div id="loginInfo">
                    <h1>
                        Welcome To
                    </h1>
                    <p>
                        用户名： <%=this.UserInfo.UserName %>
                    </p>
                    <p>
                        登录时间：<%=DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") %>
                    </p>
                    <p>
                        IP：12.210.210.10
                    </p>
                    <p>
                        上次登录时间：2011-10-25 10:21:52
                    </p>
                    <p>
                        登录次数: 2
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div id="dialog">
    </div>
    <script src="Content/js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="Content/js/jquery.cookie.js" type="text/javascript"></script>
    <script src="Content/easyui/jquery.easyui.min.4.js" type="text/javascript"></script>
    <script src="Content/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="Content/js/jquery.autocomplete.js" type="text/javascript"></script>   
    <script src="Content/js/common.js" type="text/javascript"></script>
    <%=GetScript() %>
</body>
</html>