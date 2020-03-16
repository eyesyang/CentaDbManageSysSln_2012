<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="build.aspx.cs" Inherits="CentaDbManageSys.Template.Manage.build" %>
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
	    <div>            
             &nbsp;
        </div>           
		<a href="#" class="btn-a" title="<%=item.BuildName %>"><%=StrFilter(item.BuildName,10)%></a>
		<div>			
			&nbsp;
		</div>		
	</li>	
	<%} %>		
</ul>
<div class="clear"></div>
</div> 	
<%}else if(this.ComparedBuildCollection!=null && this.ComparedBuildCollection.Count>0)
  {
      %>
      <div id="rs-list" class="build-list">
<input id="recordCount" type="hidden" value="<%=this.RecordCount %>" />
<input id="pageSize" type="hidden" value="<%=this.PageSize %>" />
<ul>
<%  
      foreach (var item in this.ComparedBuildCollection)
      {          
  %>
       <li id="<%=item.ComparedId %>" name="<%=item.BuildName %>">	
       <%if(item.StatusId==ComparedStatus.DEFAULT){ %>        
	    <div class="bg-green">            
             栋座
        </div>        
        <a href="#" class="btn-a" title="<%=item.BuildName %>"><%=StrFilter(item.BuildName,10)%></a>
		<div>			
			&nbsp;
		</div>	
        <%}
          else if(item.StatusId == ComparedStatus.DEFAULT_MISS)
          {
             %>
             <div class="bg-green-left">            
             栋座
            </div>
            <div class="bg-red-right">缺房源</div>
        <div class="clear"></div>
        <a href="#" class="btn-a" title="<%=item.Framework_BuildName %>"><%=StrFilter(item.Framework_BuildName, 10)%></a>
		<div>			
			&nbsp;
		</div>	  
             <% 
          }else if (item.StatusId == ComparedStatus.DEFAULT_CLEAR)
          {%>
          <div class="bg-green-left">            
             栋座
            </div>
            <div class="bg-yellow-right">清洗房源</div>
        <div class="clear"></div>
        <a href="#" class="btn-a" title="<%=item.Framework_BuildName %>"><%=StrFilter(item.Framework_BuildName, 10)%></a>
		<div>			
			&nbsp;
		</div>	  
             <% 
          }
         else if (item.StatusId == ComparedStatus.ADDNEW)
         {
           %>  
           <div class="bg-red-left">            
             缺栋座
            </div>
            <div class="bg-white-right">-</div>
        <div class="clear"></div>
        <a href="#" class="btn-a" title="<%=item.Framework_BuildName %>"><%=StrFilter(item.Framework_BuildName, 10)%></a>
		<div>			
			&nbsp;
		</div>	         
           <%}else if(item.StatusId==ComparedStatus.DELETE){ %>
           <div class="bg-yellow-left">            
             删栋座
            </div>
            <div class="bg-white-right">-</div>
            <div class="clear"></div>
            <a href="#" class="btn-a" title="<%=item.BuildName %>"><%=StrFilter(item.BuildName,10)%></a>
		<div>			
			&nbsp;
		</div>	
           <%} %>			
	</li>	
	<%} %>		
</ul>
<div class="clear"></div>
</div>
      <%
  }
  else
  { %>
    <div class="no-result">当前楼盘下没有栋座，点击 "添加栋座" 进行添加。</div>
<%} %> 
</div>
</body>
</html>
