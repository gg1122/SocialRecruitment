﻿
//去除左右空格
function trimStr(str)
{ return str.replace(/(^\s*)|(\s*$)/g, ""); }
//获取数组索引
function GetArrIndex(arr, val) {
    var r = -1;
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] == val) {
            r = i;
            break;
        }
    }
    return r;
}
function returnParent(value) {//获取子窗体返回值
    var parent = window.dialogArguments; //获取父页面
    //parent.location.reload(); //刷新父页面
    if (parent != null && parent != "undefined") {
        window.returnValue = value; //返回值
        window.close(); //关闭子页面
    }
    return;
}
function isNumber(id) {

    if (isNaN(Number(id.value))) {

        alert("非法数字");
        id.value = "";

    }
}
function CompareTime(StartTime, EndTime) {
    if (StartTime != "" && StartTime != null && EndTime != "" && EndTime != null) {
        var arr = StartTime.split("-");
        var starttime = new Date(arr[0], arr[1], arr[2]);
        var starttimes = starttime.getTime();
        var arrs = EndTime.split("-");
        var endtime = new Date(arrs[0], arrs[1], arrs[2]);
        var endimes = endtime.getTime();
        if (starttimes > endimes) {
            return false;
        }  
    }
    return true;
}

//根据表名字段名获取列表绑定数据
function GetSysField(id, table, colum) {

    $(id).empty();
    $("<option></option>")
            .val("")
            .text("请选择")
            .appendTo($(id));
    var url = "/SysField/GetSysField";
    $.ajaxSetup({ cache: false });
    $.getJSON(url, { table: table, colum: colum }, function (data) {
        if (data == null) {
            return;
        }
        $.each(data, function (i, item) {
            if (item == null) {
                return;
            }
            $("<option></option>")
                .val(item["MyTexts"])
                .text(item["MyTexts"])
                .appendTo($(id));

        });
    });
  
}

//联动
//id需绑定ID
//parentid父类ID
//colums需要绑定的列名称
//parentcolums父类的列名称
function GetSysFieldByParent(id, parentid, colums, parentcolums) {

    $(id).empty();
    $("<option></option>")
            .val("")
            .text("请选择")
            .appendTo($(id));
    var url = "/SysField/GetSysFieldByParent";
    $.ajaxSetup({ cache: false, async:false});
    $.ajaxSetup({ cache: false });
   // $.ajaxSetting.async = false;
    $.getJSON(url, { id: colums, parentid: parentcolums, value: $(parentid).val() }, function (data) {
        if (data == null) {
            return;
        }
        $.each(data, function (i, item) {
            if (item == null) {
                return;
            }
            $("<option></option>")
                .val(item["MyTexts"])
                .text(item["MyTexts"])
                .appendTo($(id));

        });
    });

}


//多级联动
//多级联动
function bindDropDownList(id, parentid) {

    if ($(parentid).val() != "") {

        var url = "/SysField/GetSysFieldByParent";
        $.ajaxSetup({ cache: false });
        $.getJSON(url, { id: id.substring(1), parentid: parentid.substring(1), value: $(parentid).val() }, function (data) {
            if (data == null) {
                return;
            }
            $(id).empty();
            $("<option></option>")
                    .val("")
                    .text("请选择")
                    .appendTo($(id));
            $.each(data, function (i, item) {
                if (item == null) {
                    return;
                }
                $("<option></option>")
                    .val(item["MyTexts"])
                    .text(item["MyTexts"])
                    .appendTo($(id));

            });
        });
    }
}
//多级联动
function bindDropDownList2(id, parentid, ctrlId, parentctrlId, DefaultValue) {
    if ($(parentctrlId).val() != "") {
        var url = "/Home/GetSysFieldByParent";
        $.ajaxSetup({ cache: false });
        $.getJSON(url, { id: id.substring(1), parentid: parentid.substring(1), value: $(parentctrlId).val() }, function (data) {
            if (data == null) {
                return;
            }
            $.each(data, function (i, item) {
                if (item == null) {
                    return;
                }
                if (item["Value"] == DefaultValue) {
                    $("<option selected></option>")
                        .val(item["Value"])
                        .text(item["Text"])
                        .appendTo($(ctrlId));
                }
                else {
                    $("<option></option>")
                        .val(item["Value"])
                        .text(item["Text"])
                        .appendTo($(ctrlId));
                }
            });
        });
    }
}

