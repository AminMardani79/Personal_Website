var audio = document.getElementById("audioPlayer");
var isPlaying = false;

function startAudio() {
    audio.loop = true;
    isPlaying ? audio.pause() : audio.play();
};

audio.onplaying = function () {
    isPlaying = true;
};
audio.onpause = function () {
    isPlaying = false;
};
document.addEventListener("DOMContentLoaded", function (event) {
    audio.play()
});
const { log } = require("util");

function send_mail() {
    var name = $("#name").val();
    var email = $("#email").val();
    var number = $("#number").val();
    var subject = $("#subject").val();
    var message = $("#message").val();

    var flag = 0;

    if (name == "") {
        jQuery("#name").addClass('invalid');
        jQuery("#val_user_name").html("وارد کردن نام الزامی است");
        flag = 1;
    } else {
        jQuery("#name").removeClass('invalid');
        jQuery("#val_user_name").html("");
    }

    if (subject == "") {
        jQuery("#subject").addClass('invalid');
        jQuery("#val_subject").html("وارد کردن موضوع الزامی است");
        flag = 1;
    } else {
        jQuery("#subject").removeClass('invalid');
        jQuery("#val_subject").html("");
    }

    if (message == "") {
        jQuery("#message").addClass('invalid');
        jQuery("#val_message").html("لطفا پیام خود را وارد کنید");
        flag = 1;
    } else {
        jQuery("#message").removeClass('invalid');
        jQuery("#val_message").html("");
    }

    if (flag == 1) {
        return false;
    }

    var data = {
        "name": name,
        "subject": subject,
        "message": message,
        "email": email,
        "number": number
    };

    jQuery('.form-message').hide();
    jQuery('#snd_message').show();

    $.ajax({
        url: "/SendMessage", //1
        data: data, //2
        type: "Get", //3
    }).done(function () {
        Swal.fire(
            'ارسال شد',
            'پیام با موفقیت ارسال شد',
            'success'
        ).then(() => {
            $("#name").val('');
            $("#email").val('');
            $("#number").val('');
            $("#subject").val('');
            $("#message").val('');
        });
    });
}