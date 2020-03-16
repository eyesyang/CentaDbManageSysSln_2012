<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estate-refresh.aspx.cs" Inherits="CentaDbManageSys.Template.Manage.estate_refresh" %>
<%@ Import Namespace="CentaLine.Common" %>
<%@ Import Namespace="CentaDbManageSys.Model" %>
<%@ Import Namespace="CentaDbManageSys.BLL" %>
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
	<li id="<%=item.EstateId %>" name="<%=item.EstateName+item.Phase %>" tp="<%=item.EstateType %>">   
            <%if (!item.IsOrder)
              { %><div class="bg-white">
            <input type="checkbox" style="height:10px; width:10px; vertical-align:middle"/>
            <label>设定为重点楼盘</label>
            <%}
              else if (item.OrderStatus == OrderStatus.REQUEST)
              {
            %>
                  <div class="bg-green">
                      重点楼盘
            <%}
              else if (item.OrderStatus == OrderStatus.COLLECTING)
              {
            %>
                  <div class="bg-red">
                      框架收集中
                      <%}
              else if (item.OrderStatus == OrderStatus.COLLECTED)
              {%>
                      <div class="bg-green">
                          框架收集完成
                          <%}
              else if (item.OrderStatus == OrderStatus.FRAMEWORKING)
              {
                          %>
                          <div class="bg-yellow">
                              框架录入中
                              <%}
              else if (item.OrderStatus == OrderStatus.FRAMEWORKED)
              {%>
                              <div class="bg-green">
                                  框架录入完成
                                  <%}
              else
              {           
              %>
              <div class="bg-red">
              比较完成(<%=item.CompareDate.ToString("yyyy/MM/dd") %>)
            <%} %>
        </div>
        <div class="estate-name">
        <a href="#" class="btn-a" title="<%=item.EstateName+item.Phase %>"><%=StrFilter(item.EstateName + item.Phase, 8)%></a>					
        </div>
        <div class="estate-btn">
             <a class="btn-b" href="#">更新框架</a> <a class="btn-c" href="#">导出记录</a>          
        </div>       
	</li>	
	<%} %>	
</ul>
<div class="clear"></div>	
</div>
<%}%> 
</body>
</html>
