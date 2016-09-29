function ajaxFrom(form, url) {
    $.ajax({
        url: url,
        type: "Post",
        data: $(form).serialize(),
        dataType: "json",
        success: function (data) {
            alert(data.Message);
            if (data.Code == 1) {
                window.location.href = "../Person";
            }
            $("input[type='submit']").attr('disabled', false);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert("操作失败")
            $("input[type='submit']").attr('disabled', false);
            return false;
        }
    });
}
$(function () {
    $("form").submit(function (form) {
        if (form.result) {
            $("input[type='submit']").attr('disabled', true);
            ajaxFrom(this, this.action);
        }
        return false;
    });
});