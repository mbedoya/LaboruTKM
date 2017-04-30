function ajaxPost(controller, method, data, fx) {

    $.ajax({
        url: "/" + siteUrlPrefix + controller + "/" + method,
        dataType: "json",
        type: "POST",
        data: data,
        success: function (data) {
            fx(true, data);
        },
        error: function (a, b, c) {
            fx(false, a);
        }
    }).done(function () {
        //hideLoading();
    });
}

function ajaxGet(controller, method, data, fx) {

    $.ajax({
        url: "/" + siteUrlPrefix + controller + "/" + method,
        dataType: "json",
        type: "GET",
        data: data,
        success: function (data) {
            fx(true, data);
        },
        error: function (a, b, c) {
            fx(false, a);
        }
    }).done(function () {
        //hideLoading();
    });
}

function getDateDiff(date) {

    var date = moment(date);
    var now = moment();

    var months = now.diff(date, 'months');

    if (months == 0) {

        var days = now.diff(date, 'days');

        console.log(days);

        if (days == 0) {

            var hours = now.diff(date, 'hours');

            if (hours == 0) {

                var minutes = now.diff(date, 'minutes');

                if (minutes == 0) {

                    return "recién";

                } else {
                    return "hace " + minutes + " minutos";
                }

            } else {
                return "hace " + hours + " horas";
            }


        } else {

            if (days < 15) {
                return 'hace ' + days + ' días';
            } else {
                return date.locale(getLanguage()).format('MMM DD YYYY');
            }
        }

    } else {
        return date.locale(getLanguage()).format('MMM DD YYYY');
    }


}

function showLoading() {
    $("#waiting").css('display', 'block');
}

function hideLoading() {
    $("#waiting").css('display', 'none');
}

function getLanguage() {
    var language = '@UIHelpers.GetBrowserUICulture()';
    return language;
}

function getGlobalizedText(name) {
    var language = '@UIHelpers.GetBrowserUICulture()';
    return lang[language][name];
}