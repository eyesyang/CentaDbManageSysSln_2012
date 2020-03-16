var estate = (function () {
    var rsList = '#rs-list';
    var pageBar = '#page-bar';

    var initBtn = function () {
        var $rs = $(rsList);
        var $estateName = $rs.find('.btn-a');
        var $edit = $rs.find('.btn-b');
        var $completed = $rs.find('.btn-c');

        $estateName.linkbutton({ plain: 'true' });
        $edit.linkbutton({ iconCls: 'icon-edit', plain: 'true' });
        $completed.linkbutton({ iconCls: 'icon-ok', plain: 'true' });

        $estateName.click(linkTo);
        $edit.click(editOnClick);
        $completed.click(completedOnClick);

        function linkTo(event) {
            var cd = getEstateId(event);
            var tp = architecture.estate;
            var url = 'build.aspx?type=' + tp + '&code=' + cd;
            var href = member.getUrl(url);
            var callback = build.init;
            tabs.addNew(tabTitle.architecture, href, callback);
        }
        function editOnClick(event) {
            var estateId = getEstateId(event);
            var url = 'estate-edit.aspx?id=' + estateId;
            url = member.getUrl(url);
            var json = { width: 600, height: 250, title: '编辑楼盘', href: url };
            var onclick = function () {
                form.submit();
            }
            var onload = function () {
                form.init(url, refresh);
            }
            dialog.show(json, 2, onclick, onload);
        }
        function completedOnClick(event) {
            var estateId = getEstateId(event);
            dialog.confirm('确定已经完成此楼盘的框架工作吗?', function () {
                var estateId = getEstateId(event);
                var url = 'estate.aspx/complete';
                url = member.getUrl(url);
                toolTip.load();
                $.ajax({
                    url: url,
                    type: 'post',
                    data: '{id:\'' + estateId + '\'}',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function (d) {
                        if (d.d) {
                            toolTip.success();
                            refresh();
                        }
                        else {
                            toolTip.error();
                        }
                    },
                    error: function () {
                        toolTip.clear();
                        base.error();
                    }
                });
            });
        }

        function getEstateId(event) {
            event = event || window.event;
            var element = $(event.srcElement || event.target);
            var id;
            while (true) {
                id = element.attr('id');
                if (id && id != 'undefined') {
                    return id;
                }
                element = element.parent();
            }
        }
    }
    var initPage = function () {
        var $rs = $(rsList);
        var $pageBar = $(pageBar);
        var recordCount = $rs.find('#recordCount').val();
        var pageSize = $rs.find('#pageSize').val();
        $pageBar.pagination({
            total: recordCount,
            pageSize: pageSize,
            pageList: [50, 100, 200],
            onSelectPage: function (idx, rows) {
                $pageBar.pagination({
                    loading: true
                });
                refresh(idx, rows);
                $pageBar.pagination({
                    loading: false
                });
            }
        });
    };
    var refresh = function (idx, rows) {
        var type = getType();
        var code = getCode();
        var url = 'estate-refresh.aspx?type=' + type + '&code=' + code + '&pageIndex=' + idx;
        url = member.getUrl(url);
        var $buildTemp = $('#build-temp');
        var load = '<img src="Content/easyui/themes/default/images/pagination_loading.gif" /> loading...';
        $buildTemp.empty();
        $buildTemp.append(load);
        $.ajax({
            url: url,
            type: 'get',
            cache: false,
            dataType: 'text',
            success: function (data) {
                $buildTemp.empty();
                $buildTemp.append(data);
                initBtn();
            },
            error: function () {
                $build_temp.empty();
                $build_temp.append('error!!!');
            }
        });
    }
    var getType = function () {
        return $('#nav-bar').find(':hidden').eq(0).val();
    }
    var getCode = function () {
        return $('#nav-bar').find(':hidden').eq(1).val();
    }
    return { init: function () {
        navBar.bindClick();
        initPage();
        initBtn();
    }
    }
})();