//function menuClick(url) {
//    if (url == "undefined" || url == "") { return; }
//    $("#frmMain").attr("src", '../../' + url);
//    return;
//}
//function getclick(ok) {
//}
//function GetEyeSize() {
//    return { width: document.documentElement.clientWidth, height: document.documentElement.clientHeight };
//}
//IFrame 调用页面后, 自动适应高度的代码.SetWinHeight(this);

function deleteTable(table, hidden) { //删除table和隐藏的值
    var tableId = document.getElementById(table); //获取表格
    tableId.parentNode.removeChild(tableId); //删除table
    // tableId.style.display = "none";//table隐藏isNaN(Number())
    var hiddenValue = document.getElementById(hidden); //获取隐藏的控件

    //  hiddenValue.value+="";

    if (hiddenValue.value.indexOf(table) > -1) {
        hiddenValue.value = hiddenValue.value.replace(table, ""); //为隐藏控件赋值
    }
}
function showModalMany2(me, url, dialogWidth, callback) { //弹出窗体，多选   
    if (dialogWidth == null || dialogWidth == "undefined" || dialogWidth == "") {
        dialogWidth = 968;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:" + dialogWidth + "px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }

    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = []; //需要添加到check中的内容
    var h = "";
    for (var i = 0; i < hid.length - 1; i++) {
        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {
            h += "^" + hid[i] + "&" + view[i + 1];
            content.push({ id: hid[i], name: view[i + 1] });
        }
    }
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden != null)
        hidden.value += h; //为隐藏控件赋值
    if (callback != null) {
        callback()
    }

    return content;
}
function showModalMany(me, url, dialogWidth, callback) { //弹出窗体，多选   
    if (dialogWidth == null || dialogWidth == "undefined" || dialogWidth == "") {
        dialogWidth = 968;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:" + dialogWidth + "px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }

    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = ""; //需要添加到check中的内容
    var h = "";
    for (var i = 0; i < hid.length - 1; i++) {
        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {

            var tableId = document.getElementById(hid[i] + "&" + view[i + 1]); //获取表格
            if (tableId == null) {
                h += "^" + hid[i] + "&" + view[i + 1];
                content += '<table  id="' + hid[i] + "&" + view[i + 1] + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable(' + "'" + hid[i] + "&" + view[i + 1] + "'," + "'" + me + "'" + ');" /></td><td>' + view[i + 1] + '</td></tr></table>';
            }
        }
    }
    var hidden = document.getElementById(me); //获取隐藏的控件
    hidden.value += h; //为隐藏控件赋值
    var c = document.getElementById("check" + me);
    c.innerHTML += content;
    if (callback != null) {
        callback()
    }
}

