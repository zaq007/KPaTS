$(document).ready(function () {
    $('form').each(function (index, elem) {
        var formData = $.data(elem)
        if (formData.validator) {
            var settings = formData.validator.settings
            , oldErrorPlacement = settings.errorPlacement;

            settings.errorPlacement = function (label, element) {
                oldErrorPlacement(label, element);
                label.addClass("mdl-textfield__error");
            };

            settings.highlight = function (element) {
                $(element).parent().addClass("is-invalid");
            };

            settings.unhighlight = function (element) {
                $(element).parent().removeClass('is-invalid');
            };
        }
    });
});