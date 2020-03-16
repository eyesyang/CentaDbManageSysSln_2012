<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit-edit.aspx.cs" Inherits="CentaDbManageSys.Template.Collect.unit_modify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>  
     <div class="unit-info">
        <h1>单元信息</h1>
        <form id="form" method="post">
        <input name="unitId" type="hidden" value="<%=this.UnitId %>" />
        <div>
            <span>楼盘</span><%=this.EstateName %></div>
        <div>
            <span>栋座</span><%=this.BuildName %></div>
        <div>
            <span>单元</span>
            <%=this.UnitCollection %>
        </div>
        <div>
            <span>地址</span><%=this.Address %></div>
        <div>
            <span>面积(m<sup>2</sup>)</span>
            <input name="area" class="easyui-numberbox" required="true" type="text" value="" style="width:50px" />
            </div>
        <div>
            <span>房间</span>
            <select name="countf" style="width:50px">                
                <option selected="selected">1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
                <option>6</option>
                <option>7</option>
                <option>8</option>
                <option>9</option>
                <option>10</option>
            </select>
            </div>
        <div>
            <span>客厅</span>
            <select name="countt" style="width:50px">
                <option selected="selected">0</option>
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
            </select>
            </div>
        <div>
            <span>卫生间</span>
            <select name="countw" style="width:50px">
                <option selected="selected">0</option>
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
            </select>
            </div>
        <div>
            <span>朝向</span>
            <select name="direction" style="width:50px">
                <option selected="selected">东</option>
                <option>南</option>
                <option>西</option>
                <option>北</option>
                <option>东南</option>
                <option>西南</option>
                <option>东北</option>
                <option>西北</option>
            </select>
            </div>
        </form>
    </div>  
</body>
</html>
