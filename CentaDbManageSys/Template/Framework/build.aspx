<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="build.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.build" %>
<%@ Import Namespace="CentaDbManageSys.Model" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Untitled Page</title>
</head>
<body>
<div id="nav-bar" class="nav-bar"><%=this.TitleBar %>
<input name="estateId" type="hidden" value="<%=this.EstateId %>" />
</div>
<div id="page-bar" class="page"></div>
<div style="text-align:right;margin-top:10px;margin-bottom:10px;padding-right:10px">
    <a id="btn-banch" href="#" class="easyui-linkbutton" >批量添加栋座</a>    
   <a id="btn-add" href="#" class="easyui-linkbutton">添加栋座</a>       
</div>
<div id="build-temp">
<%if (this.BuildCollection != null && this.BuildCollection.Count > 0)
  { %>
<div id="rs-list" class="build-list">
<input id="recordCount" type="hidden" value="<%=this.RecordCount %>" />
<input id="pageSize" type="hidden" value="<%=this.PageSize %>" />
<ul>
<%  
      foreach (var item in this.BuildCollection)
      {          
  %>
       <li id="<%=item.BuildId %>" name="<%=item.BuildName %>">	                 
              <%if (item.Flow == FlowStatus.COLLECTING || item.Flow == FlowStatus.COLLECTING_ORDERSTATUS)
                { %><div class="btn-d"></div> <div class="bg-yellow">录入中<%}
                else
                { %><div class="bg-green">
                <%=item.ModifyDate.ToString("yyyy-MM-dd") %> 录入完成
                <%} %>
        </div>           	       
		<a href="#" class="btn-a" title="<%=item.BuildName %>"><%=StrFilter(item.BuildName,10)%></a>
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
    <div class="no-result">当前楼盘下没有栋座，点击 "添加栋座" 进行添加 或 "导入栋座" 导入已经收集的栋座。</div>
<%} %> 
</div>
</body>
</html>
