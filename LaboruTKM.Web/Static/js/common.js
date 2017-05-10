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

function parseJsonDate(jsonDateString) {
    return new Date(parseInt(jsonDateString.replace('/Date(', '')));
}

function getObjectByNestedProperties(obj, property) {

    var propertyArray = property.split('.');
    for (var i = 0; i < propertyArray.length; i++) {
        if (obj) {
            obj = obj[propertyArray[i]];
        } else {
            return "N/D";
        }
    }

    return obj;
}

function getValueFromState(state) {
    if (state == 1) {
        return 'Creado como candidato ' +
                '<div class="progress">' +
                 '<div class="progress-bar progress-bar-danger" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100" style="width: 10%">10%</div>' +
                '</div>';
    }
}

function getRowElement(obj, properties, key, url) {

    var date = moment(obj.DateCreated);
    var now = moment();

    var rowTemplate = '<tr>';
    for (var i = 0; i < properties.length; i++) {
        var property = properties[i];
        if (i == 0) {
            rowTemplate += '<td><a href="' + url + '/' + getObjectByNestedProperties(obj, key) + '">' + getObjectByNestedProperties(obj, property) + '</a></td>';
        } else {
            console.log(property);
            if (property.toLowerCase().indexOf('date', 0) > -1) {
                var date = moment(parseJsonDate(getObjectByNestedProperties(obj, property)));
                rowTemplate += '<td>' + getDateDiff(date) + '</td>';
            } else {

                var value = getObjectByNestedProperties(obj, property);
                if (property.toLowerCase().indexOf('state', 0) > -1) {
                    rowTemplate += '<td>' + getValueFromState(value) + '</td>';
                } else {
                    rowTemplate += '<td>' + getObjectByNestedProperties(obj, property) + '</td>';
                }
            }
        }
    }
    rowTemplate += '</tr>';

    return rowTemplate;
}

function getAndsetTableData(controllerName, method, parameters, url, properties, key, tableID) {

    showLoading();
    ajaxGet(controllerName, method, parameters, function (success, data) {

        hideLoading();
        if (success) {

            console.log(data);

            if (data && data.length > 0) {

                for (var i = 0; i < data.length; i++) {

                    var obj = data[i];
                    var htmlElement = getRowElement(obj, properties, key, url);

                    $("#" + tableID + " tbody").append(htmlElement);
                }


                if (lang[getLanguage().toString()] != null) {
                    $("#" + tableID).DataTable({
                        "language": lang[getLanguage().toString()].datatables
                    });
                } else {
                    $("#" + tableID).DataTable();
                }

            } else {
                console.log("no elements in table");
            }

        } else {

            console.log("error");
            console.log(data);
        }

    });
}

function getSelectElement(obj, property, key) {

    var rowTemplate = '<option value="' + obj[key] + '">' + obj[property] + '</option>';
    return rowTemplate;
}

function getAndsetDropdownData(controllerName, method, parameters, property, key, selectID) {

    ajaxGet(controllerName, method, parameters, function (success, data) {

        if (success) {

            console.log(data);

            if (data && data.length > 0) {

                for (var i = 0; i < data.length; i++) {

                    var obj = data[i];
                    var htmlElement = getSelectElement(obj, property, key);

                    console.log(htmlElement);

                    $("#" + selectID).append(htmlElement);
                }

            } else {
                console.log("no elements in table");
            }

        } else {

            console.log("error");
            console.log(data);
        }

    });
}