<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estate.aspx.cs" Inherits="CentaDbManageSys.Template.Manage.estate" %>
<%@ Import Namespace="CentaLine.Common" %>
<%@ Import Namespace="CentaDbManageSys.Model" %>
<%@ Import Namespace="CentaDbManageSys.BLL" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
<div id="nav-bar" class="nav-bar"><%=this.TitleBar %>
    <input name="type" type="hidden" value="<%=this.Type %>" />
    <input name="code" type="hidden" value="<%=this.Code %>" />
</div>
<div class="top-add">
     <div class="top-add-l">
       城区 
    <select>
        <option value="AL">白云区</option>
		<option value="AK">天河区</option>
		<option value="AZ">番禺区</option>
		<option value="AR">花都区</option>
		<option value="CA">越秀区</option>
		<option value="CO">荔湾区</option>
		<option value="CT">增城区</option>
		<option value="DE">萝岗区</option>		
    </select>
    楼盘 <input type="text" />
    栋座 <input type="text" />
    <input type="button" value="查询" />
    </div>
<div class="top-add-r">
   <a id="btn-s" href="#" class="easyui-linkbutton" iconCls="icon-save">保存重点楼盘</a>       
</div>
<div class="clear"></div>
</div>
<div id="page-bar" class="page"></div>
<div id="build-temp">
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
            <input type="checkbox"/>
            设定为重点楼盘
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
<%}
  else
  { %>
    <div class="no-result">当前区域下没有楼盘</div>	
<%} %>
</div>
</body>
</html>
