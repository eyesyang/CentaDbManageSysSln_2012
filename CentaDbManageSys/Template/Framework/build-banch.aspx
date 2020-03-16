<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="build-banch.aspx.cs" Inherits="CentaDbManageSys.Template.Framework.build_banch" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div class="dialog-container">
        <form id="form" method="post">
        <fieldset>
            <legend>栋座信息</legend>            
            <div id="area">               
                    城市                   
                   <span><%=this.Estate.Scope.Region.City.CityName %></span> 
                    城区              
                    <span><%=this.Estate.Scope.Region.RegionName %></span>
                    片区              
                    <span><%=this.Estate.Scope.ScopeName %></span>
            </div>
            <div><span>楼盘名字</span> <%=this.Estate.EstateName %>
            </div>    
                 <div>
                    <span>栋座名字</span> 
                    <input name="buildName_B" type="text" style="width:62px"/>
                    到
                    <input name="buildName_E" type="text" style="width:63px"/>
                    <select name="buildName">
                        <option selected="selected">栋</option>
                        <option>座</option>
                    </select>                                                      
                </div>   
                <div>
                    <span>地址</span> 
                    <input name="address" type="text" />                       
                </div>   
                <div id="unit-pro">
                <div>
                    <span>每层单元数</span> 
                    <input name="x_cnt" type="text" />
                    <input name="x_except" type="checkbox"/> 去4单元
                </div>            
                 <div>
                    <span>楼层数</span> 
                    <input name="y_cnt_b" type="text" style="width:62px" /> 
                    到
                    <input name="y_cnt_e" type="text" style="width:63px"/> 
                    <input name="y_except" type="checkbox"/> 去4楼
                </div> 
                </div>      
        </fieldset>
        </form>
    </div>
</body>
</html>
