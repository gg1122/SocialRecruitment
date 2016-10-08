
//去除左右空格
function trimStr(str)
{ return str.replace(/(^\s*)|(\s*$)/g, ""); }

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
    $.ajaxSetup({ cache: false, async: false });
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
function BackList(url) {

    window.location.href = '../../' + url;
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