
function ajaxFrom(form, url) {
    $.ajax({
        url: url,
        type: "Post",
        data: $(form).serialize(),
        dataType: "json",
        success: function (data) {
            alert(data.Message);          
            if(data.Url!=null && trimStr(data.Url)!="")
            {
                window.location.href = data.Url;            
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("操作失败")
            return false;
        }
    });
}


$(function () {

    $("form").submit(function (form) {      
        if (form.result) {
            ajaxFrom(this, this.action);
        }
        return false;
    });
    //按钮样式
    $('.a2').mouseover(function () { this.style.color = "#ae1121"; }).mouseout(function () { this.style.color = "#333"; });
});
