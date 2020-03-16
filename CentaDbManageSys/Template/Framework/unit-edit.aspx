<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit-edit.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.unit_edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>  
     <div class="dialog-container">        
        <form id="form" method="post">
        <fieldset>
            <legend>单元信息</legend>        
        <div id="area">               
                    城市                   
                   <span><%=this.Unit.Build.Estate.Scope.Region.City.CityName %></span> 
                    城区              
                    <span><%=this.Unit.Build.Estate.Scope.Region.RegionName%></span>
                    片区              
                    <span><%=this.Unit.Build.Estate.Scope.ScopeName%></span>
            </div>       
            <div id="area">               
                    楼盘                   
                   <span><%=this.Unit.Build.Estate.EstateName%></span> 
                    栋座              
                    <span><%=this.Unit.Build.BuildName%></span>
                    单元
                    <span><%=this.Unit.CY_Axis%> <%=this.Unit.CX_Axis %></span>                    
            </div>       
        <div>
            <span>房间数量</span> 
            <input name="countf" type="text" value="<%=this.Unit.CountF %>" style="width:50px"/>           
        </div>  
        <div>
            <span>厅数量</span> 
            <input name="countt" type="text" value="<%=this.Unit.CountT %>" style="width:50px"/>           
        </div>  
        <div>
            <span>卫生间数量</span> 
            <input name="countw" type="text" value="<%=this.Unit.CountW %>" style="width:50px"/>          
        </div>  
        <div>
            <span>阳台数量</span> 
            <input name="county" type="text" value="<%=this.Unit.CountY %>" style="width:50px"/>           
        </div>  
        <div>
            <span>面积</span> 
            <input name="area" type="text" value="<%=this.Unit.Area %>" style="width:50px"/>           
        </div>  
        <div>
            <span>朝向</span> 
            <input name="directionTo" value="<%=this.Unit.DirectionTo %>"  style="width:50px"/>           
        </div>  
        </fieldset>
        </form>
    </div>    
</body>
</html>
