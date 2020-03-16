(function ($) {
    // the code of this function is from  
    // http://lucassmith.name/pub/typeof.html 
    $.type = function (o) {
        var _toS = Object.prototype.toString;
        var _types = {
            'undefined': 'undefined',
            'number': 'number',
            'boolean': 'boolean',
            'string': 'string',
            '[object Function]': 'function',
            '[object RegExp]': 'regexp',
            '[object Array]': 'array',
            '[object Date]': 'date',
            '[object Error]': 'error'
        };
        return _types[typeof o] || _types[_toS.call(o)] || (o ? 'object' : 'null');
    };
    // the code of these two functions is from mootools 
    // http://mootools.net 
    var $specialChars = { '\b': '\\b', '\t': '\\t', '\n': '\\n', '\f': '\\f', '\r': '\\r', '"': '\\"', '\\': '\\\\' };
    var $replaceChars = function (chr) {
        return $specialChars[chr] || '\\u00' + Math.floor(chr.charCodeAt() / 16).toString(16) + (chr.charCodeAt() % 16).toString(16);
    };
    $.toJSON = function (o) {
        var s = [];
        switch ($.type(o)) {
            case 'undefined':
                return 'undefined';
                break;
            case 'null':
                return 'null';
                break;
            case 'number':
            case 'boolean':
            case 'date':
            case 'function':
                return o.toString();
                break;
            case 'string':
                return '"' + o.replace(/[\x00-\x1f\\"]/g, $replaceChars) + '"';
                break;
            case 'array':
                for (var i = 0, l = o.length; i < l; i++) {
                    s.push($.toJSON(o[i]));
                }
                return '[' + s.join(',') + ']';
                break;
            case 'error':
            case 'object':
                for (var p in o) {
                    s.push(p + ':' + $.toJSON(o[p]));
                }
                return '{' + s.join(',') + '}';
                break;
            default:
                return '';
                break;
        }
    };
    $.evalJSON = function (s) {
        if ($.type(s) != 'string' || !s.length) return null;
        return eval('(' + s + ')');
    };
})(jQuery);

$(function () {
    var lastIndex;
    var index;
    var object;
    $('#tt').datagrid({
        toolbar: [{
            text: '新增',
            handler: function() {
                if (lastIndex) {
                    $('#tt').datagrid('endEdit', lastIndex);
                }
                $('#tt').datagrid('appendRow', {
                    itemid: '',
                    productid: '',
                    listprice: '',
                    unitprice: '',
                    attr1: '',
                    status: 'P'
                });
                lastIndex = $('#tt').datagrid('getRows').length - 1;
                $('#tt').datagrid('selectRow', lastIndex);
                $('#tt').datagrid('beginEdit', lastIndex);
            }
        }, '-', {
            text: '删除',
            handler: function() {
                var rows = $('#tt').datagrid('getSelections');
                var id = [];
                for (var i = 0; i < rows.length; i++) {
                    id.push(rows[i].CentaBuildId);
                }
                if (id.length > 0) {
                    ajaxRequest('/home/delete', $.toJSON(id), function() {
                        $('#tt').datagrid('reload');
                        lastIndex = -1;
                    });
                }
            }
        }, '-', {
            text: '全选',
            handler: function() {
                $('#tt').datagrid('selectAll');
            }
        }, '-', {
            text: '全不选',
            handler: function() {
                $('#tt').datagrid('unselectAll');
            }
        }, '-', {
            text: '筛选',
            handler: function() {
                resize();
            }
        }, '-', {
            text: '显示所有',
            handler: function() {
                $('#tt').datagrid({ url: '/home/jsondata' });
                lastIndex = -1;
            }
        }],
        onCancelEdit: function(rowIndex, rowData) {
            lastIndex = -1;
        },
        onClickRow: function(rowIndex) {
            if (lastIndex) {
                $('#tt').datagrid('endEdit', lastIndex);
            }
            lastIndex = -1;
        },
        onAfterEdit: function(rowIndex, rowData, changes) {
            var changed = false;
            for (var item in changes) {
                changed = true;
                break;
            }
            if (changed) {
                if (rowData.CentaBuildId > 0) {
                    ajaxRequest('/home/update', rowData);
                } else {
                    if (rowData.centaest && rowData.cestcode && rowData.centabldg && rowData.cblgcode) {
                        ajaxRequest('/home/addnew', rowData, function(buildId) {
                            rowData.CentaBuildId = buildId;
                            $('#tt').datagrid('updateRow', { index: rowIndex, rowData: rowData });
                        });
                    } else {
                        $('#tt').datagrid('deleteRow', rowIndex);
                    }
                }
            }
        },
        onRowContextMenu: function(e, rowIndex, rowData) {
            e.preventDefault();
            $('#tt').datagrid('selectRow', rowIndex);
            index = rowIndex;
            object = rowData;

            if (!$('#amenu').length) {
                $('#amenu').remove();
            }
            createActionMenu(e);
        },
        onHeaderContextMenu: function(e, field) {
            e.preventDefault();
            if (!$('#tmenu').length) {
                createColumnMenu();
            }
            $('#tmenu').menu('show', {
                left: e.pageX,
                top: e.pageY
            });
        }
    });

    function createColumnMenu() {
        var tmenu = $('<div id="tmenu" style="width:100px;"></div>').appendTo('body');
        var fields = $('#tt').datagrid('getColumnFields');
        for (var i = 1; i < fields.length; i++) {
            $('<div iconCls="icon-ok"/>').html(fields[i]).appendTo(tmenu);
        }
        tmenu.menu({
            onClick: function(item) {
                if (item.iconCls == 'icon-ok') {
                    $('#tt').datagrid('hideColumn', item.text);
                    tmenu.menu('setIcon', {
                        target: item.target,
                        iconCls: 'icon-empty'
                    });
                } else {
                    $('#tt').datagrid('showColumn', item.text);
                    tmenu.menu('setIcon', {
                        target: item.target,
                        iconCls: 'icon-ok'
                    });
                }
            }
        });
    }

    function createActionMenu(e) {
        var amenu = $('<div id="amenu" style="width:100px;"></div>').appendTo('body');
        $('<div iconCls="icon-add"/>').html("新增").appendTo(amenu);
        $('<div iconCls="icon-remove"/>').html("删除").appendTo(amenu);
        $('<div iconCls="icon-edit"/>').html("修改").appendTo(amenu);

        amenu.menu({
            onClick: function(item) {
                if (item.iconCls == 'icon-add') {
                    $('#tt').datagrid('endEdit', lastIndex);
                    $('#tt').datagrid('appendRow', { });
                    lastIndex = $('#tt').datagrid('getRows').length - 1;
                    $('#tt').datagrid('selectRow', lastIndex);
                    $('#tt').datagrid('beginEdit', lastIndex);
                } else if (item.iconCls == 'icon-remove') {
                    var rows = $('#tt').datagrid('getSelections');
                    var id = [];
                    for (var i = 0; i < rows.length; i++) {
                        id.push(rows[i].CentaBuildId);
                    }
                    if (id.length > 0) {
                        ajaxRequest('/home/delete', $.toJSON(id), function() {
                            var pager = $('#tt').datagrid('getPager').pagination('options');
                            $('#tt').datagrid('load', { page: pager.pageNumber });
                            lastIndex = -1;
                        });
                    }
                } else {
                    if (index != lastIndex) {
                        $('#tt').datagrid('endEdit', lastIndex);
                        $('#tt').datagrid('beginEdit', index);
                    }
                    lastIndex = index;
                }
            }
        });
        amenu.menu('show', {
            left: e.pageX,
            top: e.pageY
        });
    }

    function ajaxRequest(url, data, callback) {
        $('#tt').datagrid('loading');
        $.ajax({
            type: 'post',
            url: url,
            data: data,
            dataType: 'json',
            contentType: 'application/json',
            success: function(json) {
                $('#tt').datagrid('loaded');
                if (json.rs && typeof callback == 'function') {
                    callback(json.id);
                }
            }
        });
    }

    function resize() {
        var fields = $('#tt').datagrid('getColumnFields');
        var params = { };
        var dd = $('#w');
        var content = [];
        dd.remove();
        content.push('<ul>');
        for (var i = 1; i < fields.length; i++) {
            content.push('<li><span>' + fields[i] + '</span><input name="' + fields[i] + '" type="text"></li>');
        }
        content.push('</ul>');
        content.push('<div class="clear"></div>');
        dd.append(content.join(''));
        dd.dialog({
            title: '筛选',
            modal: true,
            buttons: [{
                text: 'Ok',
                iconCls: 'icon-ok',
                handler: function() {
                    for (var i = 1; i < fields.length; i++) {
                        params[fields[i]] = $('#w input[name="' + fields[i] + '"]').val();
                    }
                    dd.dialog('close');
                    $('#tt').datagrid({
                        url: '/home/filter',
                        queryParams: params
                    });
                    lastIndex = -1;
                }
            }, {
                text: 'Cancel',
                handler: function() {
                    dd.dialog('close');
                }
            }]
        });
    }
});
	