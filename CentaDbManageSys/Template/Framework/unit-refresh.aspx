<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="unit-refresh.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.unit_refresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
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
    var item = this.model[row, col];
          %>
      <%if (item == null)
        { %>
      <td row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">        
      </td>
      <%}
        else
        { %>
        <td row="<%=this.Rows[row] %>" col="<%=this.Columns[col] %>" wor="<%=row+1 %>" loc="<%=col+1 %>">
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
    <%} %>
</body>
</html>
