(function ($) {
    $(".socialmetatagEnabled").change(function () {
        var inputid = '#' + this.name.replace("Enabled", "Required");
        if (this.checked) {
            $(inputid).prop("disabled", false);
        }
        else {
            $(inputid).prop("checked", false);
            $(inputid).prop("disabled", true);
        }
    });

    $(".socialmetatagRequired").change(function () {
        var inputid = '#' + this.name.replace("Required", "Enabled");
        if (this.checked) {
            $(inputid).prop("checked", true);
        }
    });

})(jQuery);