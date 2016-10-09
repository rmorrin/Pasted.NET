// Write your Javascript code.
$(function () {
    $.material.init();
});


$.validator.setDefaults({
    highlight: function (e, v) {
        $(e).parents(".form-group").addClass('has-error').find('.field-validation-error').addClass('text-danger');
    },
    unhighlight: function (e) {
        $(e).parents(".form-group").removeClass('has-error').find('.field-validation-error').removeClass('text-danger');
    }
});