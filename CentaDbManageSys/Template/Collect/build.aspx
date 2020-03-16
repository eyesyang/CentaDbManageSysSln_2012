<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="build.aspx.cs" Inherits="CentaDbManageSys.Template.Collect.build" %>
<%@ Import Namespace="CentaLine.Common" %>
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
<div class="top-add">
     <div id="search-btn" class="top-add-l">
        &nbsp;
    </div>
<div class="top-add-r">
   <a id="btn-o" href="#">添加栋座</a>    
</div>
<div class="clear"></div>
</div>
<div id="build-temp">
<%if (this.BuildCollection != null && this.BuildCollection.Count > 0)
  { %>
<div id="rs-list" class="rs-list">
<input id="recordCount" type="hidden" value="<%=this.RecordCount %>" />
<input id="pageSize" type="hidden" value="<%=this.PageSize %>" />
<ul>
<%  
      foreach (var item in this.BuildCollection)
      {          
  %>
       <li id="<%=item.BuildId %>" name="<%=item.BuildName %>">	 
       <div class="btn-d"></div> 
	    <div class="framework">
            [<%if (item.Completed)
              { %>收集完成<%}
              else
              { %>收集中..<%} %>] 
        </div>           
		<a href="#" class="btn-a" title="<%=item.BuildName %>"><%=StrFilter(item.BuildName,12)%></a>
		<div>			
			<a href="#" class="btn-c">编辑</a>
            <a href="#" class="btn-b">完成</a>
		</div>		
	</li>	
	<%} %>		
</ul>
<div class="clear"></div>
</div> 	
<%}
  else
  { %>
    <div class="no-result">当前楼盘下没有栋座，点击 "添加栋座" 进行添加。</div>
<%} %> 
</div>
</body>
</html>
