//提示框定时关闭
function clock() {
    setTimeout(function () {
        $('#toast').hide();
    }, 2000);
}

//添加提示框组件
function toast() {
    var toast = "<div id='toast' style='display:none;'><div class='weui_mask_transparent'></div><div class='weui_toast'><i class='weui_icon_warn'></i><p class='weui_toast_content'></p></div></div>"
    $("body").append(toast);
}

//短信验证码
function vcode(o) {
    var wait = 60;
    function time(o) {
        if (wait == 0) {
            $(o).removeClass("weui_btn_disabled");
            o.setAttribute("onclick", "vcode(this)");
            o.text = "获取验证码";
        } else {
            $(o).addClass("weui_btn_disabled");
            $(o).removeAttr('onclick');
            o.text = wait;
            wait--;
            setTimeout(function () {
                    time(o)
                },
                1000)
        }
    }
    time(o);
}

//体重血压展示条目切换
$('#container').on('click', '.weui_navbar_item', function () {
    $(this).addClass('weui_bar_item_on').siblings('.weui_bar_item_on').removeClass('weui_bar_item_on');
});

//日期查询显示当月月份
//$(function() {
//    var date = new Date();
//    var nowmonth=date.getMonth()+1;
//    alert(nowmonth);
//    $("input[type='month']").val(nowmonth);
//});