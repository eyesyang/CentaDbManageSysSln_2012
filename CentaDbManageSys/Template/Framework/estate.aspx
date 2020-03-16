<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estate.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.estate" %>

<%@ Import Namespace="CentaDbManageSys.Model" %>
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
<div id="search-bar" class="search-bar">
    城区 
    <select class="easyui-combobox" style="width:100px;">
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
	<li id="<%=item.EstateId %>" name="<%=item.EstateName %>">          
              <%if (item.Flow == FlowStatus.COLLECTING || item.Flow==FlowStatus.COLLECTING_ORDERSTATUS)
                { %> <div class="bg-yellow">录入中<%}
                else
                { %>
                <div class="bg-green">
                <%=item.ModifyDate.ToString("yyyy-MM-dd") %> 录入完成
                <%} %>
        </div>        			
        <a href="#" class="btn-a" title="<%=item.EstateName %>"><%=StrFilter(item.EstateName, 8)%></a>					
        <div>           
            <a href="#" class="btn-b">编辑</a> <a class="btn-c" href="#">完成</a>            
        </div>
	</li>	
	<%} %>	
</ul>
<div class="clear"></div>	
</div>
<%}
  else
  { %>
    <div class="no-result">当前区域下没有楼盘，点击 "添加楼盘" 进行添加。</div>	
<%} %>
</div>
</body>
</html>
