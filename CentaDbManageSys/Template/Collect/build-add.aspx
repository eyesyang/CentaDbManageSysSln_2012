<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="build-add.aspx.cs" Inherits="CentaDbManageSys.Template.Collect.build_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>    
     <div class="dialog-container">
        <form id="form" method="post">
        <fieldset>
            <legend>栋座信息</legend>            
            <div id="area">               
                    城市                   
                   <span><%=this.Estate.Scope.Region.City.CityName %></span> 
                    城区              
                    <span><%=this.Estate.Scope.Region.RegionName %></span>
                    片区              
                    <span><%=this.Estate.Scope.ScopeName %></span>
            </div>
            <div><span>楼盘名字</span> <%=this.Estate.EstateName %>
            </div>            
           
                 <div>
                    <span>栋座名字</span> 
                    <input name="buildName" type="text" />                    
                </div>                
                                 
        </fieldset>
        </form>
    </div>
</body>
</html>
