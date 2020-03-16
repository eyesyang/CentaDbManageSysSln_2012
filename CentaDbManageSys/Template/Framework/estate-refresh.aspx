<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estate-refresh.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.estate_refresh" %>
<%@ Import Namespace="CentaDbManageSys.Model" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>    
 <%if (this.EstateCollection != null && this.EstateCollection.Count > 0)
  { %>
<div id="rs-list" class="estate-list">
    <input id="recordCount" type="hidden" value="<%=this.RecordCount %>" />
    <input id="pageSize" type="hidden" value="<%=this.PageSize %>" />
<ul>
    <%foreach (var item in this.EstateCollection)
  {%>     
	<li id="<%=item.EstateId %>" name="<%=item.EstateName %>">    
         
              <%if (item.Flow == FlowStatus.COLLECTING || item.Flow==FlowStatus.COLLECTING_ORDERSTATUS)
                { %><div class="bg-yellow"> 录入中<%}
                else
                { %><div class="bg-green">
                <%=item.ModifyDate.ToString("yyyy-MM-dd") %> 录入完成
                <%} %>
        </div>       			
        <a href="#" class="btn-a" title="<%=item.EstateName %>"><%=StrFilter(item.EstateName, 10)%></a>					
        <div>           
            <a href="#" class="btn-b">编辑</a> <a class="btn-c" href="#">完成</a>            
        </div>
	</li>	
	<%} %>	
</ul>
<div class="clear"></div>	
</div>
<%}%> 
</body>
</html>