var build = (function () {
    var rsList = '#rs-list';
    var pageBar = '#page-bar';

    function init() {
        var $rs = $(rsList);
        var $banch = $('#btn-banch');
        var $addNew = $('#btn-add');      

        $banch.click(banch);
        $addNew.click(addNew);

        function banch() {
            var estateId = getEstateId();
            var url = 'build-banch.aspx?id=' + estateId;
            url = member.getUrl(url);
            var json = { width: 600, height: 350, title: '批量添加栋座', href: url };
            var onClick = function () {
                form.submit();
            }
            var onLoad = function () {
                form.init(url, refresh);
            }
            dialog.show(json, 2, onClick, onLoad);
        }
        function addNew() {
            var estateId = getEstateId();
            var url = 'build-add.aspx?id=' + estateId;
            url = member.getUrl(url);
            var json = { width: 600, height: 350, title: '添加栋座', href: url };
            var onClick = function () {
                form.submit();
            }
            var onLoad = function () {
                form.init(url, refresh);
            }
            dialog.show(json, 2, onClick, onLoad);
        }
        initBtn();
    }

    function initBtn() {
        var $rs = $(rsList);

        var $buildName = $rs.find('.btn-a');
        var $edit = $rs.find('.btn-b');
        var $complete = $rs.find('.btn-c');
        var $remove = $rs.find('.btn-d');

        $buildName.linkbutton({ plain: 'true' });
        $complete.linkbutton({ plain: 'true', iconCls: 'icon-ok' });
        $edit.linkbutton({ plain: 'true', iconCls: 'icon-edit' });
        $remove.linkbutton({ plain: 'true' });

        $buildName.click(nameOnClick);
        $complete.click(completedOnClick);
        $edit.click(editOnClick);
        $remove.click(removeOnClick);

        function nameOnClick(event) {
            var buildId = getBuildId(event);
            var url = 'unit.aspx?id=' + buildId;
            url = member.getUrl(url);
            var callback = unit.init;
            tabs.addNew(tabTitle.architecture, url, callback);
        }

        function completedOnClick(event) {
            dialog.confirm('确定需要完成收集吗?', function () {
                var buildId = getBuildId(event);
                var url = 'build.aspx/complete';
                url = member.getUrl(url);
                toolTip.load();
                $.ajax({
                    url: url,
                    type: 'post',
                    data: '{id:\'' + buildId + '\'}',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function (d) {
                        if (d.d) {
                            toolTip.success();
                            refresh();
                        }
                        else {
                            toolTip.error();
                        }
                    },
                    error: function () {
                        toolTip.clear();
                        base.error();
                    }
                });
            });
        }
        function editOnClick(event) {
            var buildId = getBuildId(event);
            var url = 'build-edit.aspx?id=' + buildId;
            url = member.getUrl(url);
            var json = { width: 600, height: 300, title: '编辑栋座', href: url };
            var onclick = function () {
                form.submit();
            }
            var onload = function () {
                form.init(url, refresh);
            }
            dialog.show(json, 2, onclick, onload);
        }
        function removeOnClick(event) {
            dialog.confirm('确定需要删除该栋座吗?', function () {
                var buildId = getBuildId(event);
                var url = 'build.aspx/remove';
                url = member.getUrl(url);
                toolTip.load();
                $.ajax({
                    url: url,
                    type: 'post',
                    data: '{id:\'' + buildId + '\'}',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function (d) {
                        if (d.d) {
                            toolTip.success();
                            refresh();
                        }
                        else {
                            toolTip.error();
                        }
                    },
                    error: function () {
                        toolTip.clear();
                        base.error();
                    }
                });
            });
        }

        function getBuildId(event) {
            event = event || window.event;
            var element = $(event.srcElement || event.target);
            var id;
            while (true) {
                id = element.attr('id');
                if (id && id != 'undefined') {
                    return id;
                    break;
                }
                element = element.parent();
            }
        }
    }
    function initPage() {
        var $rs = $(rsList);
        var $pageBar = $(pageBar);
        var recordCount = $rs.find('#recordCount').val();
        var pageSize = $rs.find('#pageSize').val();
        $pageBar.pagination({
            total: recordCount,
            pageSize: pageSize,
            pageList: [50, 100, 200],
            onSelectPage: function (idx, rows) {
                $pageBar.pagination({
                    loading: true
                });
                refresh(idx, rows);
            }
        });
    };
    function refresh(idx, rows) {
        var estateId = getEstateId();
        var url = 'build-refresh.aspx?code=' + estateId;
        if (arguments.length > 0) {
            url = 'build-refresh.aspx?code=' + estateId + '&pageIndex=' + idx;
        }
        url = member.getUrl(url);
        var $buildTemp = $('#build-temp');
        var load = '<img src="Content/easyui/themes/default/images/pagination_loading.gif" /> loading...';
        $buildTemp.empty();
        $buildTemp.append(load);
        $.ajax({
            url: url,
            type: 'get',
            cache: false,
            dataType: 'text',
            success: function (data) {
                $buildTemp.empty();
                $buildTemp.append(data);
                initBtn();
            },
            error: function () {
                $build_temp.empty();
                $build_temp.append('error!!!');
            }
        });
    }
    function getEstateId() {
        return $('#nav-bar').find(':hidden').val();
    }

    return { init: function () {
        navBar.bindClick();
        initPage();
        init();
    }
    }
})();
var unit = (function () {
    var unitTable = '#unit-table';
    var bindDrag = function () {
        var element = $(unitTable).find('.unit-drag');
        element.draggable({
            revert: true,
            proxy: 'clone',
            cursor: 'move',
            onStartDrag: function () {
                $(this).draggable('options').cursor = 'not-allowed';
                $(this).draggable('proxy').addClass('unit-proxy');
            },
            onStopDrag: function () {
                $(this).draggable('options').cursor = 'auto';
            },
            onBeforeDrag: function (e) {
                var target = e.srcElement || e.target;
                var cls = $(target).attr('class');
                if (cls.indexOf('ck-unit') >= 0 || cls.indexOf('icon-search') >= 0 || cls.indexOf('btn-d') >= 0 || cls.indexOf('icon-edit') >= 0 || cls.indexOf('l-btn-text') >= 0) {
                    return false;
                }
            }
        }).droppable({
            handle: '.info-top',
            onDragEnter: function (e, source) {
                var target = $.trim($(this).html().replace('&nbsp;', ''));
                var source_c = $.trim($(source).html().replace('&nbsp;', ''));
                if (target.length > 0 || source_c.length == 0) {
                    $(source).draggable('options').cursor = 'not-allowed';
                }
                else {
                    $(source).draggable('options').cursor = 'auto';
                    $(source).draggable('proxy').css('border', '1px solid green');
                }
            },
            onDragLeave: function (e, source) {
                $(source).draggable('options').cursor = 'not-allowed';
            },
            onDrop: function (e, source) {

                var targetJQ = $(this);
                var sourceJQ = $(source);

                var target_td_JQ = $(getTdElement(this));
                var source_td_JQ = $(getTdElement(source));

                var target = $.trim(targetJQ.html().replace('&nbsp;', ''));
                var source_c = $.trim(sourceJQ.html().replace('&nbsp;', ''));
                var target_text = $.trim(targetJQ.text().replace('&nbsp;', ''));
                if ((target_text.length == 0 || target_text == '填充房源') && source_c.length > 0) {
                    moveUnit();
                }
                function moveUnit() {
                    var row = target_td_JQ.attr('row');
                    var col = target_td_JQ.attr('col');
                    var unitId = getUnitId(source);
                    toolTip.load();
                    $.ajax({
                        type: 'post',
                        url: 'template/unit-move.aspx',
                        data:
                        {
                            unitId: unitId,
                            x_axis: col,
                            y_axis: row
                        },
                        dataType: 'text',
                        success: function (data) {
                            if (data == 'true') {
                                targetJQ.html($(source).html());
                                sourceJQ.html('&nbsp;');
                                targetJQ.find('.info-top').html('<input class="ck-unit" type="checkbox" value="' + unitId + '" />' + row + col);
                                targetJQ.find('.btn-d').click(removeSingleData);
                                target_td_JQ.addClass('unit-bg');
                                source_td_JQ.removeClass('unit-bg');
                                removeEmpty();
                                toolTip.success();
                            }
                            else {
                                toolTip.error();
                            }
                        },
                        error: function () {
                            toolTip.clear();
                            base.error();
                        }
                    });
                }
                function removeEmpty(unitId) {
                    var ck,
                    rowIndex,
                    columnIndex,
                    count;
                    var tr = $(table_unit).find('tr');
                    var row_count = tr.size();
                    rowIndex = source_td_JQ.attr('wor');
                    columnIndex = source_td_JQ.attr('loc');
                    var ck_count = tr.eq(rowIndex).find(':checkbox').size() - 1;
                    if (ck_count == 0) {
                        refresh();
                    }
                    else {
                        ck_count = 0;
                        for (var index = 1; index <= row_count; index++) {
                            if (tr.eq(index).find('td').eq(columnIndex).find(':checkbox').size() > 0) {
                                ck_count++;
                            }
                        }
                        if (ck_count == 0) {
                            refresh();
                        }
                    }
                }
                function getUnitId(srcElement) {
                    return $(srcElement).find('div').attr('id');
                }
            }
        });
    }
    function getTdElement(srcElement) {
        while (true) {
            if (srcElement.tagName == 'TD') {
                break;
            }
            srcElement = $(srcElement).parent().get(0);
        }
        return srcElement;
    }

    function getDragElement(event) {
        event = event || window.event;
        var element = $(event.srcElement || event.target);
        var id = null;
        while (true) {
            id = element.attr('id');
            if (id && id != 'undefined') {
                break;
            }
            element = element.parent();
        }
        return element;
    }

    function getCheckbox(info, callback) {
        var checkbox = $(unitTable).find('.ck-unit:checked');
        var count = checkbox.length;
        if (count <= 0) {
            $.messager.alert('提示信息', '请选择需要 <span style="color:red;">"' + info + '"</span> 的数据。', 'info');
            return;
        }
        var unitId = [];
        for (var idx = 0; idx < count; idx++) {
            var val = checkbox.eq(idx).val();
            unitId.push(val);
        }
        if (typeof (callback) == 'function') {
            callback(unitId);
        }
    }
    function refresh() {
        var temp = $('#unit-temp');
        var load = '<img src="Content/easyui/themes/default/images/pagination_loading.gif" /> loading...';
        var buildId = getBuildId();
        var url = 'unit-refresh.aspx?id=' + buildId;
        url = member.getUrl(url);
        temp.empty();
        temp.append(load);
        $.ajax({
            url: url,
            type: 'get',
            cache: false,
            dataType: 'text',
            success: function (d) {
                temp.empty();
                temp.append(getBodyContent(d));
                unitBtnInit();
                //bindDrag();
            },
            error: function () {
                temp.empty();
                temp.append('error!!!');
            }
        });
    }
    function getBuildId() {
        return $('#nav-bar').find(':hidden').val();
    }

    function edit(event) {
        var element = getDragElement(event);
        var unitId = getUnitId(element);
        var url = 'unit-edit.aspx?id=' + unitId;
        url = member.getUrl(url);
        var json = { width: 600, height: 450, title: '编辑单元', href: url };
        var onclick = function () {
            form.submit();
        }
        var onload = function () {
            form.init(url, function () {
            });
        }
        dialog.show(json, 2, onclick, onload);
    }

    function remove(event) {
        var element = getDragElement(event);
        var unitId = getUnitId(element);
        var url = 'unit.aspx/remove';
        url = member.getUrl(url);
        var callback = function () {
            toolTip.load();
            $.ajax({
                url: url,
                type: 'post',
                data: '{id:\'' + unitId + '\'}',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (d) {
                    if (d.d) {
                        toolTip.success();
                        refresh();
                    }
                    else {
                        toolTip.error();
                    }
                },
                error: function () {
                    toolTip.clear();
                    base.error();
                }
            });
        }
        dialog.confirm('确定要删除选定的单元吗？', callback);
    }

    function fillData(event) {
        var td = $(getTdElement(event.srcElement || event.target));
        dialog.confirm('确定需要填充房源吗?', function () {
            var buildId = getBuildId();            
            var cy_axis = td.attr('row').replace('楼', '');
            var cx_axis = td.attr('col').replace('室', '');
            var url = 'unit.aspx/fill';
            url = member.getUrl(url);
            toolTip.load();
            $.ajax({
                url: url,
                type: 'post',
                data: '{id:\'' + buildId + '\', cx_axis: \'' + cx_axis + '\', cy_axis:\'' + cy_axis + '\'}',
                dataType: 'json',
                contentType: "application/json; charset=utf-8",
                success: function (d) {
                    if (d.d) {
                        toolTip.success();
                        refresh();
                    }
                    else {
                        toolTip.error();
                    }
                },
                error: function () {
                    toolTip.clear();
                    base.error();
                }
            });
        });
    }


    function getUnitId(element) {
        return element.find('.ck-unit').val();
    }

    function init() {
        var $undo = $('#btn-undo');
        var $standard = $('#btn-standard');
        var $complete = $('#btn-complete');
        var $addNew = $('#btn-add');
        var $remove = $('#btn-remove');

        $undo.click(undo);
        $standard.click(standard);
        $complete.click(complete);
        $addNew.click(addNew);
        $remove.click(removeAll);

        function undo() {
            dialog.confirm('确定撤销所有更改吗？', function () {
                toolTip.load();
                var buildId = getBuildId();
                var url = "unit.aspx/undo";
                url = member.getUrl(url);
                $.ajax({
                    url: url,
                    type: 'post',
                    data: '{id:\'' + buildId + '\'}',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function (d) {
                        if (d.d) {
                            toolTip.success();
                            refresh();
                        }
                        else {
                            toolTip.error();
                        }
                    },
                    error: function () {
                        toolTip.clear();
                        base.error();
                    }
                });
            });
        }

        function standard() {
            dialog.confirm('确定需要标准化单元吗？', function () {
                toolTip.load();
                var buildId = getBuildId();
                var url = "unit.aspx/standard";
                url = member.getUrl(url);
                $.ajax({
                    url: url,
                    type: 'post',
                    data: '{id:\'' + buildId + '\'}',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function (d) {
                        if (d.d) {
                            toolTip.success();
                            refresh();
                        }
                        else {
                            toolTip.error();
                        }
                    },
                    error: function () {
                        toolTip.clear();
                        base.error();
                    }
                });
            });
        }

        function complete() {
            dialog.confirm('确定录入完成吗？', function () {
                toolTip.load();
                var buildId = getBuildId();
                var url = "build.aspx/complete";
                url = member.getUrl(url);
                $.ajax({
                    url: url,
                    type: 'post',
                    data: '{id:\'' + buildId + '\'}',
                    dataType: 'json',
                    contentType: "application/json; charset=utf-8",
                    success: function (d) {
                        if (d.d) {
                            toolTip.success();
                            refresh();
                        }
                        else {
                            toolTip.error();
                        }
                    },
                    error: function () {
                        toolTip.clear();
                        base.error();
                    }
                });
            });
        }

        function addNew() {
            var buildId = getBuildId();
            var url = 'unit-add.aspx?id=' + buildId;
            url = member.getUrl(url);
            var json = { width: 600, height: 500, title: '添加单元', href: url };
            var onClick = function () {
                form.submit();
            }
            var onLoad = function () {
                form.init(url, refresh);
            }
            dialog.show(json, 2, onClick, onLoad);
        }
        function removeAll() {
            getCheckbox('删除', function (unitId) {
                var url = 'unit.aspx/remove';
                url = member.getUrl(url);
                var callback = function () {
                    toolTip.load();
                    $.ajax({
                        url: url,
                        type: 'post',
                        data: '{id:\'' + unitId.join(base.firstSplit) + '\'}',
                        dataType: 'json',
                        contentType: "application/json; charset=utf-8",
                        success: function (d) {
                            if (d.d) {
                                toolTip.success();
                                refresh();
                            }
                            else {
                                toolTip.error();
                            }
                        },
                        error: function () {
                            toolTip.clear();
                            base.error();
                        }
                    });
                }
                dialog.confirm('确定要删除选定的单元吗？', callback);
            });
        }
    }

    function unitBtnInit() {


        var single = $(unitTable);
        var btn_b = single.find('.btn-b');
        var btn_d = single.find('.btn-d');
        var ck_all = single.find('.ck-all');
        var ck_col = single.find('.ck-col');
        var ck_row = single.find('.ck-row');



        single.find('td').mouseover(function () {
            var html = $.trim($(this).html());
            if (html.length > 0) {
                return;
            }
            else {
                $(this).html('<a href="#" class="btn-g">填充房源</a>');
                var btn_g = $(this).find('.btn-g');
                btn_g.linkbutton({
                    plain: true
                });
                btn_g.click(fillData);
            }
        }).mouseleave(function () {
            var text = $(this).text();
            if (text == '填充房源') {
                $(this).html('');
            }
        });

        btn_b.click(edit);

        btn_d.click(remove);
        //全选
        ck_all.change(function () {
            var ck = $(this).attr('checked');
            ck_col.attr('checked', ck);
            ck_row.attr('checked', ck);
            ck_row.change();
        });
        //选择列
        ck_col.change(function () {
            var ck = $(this).attr('checked');
            var columnIndex = $(this).val();
            var tr = single.find('tr');
            var row_count = tr.length;
            for (var idx = 1; idx <= row_count; idx++) {
                tr.eq(idx).find('td').eq(columnIndex).find(':checkbox').attr('checked', ck);
            }
        });
        //选择行
        ck_row.change(function () {
            var ck = $(this).attr('checked');
            var rowIndex = $(this).val();
            single.find('tr').eq(rowIndex).find(':checkbox').attr('checked', ck);
        });
    }

    return {
        init: function () {
            navBar.bindClick();
            init();
            unitBtnInit();
            //setTimeout(bindDrag, 1500);
        }
    }
})()
$(document).ready(function(){
    tree.init();
    tabs.init();
    clock.init();
    layout.init();
});