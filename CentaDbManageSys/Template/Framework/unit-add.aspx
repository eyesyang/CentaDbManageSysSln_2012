<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit-add.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.unit_add" %>

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
        <input name="buildId" type="hidden" value="<%=this.Build.BuildId %>" />
        <div id="area">               
                    城市                   
                   <span><%=this.Build.Estate.Scope.Region.City.CityName %></span> 
                    城区              
                    <span><%=this.Build.Estate.Scope.Region.RegionName%></span>
                    片区              
                    <span><%=this.Build.Estate.Scope.ScopeName%></span>
            </div>       
            <div id="area">               
                    楼盘                   
                   <span><%=this.Build.Estate.EstateName %></span> 
                    栋座              
                    <span><%=this.Build.BuildName%></span>                    
            </div>
        <div>
            <span>楼层</span> 
            <input name="y_axis_b" style="width:50px"/>     
            到      
             <input name="y_axis_e" style="width:50px"/>    
            <input name="y_axis_except" type="checkbox" />去4楼层         
        </div>
        <div>
            <span>单元数</span> 
            <input name="x_axis" style="width:50px"/> 
            <select name="x_axis_t">
                <option selected="selected" value="1">1室,2室,3室,..</option>
                <option value="a">A室,B室,C室,..</option>
            </select>
            <input name="x_axis_except" type="checkbox" />去4单元           
        </div>  
        <div>
            <span>房间数量</span> 
            <input name="countf" style="width:50px"/>           
        </div>  
        <div>
            <span>厅数量</span> 
            <input name="countt" style="width:50px"/>           
        </div>  
        <div>
            <span>卫生间数量</span> 
            <input name="countw" style="width:50px"/>          
        </div>  
        <div>
            <span>阳台数量</span> 
            <input name="county" style="width:50px"/>           
        </div>  
        <div>
            <span>面积</span> 
            <input name="area" style="width:50px"/>           
        </div>  
        <div>
            <span>朝向</span> 
            <input name="directionTo" style="width:50px"/>           
        </div>  
        </fieldset>
        </form>
    </div>    
</body>
</html>
