<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estate-refresh.aspx.cs" Inherits="CentaDbManageSys.Template.Collect.estate_refresh" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
 <%if (this.EstateCollection != null && this.EstateCollection.Count > 0)
  { %>
<div id="rs-list" class="rs-list">
    <input id="recordCount" type="hidden" value="<%=this.RecordCount %>" />
    <input id="pageSize" type="hidden" value="<%=this.PageSize %>" />
<ul>
   <%foreach (var item in this.EstateCollection)
  {%>     
	<li id="<%=item.EstateId %>" name="<%=item.EstateName+item.Phase %>" tp="<%=item.EstateType %>">        				
        <div class="framework">
            [<%if (item.Completed)
              { %>收集完成<%}
              else
              { %>收集中..
              <%} %>] 
        </div>
        <a href="#" class="btn-a" title="<%=item.EstateName+item.Phase %>"><%=StrFilter(item.EstateName + item.Phase, 8)%></a>					        
	</li>	
	<%} %>	
</ul>
<div class="clear"></div>	
</div>
<%}%> 
</body>
</html>
