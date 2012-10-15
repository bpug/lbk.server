$(document).ready(function () {
    if (!$.validator) return;

        var data = $("meta[name='accept-language']").attr("content");
        Globalize.culture(data);
       

        $.validator.methods.number = function (value, element) {
            if (Globalize.parseFloat(value)) {
                return true;
            }
            return false;
        };

        $.validator.methods.date = function (value, element) {
            if (Globalize.parseDate(value)) {
                return true;
            }
            return false;
        };

        //Fix the range to use globalized methods
        jQuery.extend(jQuery.validator.methods, {
            range: function (value, element, param) {
                //Use the Globalization plugin to parse the value
                var val = Globalize.parseFloat(value);
                return this.optional(element) || (val >= param[0] && val <= param[1]);
            }
        });

        //Setup datepickers if we don't support it natively!
        if (!Modernizr.inputtypes.date) {
            if (data != 'en-US' && data != 'en') {
                var datepickerScriptFile = "/cms/Scripts/globdatepicker/jquery.ui.datepicker." + data + ".js";
                //Now, load the date picker support for this language
                // and set the defaults for a localized calendar
                $.getScript(datepickerScriptFile, function () {
                    $.datepicker.setDefaults($.datepicker.regional[data]);
                });
            }
            $(".date").datepicker();
        }
   
//    //Ask ASP.NET what culture we prefer
//    $.getJSON('/locale/currentculture', function (data) {
//        //Tell jQuery to figure it out also on the client side.
//        Globalize.culture(data);
//    });

});