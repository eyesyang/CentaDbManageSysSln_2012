<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.Unit" %>
<%@ Import Namespace="CentaLine.Common" %>
<%@ Import Namespace="CentaDbManageSys.Model" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>
<div id="nav-bar" class="nav-bar"><%=this.TitleBar %>
        <input name="buildId" type="hidden" value="<%=this.BuildId %>" />
    </div>	 
<div style="text-align:right;margin-top:10px;margin-bottom:10px;padding-right:10px"> 
    <a id="btn-undo" href="#" class="easyui-linkbutton">撤销</a>    
    <a id="btn-standard" href="#" class="easyui-linkbutton">标准化</a>    
    <a id="btn-complete" href="#" class="easyui-linkbutton">录入完成</a>    
   <a id="btn-add" href="#" class="easyui-linkbutton">添加</a>    
   <a id="btn-remove" href="#" class="easyui-linkbutton">删除</a> 
</div>       
	<div id="unit-temp">
	<%if (this.model.Length > 0)
   { %>
	<table id="unit-table" class="unit-list">
		<tr>
			<td class="unit-all"><input id='ck-all' class="ck-all" type="checkbox" />全选</td>
			<%for (int col = 0; col < this.Columns.Count; col++)
     { %>
			    <td><input class="ck-col" type="checkbox" value="<%=col+1 %>" /> <%=this.Columns[col]%></td>
			<%} %>			
		</tr>
		<%for (int row = 0; row < this.Rows.Count; row++)
    { %>
    <tr>
    <td><input class="ck-row" type="checkbox" value="<%=row+1 %>" /><%=this.Rows[row]%></td>	
    <%       
        for (int col = 0; col < this.Columns.Count; col++)
      { 
          var item=this.model[row,col];
          %>
      <%if (item == null)
        { %>
      <td row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">       
      </td>
      <%}
        else
        { %>
        <td  row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">			   			
            <div id="<%=item.UnitId %>">
                <div class="btn-d"></div>	
                <div class="unit-bg">&nbsp;</div>		           
				<div class="info-top"><input class="ck-unit" type="checkbox" value="<%=item.UnitId %>" /><a class="btn-b" href="#"><%=this.Rows[row] + this.Columns[col]%></a></div>				        				       				
                <div class="clear"></div>
				</div> 				  
		</td>
      <%} %>
    <%} %>
    </tr>
		<%} %>		
	</table>  
	<%}
    else
   { %>
   <div class="no-result">
  		当前栋座下没有单元，点击 "添加" 进行添加。
  		</div>  
	<%} %>
	</div>
</body>
</html>
