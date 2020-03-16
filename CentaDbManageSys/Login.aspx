<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CentaDbManageSys.Login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html>
<head>
    <title>CentaDb维护系统--中原地产</title>
    <link href="Content/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="Content/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    <link href="Content/css/login.css" rel="stylesheet" type="text/css" />
</head>
<body>
 <form name="login" method="post">
    <table id="login" cellspacing="0" cellpadding="0" align="center">
        <tbody>
            <tr id="main">
                <td>               
                    <table height="100%" cellspacing="0" cellpadding="0">
                        <tbody>
                            <tr>
                                <td colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td width="380" style="height: 30px;">
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="4">
                                    &nbsp;
                                </td>
                                <td style="height: 40px;">
                                    用户名：
                                </td>
                                <td>
                                    <input class="textbox" id="txtUserName" name="UserName" />
                                </td>
                                <td width="120">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;">
                                    密 码：
                                </td>
                                <td>
                                    <input class="textbox" id="txtUserPassword" type="password" name="Password" />
                                </td>
                                <td width="120">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;">
                                    验证码：
                                </td>
                                <td valign="center" colspan="2">
                                    <input id="txtSN" size="4" name="Validator" />
                                    &nbsp;
                                    <img id="VerifyCode" src="ajax/Code.ashx" border="0" alt="验证码" style="vertical-align: bottom" />
                                    <a href="####" onclick="ChangeVerifyCode()">换一张</a>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 40px;">
                                    &nbsp;
                                </td>
                                <td align="right">
                                    <input id="btnLogin" type="submit" value=" 登 录 " name="btnLogin" />
                                </td>
                                <td width="120">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 110px;">
                                    &nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                  
                </td>
            </tr>
            <tr id="root">
                <td style="height: 104px;">
                    <span>CentaDb</span> 维护系统
                </td>
            </tr>
        </tbody>
    </table>
      </form>
    <script type="text/javascript">       
        function ChangeVerifyCode() {
            var img= document.getElementById("VerifyCode");
            img.src="ajax/code.ashx?"+new Date();
        }
    </script>  
    <script src="Content/easyui/jquery-1.6.min.js" type="text/javascript"></script>
<script src="Content/easyui/jquery.easyui.min.4.js" type="text/javascript"></script>
<script src="Content/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
</body>
</html>
