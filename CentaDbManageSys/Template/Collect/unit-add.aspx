<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit-add.aspx.cs" Inherits="CentaDbManageSys.Template.Collect.unit_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>    
    <div class="unit-info">        
        <h1>添加单元</h1>  
        <form id="form" method="post">
        <input name="buildId" type="hidden" value="<%=this.model.BuildId %>" />
        <div class="unit-title"><%=this.model.ToTitle() %></div>       
        <div>
            <span class="unit-property">楼层</span> 
            <input name="y_axis" style="width:50px"/>
            (为空则表示需要添加一个单元的所有楼层)
        </div>
        <div>
            <span class="unit-property">单元</span> 
            <input name="x_axis" style="width:50px"/>
            (为空则表示需要添加一个楼层的所有单元)
        </div>  
        </form>
    </div>    
</body>
</html>
