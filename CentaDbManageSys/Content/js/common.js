var clock = (function(){
    function Clock(){
        var date = new Date();
        this.year = date.getFullYear();
        this.month = date.getMonth() + 1;
        this.date = date.getDate();
        this.day = new Array("星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六")[date.getDay()];
        this.hour = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        this.minute = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        this.second = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
        
        this.toString = function(){
            return this.year + "年" + this.month + "月" + this.date + "日 " + this.hour + base.timeSplit + this.minute + base.timeSplit + this.second + " " + this.day;
        };
        
        this.toSimpleDate = function(){
            return this.year + base.dateSplit + this.month + base.dateSplit + this.date;
        };
        
        this.toDetailDate = function(){
            return this.year + base.dateSplit + this.month + base.dateSplit + this.date + " " + this.hour + base.timeSplit + this.minute + base.timeSplit + this.second;
        };
        
        this.display = function(ele){
            var clk = new Clock();
            ele.html(clk.toString());
            window.setTimeout(function(){
                clk.display(ele);
            }, 1000);
        };
    }
    return {
        init : function(){
            var clk = new Clock();
            clk.display($('#north-clock'));
        }
    };
})();
var area = (function(){
    var id = '#area';
    function initSelect(type, code){
        if(type == architecture.scope){
            return;
        }
        else{
            $.ajax({
                type : 'get',
                url : 'ajax/area.ashx',
                data : 
                {
                    type : type,
                    code : code
                },
                dataType : 'text',
                success : function(m){
                    m = str2json(m);
                    if(type == architecture.region){
                        bindScope(m.scope);
                    }
                    else{
                        bindRegion(m.region);
                    }
                }
            });
        }
    }
    function bindSelect(element, data){
        var builder = new stringBuilder();
        var item = null;
        builder.append('<select>');
        for(var idx = 0; idx < data.length; idx ++ ){
            item = data[idx];
            if(idx == 0){
                builder.append('<option selected="selected" value="' + item.code + '">' + item.name + '</option>');
            }
            else{
                builder.append('<option value="' + item.code + '">' + item.name + '</option>');
            }
        }
        builder.append('</select>');
        var val = element.text();
        element.empty();
        element.append(builder.toString());
        if(val.length > 0){
            element.find('select').val(val);
        }
    }
    
    function bindChange(select){
        select.change(function(){
            var code = $(this).val();
            $.ajax({
                type : 'get',
                url : 'ajax/area.ashx',
                data : 
                {
                    type : architecture.region,
                    code : code
                },
                dataType : 'text',
                success : function(m){
                    m = str2json(m);
                    bindScope(m.scope);
                }
            });
        });
    }
    function bindRegion(data){
        var span = $(id).find('span').eq(1);
        bindSelect(span, data);
        var select = span.find('select');
        bindChange(select);
        select.change();
    }
    function bindScope(data){
        var span = $(id).find('span').eq(2)
        bindSelect(span, data);
        var select = span.find('select');
        var scopeId = select.val();
        var scope = $(id).find('input[name="scopeId"]');
        scope.val(scopeId);
        var estateId = $(form.formId).find('input[name="estateId"]').val();
        var estateName = $(form.formId).find('input[name="estateName"]');
        var validType = "remote['template/estate-view.aspx?scopeId=" + scopeId + "&id=" + estateId + "','estateName']";
        estateName.validatebox({
            validType : validType
        });
        select.change(function(){
            scopeId = $(this).val();
            scope.val(scopeId);
            validType = "remote['template/estate-view.aspx?scopeId=" + scopeId + "&id=" + estateId + "','estateName']";
            estateName.validatebox({
                validType : validType
            });
        });
    }
    return {
        init : initSelect
    };
})();
function str2json(data){
    return eval('(' + data + ')');
}
function stringBuilder(){
    var d = [];
    this.append = function(data){
        d.push(data);
    }
    this.toString = function(split){
        return d.join(split || '');
    }
}
function getBodyContent(html){
    var pattern = /<body[^>]*>((.|[\n\r])*)<\/body>/im;
    var matches = pattern.exec(html);
    if(matches){
        return matches[1];
    }
    else{
        return html;
    }
}
var base = 
{
    pageSize : 30,
    tabElement : '#tabs',
    treeElement : '#tree',
    dialogElement : '#dialog',
    loadingMsg : '加载中...',
    error : function(){
        $.messager.alert('出错了!', '加载信息错误，请重试。', 'error');
    },
    lockImg : 'url(/Content/easyui/themes/icons/lock.png)',
    unlockImg : 'url(/Content/easyui/themes/icons/unlock.png)',
    firstSplit : '^',
    secondSplit : '~',
    dateSplit : '-',
    timeSplit : ':',
    isFullSceen : false
};
var tabTitle = 
{
    architecture : '楼盘框架', searchTitle : '搜索结果'
};
var memberRole = { collecter: 1,
    frameworker: 2,
    agencer: 3,
    manager: 4
}
var architecture = 
{
    search: '-1', 
    unit : '0',
    build : '1',
    estate : '2',
    bigEstate : '3',
    scope : '21',
    region : '22',
    city : '23'
};
var layout = 
{
    init : function(){
        var $body = $('body');
        var p = $body.layout('panel', 'west');
        p.panel({
            onCollapse : function(){
                $body.layout('collapse', 'north');
                base.isFullSceen = true;
            },
            onExpand : function(){
                $body.layout('expand', 'north');
                base.isFullSceen = false;
            }
        });
    },
    fullScreen : function(){
        var $body = $('body');
        $body.layout('collapse', 'west');
        
    },
    unFullScreen : function(){
        var $body = $('body');
        $body.layout('expand', 'west');
    }
};
var tabs = (function () {
    var item = $(base.tabElement);
    var callback = null;
    var onLoad = function (panel) {
        if (callback != null) {
            if (typeof (callback) == 'function') {
                callback();
            }
            else {
                callback.init();
            }
        }
        return false;
    };
    return {
        init: function () {
            item.tabs({
                onLoad: onLoad,
                onUpdate: function (title) {
                    var tab = item.tabs('getTab', title);
                    tab.panel('refresh');
                    return false;
                }
            })
        },
        addNew: function (title, href, cb) {
            var option =
            {
                title: title, href: href,
                closable: true,
                closed: true,
                extractor: getBodyContent
            };
            callback = cb;
            if (item.tabs('exists', title)) {
                option =
                {
                    href: href
                };
                var tab = item.tabs('getTab', title);
                var param =
                {
                    tab: tab, options: option
                };
                item.tabs('select', title);
                item.tabs('update', param);
            }
            else {
                item.tabs('add', option);
            }
        },
        getTitle: function () {
            var tab = item.tabs('getSelected');
            return tab.panel('options').title;
        },
        load: function (type, code) {
            var url = null;
            if (type == architecture.build || type == architecture.unit) {
                //....
            }
            else {
                if (type == architecture.estate) {
                    url = 'build.aspx?type=' + type + '&code=' + code;
                    callback = build.init;
                }
                else {
                    url = 'estate.aspx?type=' + type + '&code=' + code;
                    callback = estate.init;
                }
                url = member.getUrl(url);
                this.addNew(tabTitle.architecture, url, callback);
            }
        }
    };
})();
var tree = (function () {
    var item = $(base.treeElement);
    var onClick = function (node) {
        item.tree('toggle', node.target);
        var attribute = node.attributes;
        if ((!node.state || node.state == 'closed') && attribute) {
            var type = attribute.type;
            var code = attribute.code;
            var url = 'estate.aspx?type=' + type + '&code=' + code;
            url = member.getUrl(url);
            var callback = estate.init;
            tabs.addNew(tabTitle.architecture, url, callback);
        }
    };
    var onBeforeExpand = function (node) {
        var attribute = node.attributes;
        if (attribute) {
            var type = attribute.type;
            var code = attribute.code;
            item.tree('options').url = 'ajax/tree.ashx?type=' + type + '&code=' + code;
        }
    }
    return {
        init: function () {
            var type = architecture.city;
            var code = '1';
            type = '';
            code = '';
            item.tree({
                url: 'ajax/tree.ashx?type=' + type + '&code=' + code,
                method: 'GET',
                onClick: onClick,
                onBeforeExpand: onBeforeExpand
            });
        },
        setCurrent: function (element) {
            item = $(element || base.treeElement);
        }
    };
})();
var toolTip = (function () {
    var wind = null;
    function load() {
        wind = $.messager.show({
            msg: '信息提示：<br/>命令执行中...', timeout: 0,
            modal: true
        });
    }
    function clear() {
        if (wind) {
            wind.window('destroy');
        }
    }
    function success() {
        wind.window('destroy');
        $.messager.show({
            msg: '信息提示：<br/>命令执行成功',
            timeout: 3 * 1000
        });
        wind = null;
    }
    function error() {
        wind.window('destroy');
        $.messager.show({
            msg: '信息提示：<br/>命令执行失败',
            timeout: 3 * 1000
        });
        wind = null;
    }
    return {
        load: load,
        success: success,
        error: error,
        clear:clear
    };
})();
var dialog = (function () {
    var needFresh = false;
    function hide() {
        var dialogJQ = $(base.dialogElement);
        dialogJQ.dialog('close');
    }
    function show(json, buttons, onClick, onLoad) {
        var dialogJQ = $(base.dialogElement);
        var data =
        {
            loadingMsg: base.loadingMsg,
            extractor: getBodyContent,
            onLoad: function () {
                if (typeof (onLoad) == 'function') {
                    onLoad();
                }
            },
            modal: true
        };
        var array = [];
        if (buttons && buttons > 0) {
            array.push({
                text: '确定',
                iconCls: 'icon-ok',
                handler: function () {
                    if (typeof (onClick) == 'function') {
                        onClick();
                    }
                    return false;
                }
            });
            if (buttons > 1) {
                array.push({
                    text: '取消',
                    iconCls: 'icon-cancel',
                    handler: function () {
                        dialogJQ.dialog('close');
                        return false;
                    }
                });
            }
        }
        $.extend(data, json,
        {
            buttons: array
        });
        dialogJQ.dialog(data);
        if (needFresh) {
            dialogJQ.dialog('refresh');
        }
        else {
            needFresh = true;
        }
    }
    return {
        show: show,
        hide: hide,
        confirm: function (message, callback) {
            var w = $.messager.confirm('对话框', message, function (v) {
                if (v && typeof (callback) == 'function') {
                    callback();
                    w = null;
                }
            });
        },
        alert: function (message) {
            $.messager.alert('对话框', message);
        }
    };
})();
var form = 
{
    init : function(url, callback){
        var formJQ = $(this.formId);
        formJQ.form({
            url : url,
            onSubmit : function(){
                var isValid = formJQ.form('validate');
                if(isValid){
                    dialog.hide();
                    toolTip.load();
                }
                return isValid;
            },
            success : function(data){
                if(data == 'true'){
                    toolTip.success();
                    if(typeof(callback) == 'function'){
                        callback();
                    }
                }
                else{
                    toolTip.error();
                }
            }
        });
    },
    submit : function(){
        $(this.formId).submit();
    },
    formId : '#form'
};
var navBar = 
{
    bindClick : function(){
        var nav_bar = '#nav-bar';
        var navBarJQ = $(nav_bar);
        var link = navBarJQ.find('a');
        var len = link.size();
        for(var idx = 0; idx < len; idx ++ ){
            link.eq(idx).click(function(){
                var type = $(this).attr('type');
                var code = $(this).attr('code');
                tabs.load(type, code);
            });
        }
    }
};
var member = (function () {
    var key = 'ui';
    var preUrl = { collect: 'template/collect/', framework: 'template/framework/', manage: 'template/manage/' };
    return { getRole: function () {
        var cookie = $.cookie(key);
        var m = cookie.split(base.firstSplit);
        var idx = m[2];
        return memberRole[idx.toLowerCase()];
    },
        getUrl: function (url) {
            var role = this.getRole();
            switch (role) {
                case memberRole.collecter:
                    {
                        url = preUrl.collect + url;
                        break;
                    }
                case memberRole.frameworker:
                    {
                        url = preUrl.framework + url;
                        break;
                    }
                case memberRole.manager:
                    {
                        url = preUrl.manage + url;
                        break;
                    }
                default:
                    break;
            }
            return url;
        }
    };
})();
