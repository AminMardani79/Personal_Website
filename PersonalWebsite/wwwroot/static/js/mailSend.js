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
    };

	jQuery('.form-message').hide();
	jQuery('#snd_message').show();

    jQuery.ajax({
        type: "POST",
        crossOrigin: true,
        url: "static/php/contact.php",
        data: data,
        success: function(response) {
			jQuery('.form-message').hide();
            if (response == '1') {
                jQuery('#suce_message').show();
                jQuery("#contact-form")[0].reset();
            } else {
                jQuery('#err_message').show();
            }
        }
    });

}