function showTreeOnlyEdit(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    var index = reValue.split("&"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    if (index[1] == null || index[1] == "undefined" || index[1].length < 1) {
        return;
    }
    var hid = index[0]; //为隐藏控件赋值
    var view = index[1]; //显示值
    var content = ""; //需要添加到check中的内容

    var href = window.location.href;
    var ref = href.substr(href.lastIndexOf('/') + 1);

    if (hid != null) {
        if (ref == hid) {
            alert("请不要选择同一条数据。");
            return;
        }
        if (hid != "undefined" && hid != "" && view != "undefined" && view != "") {

            content += '<table  id="' + hid + "&" + view
            + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid + "&" + view
             + "'," + "'" + me + "'" + ');" /></td><td>' + view
              + '</td></tr></table>';

            hidden.value = hid; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}

function showModalOnly(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden != null && hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    var index = reValue.split("^"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[0].length < 1) {
        return;
    }
    var hid = index[0].split('&'); //为隐藏控件赋值
    var view = index[1].split('&'); //显示值
    var content = ""; //需要添加到check中的内容
    if (hid != null && hid.length == 2) {
        var i = 0;

        if (hid[i] != "undefined" && hid[i] != "" && view[i + 1] != "undefined" && view[i + 1] != "") {

            content += '<table  id="' + hid[i]
            + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid[i] + "'," + "'" + me + "'" + ');" /></td><td >' + view[i + 1] + '</td></tr></table>';

            hidden.value = hid[i]; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}
function showModalOnly2(me, url) { //弹出窗体 ,单选
    var hidden = document.getElementById(me); //获取隐藏的控件
    if (hidden != null && hidden.value != null && hidden.value.length > 0) {
        alert("此处为单选，请先删除已有的选项，再次尝试选择。");
        return;
    }
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    var index = reValue.split("|"); //分割符 ^ 的位置
    if (index[0] == null || index[0] == "undefined" || index[1] == null || index[1] == "undefined") {
        return;
    }
    var hid = index[0]; //为隐藏控件赋值
    var view = index[1]; //显示值
    var content = ""; //需要添加到check中的内容

    if (hid != null) {
        var i = 0;

        if (hid != "undefined" && hid != "" && view != "undefined" && view != "") {

            content += '<table  id="' + hid
            + '" class="deleteStyle"><tr><td><img src="../../../Images/deleteimge.png" title="点击删除"  alt="删除" onclick=" deleteTable('
            + "'" + hid + "'," + "'" + me + "'" + ');" /></td><td>' + view + '</td></tr></table>';

            hidden.value = hid; //为隐藏控件赋值
            var c = document.getElementById("check" + me);
            c.innerHTML += content;
            return;
        }
    }
    alert("请只选择一条数据。");
    return;
}

function showModalMultProperty(properties, url) { //弹出窗体 ,单选
    var reValue = window.showModalDialog(url, window, "dialogHeight:500px; dialogWidth:987px;  status:off; scroll:auto");

    if (reValue == null || reValue == "undefined" || reValue == "") {
        return; //如果返回值为空，就返回
    }
    var rArr = reValue.split("|");
    var pArr = properties.split("|");
    if (rArr.length == pArr.length) {
        for (var i = 0; i < pArr.length; i++) {
            $("#" + pArr[i]).val(rArr[i]);
        }
    }
    else {
        alert("返回数据与属性集合不匹配。");
    }
    return;
}

function isInt(t) {
    t.value = t.value.replace(/[^0-9]/g, '')
}
function dia() {
    if ($("#dialo").dialog("isOpen")) {
        $("#dialo").dialog({
            autoOpen: true,

            buttons: {
                "确定": function () {
                    $("#dialo").dialog("close");
                }
            }
        });
    }
}
function BackList(url) {

    window.location.href = '../../' + url;
}
function manyTreeChecked(node, checked, hidControl, treeId) {
    var hidArr = $('#' + hidControl).val().split(',');
    //debugger;
    //alert(hidArr.join(','));
    if (checked) {
        hidArr.push(node.id);
        var nodeChildren = $('#' + treeId).tree("getChildren", node.target);
        if (nodeChildren != null) {
            for (var i = 0; i < nodeChildren.length; i++) {
                treeChecked(nodeChildren[i].id, treeId, "tree-checkbox1");
                hidArr.push(nodeChildren[i].id);
            }
        }
    }
    else {
        //debugger;
        for (var i = 0; i < hidArr.length; i++) {
            if (hidArr[i] == node.id) {
                hidArr.splice(i, 1);
            }
        }
        var nodeChildren = $('#' + treeId).tree("getChildren", node.target);
        if (nodeChildren != null) {
            for (var i = 0; i < nodeChildren.length; i++) {
                treeChecked(nodeChildren[i].id, treeId, "tree-checkbox0");
                for (var j = 0; j < hidArr.length; j++) {
                    if (hidArr[j] == nodeChildren[i].id) {
                        hidArr.splice(j, 1);
                    }
                }
            }
        }
    }
    $('#' + hidControl).val(hidArr.join(','));
}
function bindmanyTreeChecked(checkData, hidControl, treeId) {
    if (checkData == null || checkData == "" || checkData == "undefined") {
        return;
    }
    var menuids = checkData.split(',');
    var hidArr = $('#' + hidControl).val().split(',');
    for (i = 0; i < menuids.length; i++) {
        treeChecked(menuids[i], treeId, "tree-checkbox1");
        hidArr.push(menuids[i]);
    }
    $('#' + hidControl).val(hidArr.join(','));
}
function bindSonTreeChecked(oldData, newData, treeId) {
    if (oldData == null || oldData == "" || oldData == "undefined") {
        return;
    }
    var menuids = oldData.split(',');
    var sonids = newData.split(',');
    for (i = 0; i < menuids.length; i++) {
        for (j = 0; j < sonids.length; j++) {
            if (menuids[i] == sonids[j]) {
                treeChecked(menuids[i], treeId, "tree-checkbox1");
                break;
            }
        }
    }
}
function treeChecked(node, treeId, className) {
    var nodeid = $("#" + treeId).tree("find", node);
    if (nodeid) {
        var ck = $(nodeid.target).find('.tree-checkbox');
        ck.removeClass("tree-checkbox0 tree-checkbox1 tree-checkbox2");
        ck.addClass(className);
    }
}

//<!--验证正整数-->
function validateInt(val) {
    var reg1 = /^\d+$/;
    return reg1.test(val);
}
//<!--数值验证-->
function validateDigital(val) {
    return !isNaN(val);
}
//<!--邮箱验证-->
function validateEmail(val) {
    var testReg = /^([a-zA-Z0-9]+[_|\_|\.|\-]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.|\-]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,4}$/;
    return testReg.test(val);
}
//更新CKEditor在线编辑器
function updateEditor(ckid, html) {
    deleteEditor(ckid);
    return createEditor(ckid, html);
}
//删除CKEditor在线编辑器
function deleteEditor(ckid) {
    var editorName = $("#" + ckid).attr("editorName");
    var objEditor = CKEDITOR.instances[editorName];
    if (objEditor) {
        CKEDITOR.remove(objEditor);
        delete objEditor;
    }
    $("#" + ckid).html("");
}
//创建CKEditor在线编辑器
function createEditor(ckid, html) {
    var config = {
        bodyClass: 'contents',
        height: 250,
        width: 700,
        enterMode: 2,
        toolbar: 'Full'
        /*toolbar: [
        ['Bold', 'Italic', 'Underline', 'Strike', 'TextColor', 'BGColor', '-', 'JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock', 'HorizontalRule', '-', 'Link', 'Unlink', 'Image', 'Table', '/', 'Font', 'FontSize', 'Maximize', 'Source']
        ]*/
    };
    editor = CKEDITOR.appendTo(ckid, config, html);
    $("#" + ckid).attr("editorName", editor.name);

    return editor.name;
}
//日期格式
function jsonDateFormat(jsonDate) {//json日期格式转换为正常格式
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();       
        return date.getFullYear() + "-" + month + "-" + day;
    } catch (ex) {
        return "";
    }
}
//日期时间格式
function jsonDateTimeFormat(jsonDate) {//json日期格式转换为正常格式
    try {
        var date = new Date(parseInt(jsonDate.replace("/Date(", "").replace(")/", ""), 10));
        var month = date.getMonth() + 1 < 10 ? "0" + (date.getMonth() + 1) : date.getMonth() + 1;
        var day = date.getDate() < 10 ? "0" + date.getDate() : date.getDate();
        var hours = date.getHours();
        var minutes = date.getMinutes();
        var seconds = date.getSeconds();
        var milliseconds = date.getMilliseconds();
        return date.getFullYear() + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds + "." + milliseconds;
    } catch (ex) {
        return "";
    }
}
//是否登录用于控制页头显示隐藏控件
//YesHideIDList:已登录隐藏控件
//YesShowIDList:已登录显示控件
//NoHideIDList:未登录隐藏控件
//NoShowIDList:未登录显示控件
function TopBtnHideShow(YesHideIDList, YesShowIDList,NoHideIDList, NoShowIDList) {
   
        $.ajax({
            url: "/Account/GetIsLogining",
            type: "post",
            dataType: "text",           
            success: function (data) {
                if(data=="Y")
                {
                    for (var i = 0; i < YesHideIDList.length; i++) {
                        $(YesHideIDList[i]).hide();
                    }
                    for (var i = 0; i < YesShowIDList.length; i++) {
                        $(YesShowIDList[i]).show();
                    }
                }
                else
                {
                    for (var i = 0; i < NoHideIDList.length; i++) {
                        $(NoHideIDList[i]).hide();
                    }
                    for (var i = 0; i < NoShowIDList.length; i++) {
                        $(NoShowIDList[i]).show();
                    }
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alert("操作失败");
            }
        });
   
}
