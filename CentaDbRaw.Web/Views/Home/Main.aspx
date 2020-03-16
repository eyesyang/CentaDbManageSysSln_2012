<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Main</title>
    <link href="../../Content/easyui/themes/default/easyui.css" rel="stylesheet" type="text/css" />
    <link href="../../Content/easyui/themes/icon.css" rel="stylesheet" type="text/css" />
    
    <script src="../../Content/js/jquery-1.4.4.min.js" type="text/javascript"></script>
    <script src="../../Content/easyui/jquery.easyui.min.js" type="text/javascript"></script>
    <script src="../../Content/easyui/locale/easyui-lang-zh_CN.js" type="text/javascript"></script>
    <script src="../../Content/js/common.js" type="text/javascript"></script>
    <style type="text/css">
        .clear {
            clear: both;
        }
        #w ul span {
            display: inline-block;
            width: 80px;
        }
        #w ul,#w li {
            padding: 0;
            margin: 0;
            list-style: none;
        }
        #w li {
            float: left;
            width: 45%;
            margin: 2px 0 2px 0;
        }
    </style>
</head>
<body class="easyui-layout">
    <div region="center">
	<table id="tt" pageSize="40" rownumbers="true" remoteSort="false" fit="true" pagination="true" title="栋座" iconCls="icon-edit" singleSelect="false"
			idField="CentaBuildId" url="/home/jsondata">
		<thead>
			<tr>
			    <th field="CentaBuildId" hidden="true">CentaBuildId</th>
				<th field="centaest" width="100" sortable="true" resizable="true" editor="text">centaest</th>
				<th field="cestcode" width="100" sortable="true" resizable="true" editor="text">cestcode</th>
				<th field="centabldg" width="80" sortable="true" resizable="true" editor="text">centabldg</th>
				<th field="cblgcode" width="100" sortable="true" resizable="true" editor="text">cblgcode</th>
				<th field="lpt_x" width="60" sortable="true" resizable="true" editor="text">lpt_x</th>
                <th field="lpt_y" width="60" sortable="true" resizable="true" editor="text">lpt_y</th>
                <th field="usage" width="60" sortable="true" resizable="true" editor="text">usage</th>
                <th field="c_estate" width="250" sortable="true" resizable="true" editor="text">c_estate</th>
                <th field="e_estate" width="250" sortable="true" resizable="true" editor="text">e_estate</th>
                <th field="c_phase" width="60" sortable="true" resizable="true" editor="text">c_phase</th>
                <th field="e_phase" width="60" sortable="true" resizable="true" editor="text">e_phase</th>
                <th field="c_property" width="60" sortable="true" resizable="true" editor="text">c_property</th>
                <th field="e_property" width="60" sortable="true" resizable="true" editor="text">e_property</th>
                <th field="pc_addr1" width="60" sortable="true" resizable="true" editor="text">pc_addr1</th>
                <th field="pc_addr2" width="60" sortable="true" resizable="true" editor="text">pc_addr2</th>
                <th field="pe_addr" width="60" sortable="true" resizable="true" editor="text">pe_addr</th>
                <th field="opdate" width="120" sortable="true" resizable="true" editor="text">opdate</th>
                <th field="unit_cnt" width="60" sortable="true" resizable="true" editor="text">unit_cnt</th>
                <th field="x_cnt" width="60" sortable="true" resizable="true" editor="text">x_cnt</th>
                <th field="y_cnt" width="60" sortable="true" resizable="true" editor="text">y_cnt</th>
                <%--<th field="scp_id" width="60" editor="text">scp_id</th>
                <th field="scp_c" width="60" editor="text">scp_c</th>
                <th field="scp_e" width="60" editor="text">scp_e</th>
                <th field="scp_mkt" width="60" editor="text">scp_mkt</th>
                <th field="nmark" width="60" editor="text">nmark</th>
                <th field="o_estateid" width="60" editor="text">o_estateid</th>
                <th field="o_bldgid" width="60" editor="text">o_bldgid</th>
                <th field="estateid" width="60" editor="text">estateid</th>
                <th field="buildingid" width="60" editor="text">buildingid</th>
                <th field="address" width="250" editor="text">address</th>
                <th field="moddate" width="60" editor="text">moddate</th>
                <th field="pc_street1" width="60" editor="text">pc_street1</th>
                <th field="pc_street2" width="60" editor="text">pc_street2</th>
                <th field="pe_street1" width="60" editor="text">pe_street1</th>
                <th field="pe_street2" width="60" editor="text">pe_street2</th>
                <th field="pc_stno1" width="60" editor="text">pc_stno1</th>
                <th field="pc_stno2" width="60" editor="text">pc_stno2</th>
                <th field="ppt_rank" width="60" editor="text">ppt_rank</th>
                <th field="org_cenblg" width="60" editor="text">org_cenblg</th>
                <th field="org_cenest" width="60" editor="text">org_cenest</th>
                <th field="need_clear" width="60" editor="text">need_clear</th>
                <th field="x_axis" width="60" editor="text">x_axis</th>
                <th field="x_axis2" width="60" editor="text">x_axis2</th>
                <th field="y_axis" width="60" editor="text">y_axis</th>
                <th field="y_axis2" width="60" editor="text">y_axis2</th>
                <th field="cblk_key" width="60" editor="text">cblk_key</th>--%>
			</tr>
		</thead>
	</table>
     </div>
     <div id="w" style="width:600px;height:400px;padding:5px;">
            
	</div>
</body>
</html>
