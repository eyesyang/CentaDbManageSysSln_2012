<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="build-edit.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.build_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>    
       <div class="dialog-container">
       <form id="form" method="post">
        <input name="estateId" type="hidden" value="<%=this.Build.Estate.EstateId %>" />
        <fieldset>
            <legend>栋座信息</legend>
            <div id="area">               
                    城市: <span><%=this.Build.Estate.Scope.Region.City.CityName%> </span>
                    城区: <span><%=this.Build.Estate.Scope.Region.RegionName%></span>
                    片区: <span><%=this.Build.Estate.Scope.ScopeName%></span>
            </div>
            <div>
                <span>楼盘名字:</span> <%=this.Build.Estate.EstateName%>
            </div> 
             <div>
                <span>栋座名字:</span> 
                <input name="buildName" type="text" value="<%=this.Build.BuildName %>" />
            </div>    
            <div>
                <span>地址:</span> 
                <input name="address" type="text" value="<%=this.Build.Address %>" />
            </div>               
        </fieldset>
        </form>
    </div>   
</body>
</html>
