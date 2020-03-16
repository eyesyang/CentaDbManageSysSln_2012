<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit.aspx.cs" Inherits="CentaDbManageSys.Template.Manage.Unit" %>
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
    <a href="#" class="easyui-linkbutton" iconCls="icon-save">导出报表</a>
</div>
	<div id="unit-temp">
	<%if (this.UnitArray!=null && this.UnitArray.Length > 0)
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
          var item = this.UnitArray[row, col];
          %>
      <%if (item == null)
        { %>
      <td row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">       
      </td>
      <%}
        else
        { %>
        <td class="unit-bg" row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">			    
			        <div id="<%=item.UnitId %>">                        		           
				        <input style="vertical-align:middle" class="ck-unit" type="checkbox" value="<%=item.UnitId %>" /><%=this.Rows[row] + this.Columns[col]%>
				      </div>				  
			</td>
      <%} %>
    <%} %>
    </tr>
		<%} %>		
	</table>  
	<%}
   else if(this.ComparedUnitArray!=null && this.ComparedUnitArray.Length>0)
   {
       %>
<table id="unit-table" class="unit-list">
		<tr>
			<td class="unit-all"></td>
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
          var item = this.ComparedUnitArray[row, col];
          %>
      <%if (item == null)
        { %>
      <td row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">       
      </td>
      <%}
        else if(item.StatusId==ComparedStatus.DEFAULT)
        { %>
        <td class="bg-green" row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">
				        <input style="vertical-align:middle" class="ck-unit" type="checkbox" value="<%=item.UnitId %>" /><%=this.Rows[row] + this.Columns[col]%>	  
			</td>	        
      <%}else if(item.StatusId==ComparedStatus.ADDNEW){ %>
        <td class="bg-red" row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">	
                             		           
				        <input style="vertical-align:middle" class="ck-unit" type="checkbox" value="<%=item.UnitId %>" /><%=this.Rows[row] + this.Columns[col]%>
				   			  
			</td>
      <%}else if(item.StatusId==ComparedStatus.DELETE){ %>
     <td class="bg-yellow" row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">
				        <input style="vertical-align:middle" class="ck-unit" type="checkbox" value="<%=item.UnitId %>" /><%=this.Rows[row] + this.Columns[col]%>
		</td>
      <%} %>
    <%} %>
    </tr>
		<%} %>		
	</table>  
       <%
   }
    else 
   { %>
   <div class="no-result">
  		当前栋座下没有单元，点击 "添加" 进行添加。
  		</div>  
	<%} %>
	</div>
</body>
</html>
