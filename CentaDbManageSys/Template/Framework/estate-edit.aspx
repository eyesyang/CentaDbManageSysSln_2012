<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estate-edit.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.estate_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="dialog-container">
       <form id="form" method="post">
        <input name="estateId" type="hidden" value="<%=this.Estate.EstateId %>" />
        <fieldset>
            <legend>楼盘信息</legend>
            <div id="area">               
                    城市: <span><%=this.Estate.Scope.Region.City.CityName%> </span>
                    城区: <span><%=this.Estate.Scope.Region.RegionName%></span>
                    片区: <span><%=this.Estate.Scope.ScopeName%></span>
            </div>
            <div>
                <span>楼盘名字:</span> 
                <input name="estateName" type="text" value="<%=this.Estate.EstateName %>" />
            </div> 
             <div>
                <span>地址:</span> 
                <input name="address" type="text" value="<%=this.Estate.Address %>" />
            </div>                  
        </fieldset>
        </form>
    </div>   
</body>
</html>
