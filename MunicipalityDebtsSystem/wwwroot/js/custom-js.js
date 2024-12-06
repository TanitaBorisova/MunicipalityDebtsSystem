///Връща TRUE ако даден елемент притежава Attribute с дадено име, в противен случай връща FALSE
$.fn.hasAttr = function (name) {
    try {
        return this.attr(name) !== undefined;
    } catch (e) {
        console.log("Input parameter for .hasAttr(name) not valid");
        return false;
    }
};

//Унищожава DataTable по подаден селектор, ако съществува
function destroyDataTable(selector) {
    try {
        //Ако вече таблицата е инициализирана, ние я унищожаваме
        if ($.fn.DataTable.isDataTable(selector)) {
            $(selector).DataTable().clear().destroy();
            $(selector).html('');
        } else {
            console.log('destroyDataTable(selector) - DataTable not initialized');
        }
    } catch (e) {
        console.log('destroyDataTable(selector) -' + e.message);
        return false;
    }
}

//Презарежда DataTable по подаден селектор, ако съществува
function reloadDataTable(selector) {
    try {
        if ($.fn.DataTable.isDataTable(selector)) {
            $(selector).DataTable().draw();
        } else {
            console.log("reloadDataTable(selector) - DataTable not initialized");
        }
    } catch (e) {
        console.log('reloadDataTable(selector) -' + e.message);
        return false;
    }
}

//връща обект с попълнени данни за обща филтрация от полета на екран
function loadCommonFiltersData(d) {
    d.date = $('#Date').val();
    d.administrationId = $('#AdministrationId').val();
    d.administrationIds = $('#AdministrationIds').val();
    d.analysisGroupIds = $('#AnalysisGroupIds').val();
    d.administrationMainIds = $('#AdministrationMainIds').val();
    d.managerTypeIds = $('#ManagerTypeIds').val();
    d.administrationOrganizationTypeIds = $('#AdministrationOrganizationTypeIds').val();
    d.systemIds = $('#SystemIds').val();
    d.administrationTypeIds = $('#AdministrationTypeIds').val();
    d.groupBy = $('#GroupBy').val();
    d.includeBusinessTripped = $('#IncludeBusinessTripped').is(':checked');
    d.includeExceedingByNZSDA = $('#IncludeExceedingByNZSDA').is(':checked');
    d.positionOccupationId = $('#PositionOccupationId').val();
    d.implementationVariantId = $('#ImplementationVariantId').val();
    d.legalRelationshipTypeIds = $('#LegalRelationshipTypeIds').val();

    return d;
}

//изчиства попълнените данни за обща филтрация от полета на екран
function clearCommonFiltersData() {
    //if (!$('#Date').attr('readonly')) {
    //    $('#Date').parents('.dateonly-calendar').calendar('set date', null);
    //    $('#Date').trigger('change');
    //}
    $('#AdministrationIds').val(null).trigger('change');
    $('#AdministrationIds').dropdown('clear');
    $('#AdministrationMainIds').val(null).trigger('change');
    $('#AdministrationMainIds').dropdown('clear');
    $('#ManagerTypeIds').val(null).trigger('change');
    $('#ManagerTypeIds').dropdown('clear');
    $('#AdministrationOrganizationTypeIds').val(null).trigger('change');
    $('#AdministrationOrganizationTypeIds').dropdown('clear');
    $('#SystemIds').val(null).trigger('change');
    $('#SystemIds').dropdown('clear');
    $('#AdministrationTypeIds').val(null).trigger('change');
    $('#AdministrationTypeIds').dropdown('clear');
    $('#IncludeBusinessTripped').prop('checked', false).trigger('change');
    $('#IncludeExceedingByNZSDA').prop('checked', true).trigger('change');
    $('#PositionOccupationId').val('-1').trigger('change');
    $('#AnalysisGroupIds').val(null).trigger('change');
    $('#AnalysisGroupIds').dropdown('clear');
    $('#LegalRelationshipTypeIds').val(null).trigger('change');
    $('#LegalRelationshipTypeIds').dropdown('clear');

    //Не се зачиства стойността, тъй като служи за предаване на информация през екраните
    //$('#ImplementationVariantId').val(null).trigger('change');

    
}

// Function to darken an RGB color
function darkenColor(rgbColor, percent) {
    // Parse the RGB color string
    var rgba = rgbColor.match(/\d+/g);

    // Darken each RGB component proportionally
    var r = Math.floor(rgba[0] * (100 - percent) / 100);
    var g = Math.floor(rgba[1] * (100 - percent) / 100);
    var b = Math.floor(rgba[2] * (100 - percent) / 100);

    // Construct the new RGB color string
    var newColor = 'rgb(' + r + ', ' + g + ', ' + b + ')';

    // Return the darkened color
    return newColor;
}

// Прави Distinct на масив с обекти по подадено име на Property
function distinctArrayByPropName(arr, propName) {
    var result = [];
    var seen = {};
    var prop;

    for (var i = 0; i < arr.length; i++) {
        prop = arr[i][propName];
        if (!seen[prop]) {
            seen[prop] = true;
            result.push(arr[i]);
        }
    }

    return result;
}

//Зарежда съдържанието на резултата от PartialView в div-елемент
function requestContent(url, data, callback) {
    $.ajax({
        method: 'GET',
        async: false,
        cache: false,
        url: url,
        data: data,
        beforeSend: function (xhr) {
            // Code to run before sending the request
        },
        success: function (response) {
            callback(response);
        },
        error: function (xhr, status, error) {
            console.error(status, error);
        },
        complete: function (xhr, status) {
        }
    });
}

//Зарежда съдържанието на резултата от PartialView в div-елемент
function requestContentPost(url, data, callback) {
    $.ajax({
        method: 'POST',
        async: false,
        cache: false,
        url: url,
        data: data,
        success: function (data) {
            callback(data);
        }
    });
}

//Пълни колекция с данни по подаден URL
function fillDataSet(url, data, dataProps = {}) {
    let result = data;

    $.ajax({
        type: "POST",
        url: url,
        dataType: "json",
        cache: false,
        async: false,
        data: dataProps,
        success: function (response) {
            result = response;
        },
        complete: function () { },
        error: function () { }
    });

    return result;
}

//Прави бутона НЕактивен и показва спинър иконка в него
function showSpinner(button) {
    return new Promise(function (resolve, reject) {
        try {
            let disabled = $(button).is(':disabled') || $(button).attr('disabled');
            if (!disabled) {
                $(button).attr('disabled', 'disabled');
                $(button).addClass('disabled');
                $(button).prepend('<i class="spinner loading icon"></i>');

                setTimeout(function () {
                    if ($(button).attr('disabled')) {
                        resolve('dom changes complete');
                    }
                }, 50);
            }
        } catch (e) {
            console.log(e);
            reject(e);
        }
    });
}

//Прави бутона Активен и скрива спинър иконата в него
function hideSpinner(button) {
    try {
        $(button).removeAttr('disabled');
        $(button).removeClass('disabled');
        $(button).find('i.spinner.loading.icon').remove();
        return false;
    } catch (e) {
        console.log(e);
        return false;
    }
}

$(document).on('change', 'input.input', function () {
    removeErrorClass(this);
});

$(document).on('change', '.dropdown', function () {
    removeErrorClass(this);
});

$(document).on('keyup', 'input.input-number', function () {
    let value = $(this).val();
    value = value.replace(',', '.');
    $(this).val(value);
});

$(document).on('paste', 'input.input-number', function () {
    let value = $(this).val();
    value = value.replace(',', '.');
    $(this).val(value);
});

function removeErrorClass(element) {
    $(element).removeClass('input-validation-error');
}

///Променлива, която показва дали можем да събмитнем форма
//сетва се на False, когато се натисне събмит бутон, и се връща на True, когато се презареди страницата или се сетне ръчно
//Default = true
//връща bool
var canSubmitForm = true;


function submitForm(button) {
    try {
        let form = $(button).parents('form:first');

        if ($(form) !== null && $(form) !== undefined && canSubmitForm) {
            canSubmitForm = false;

            if (!$(form).valid()) {
                canSubmitForm = true;

                $(button).removeAttr('disabled');
                $(button).removeClass('disabled');
                $(button).find('i.spinner.loading.icon').remove();
            } else {
                $(form).find('input[name="send"][value="send"]').remove();
                $(form).find('input[name="save"][value="save"]').remove();
                $(form).find('input[name="finalize"][value="finalize"]').remove();
                $(form).find('input[name="confirm"][value="confirm"]').remove();
                $(form).find('input[name="reject"][value="reject"]').remove();

                let disabled = $(button).is('[disabled]') || $(button).is(':disabled') || $(button).attr('disabled');
                if (!disabled) {
                    $(button).attr('disabled', 'disabled');
                    $(button).addClass('disabled');
                    $(button).prepend('<i class="spinner loading icon"></i>');

                    if ($(button).hasClass('submit-send')) {
                        $(form).append($('<input />').attr('type', 'hidden').attr('name', 'send').attr('value', 'send'));
                    } else if ($(button).hasClass('submit-save')) {
                        $(form).append($('<input />').attr('type', 'hidden').attr('name', 'save').attr('value', 'save'));
                    } else if ($(button).hasClass('submit-finalize')) {
                        $(form).append($('<input />').attr('type', 'hidden').attr('name', 'finalize').attr('value', 'finalize'));
                    } else if ($(button).hasClass('submit-confirm')) {
                        $(form).append($('<input />').attr('type', 'hidden').attr('name', 'confirm').attr('value', 'confirm'));
                    } else if ($(button).hasClass('submit-reject')) {
                        $(form).append($('<input />').attr('type', 'hidden').attr('name', 'reject').attr('value', 'reject'));
                    }

                    $(form).trigger('submit');
                }
            }
        }
        return false;
    } catch (e) {
        console.log(e);
        return false;
    }
}

function hideShowDataTablesColumn(tableSelector, columnIndex, columnVisible = false) {
    if ($.fn.dataTable.isDataTable(tableSelector)) {
        var column = $(tableSelector).DataTable().column(0);
        column.visible(columnVisible);
    }
}

function jsonBgMoney(value) {
    if (isNaN(parseFloat(value))) {
        return '';
    } else {
        return value.toLocaleString('en-US', { useGrouping: false, minimumFractionDigits: 2, maximumFractionDigits: 2 });
    }
}

function addThousandSeparatorFloat(value) {
    if (isNaN(parseFloat(value))) {
        return '';
    } else {
        // Convert number to string and split into integer and decimal parts
        let parts = value.toFixed(2).toString().split(".");

        // Format integer part with space as thousands separator
        let formattedInteger = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, "&nbsp;");

        // Combine integer and decimal parts using '.' as delimiter
        return formattedInteger + "." + parts[1];
    }
}

function addThousandSeparatorInt(value) {
    if (isNaN(parseInt(value))) {
        return '';
    } else {
        // Convert number to string
        let numStr = String(value);

        // Insert space after every three digits from the right
        return numStr.replace(/\B(?=(\d{3})+(?!\d))/g, "&nbsp;");
    }
}

//При клик върху дадения INPUT го фокусираме и избираме, за да отиде курсура там
document.addEventListener('click', function (event) {
    if (event.target.matches('input.input-validation-error')) {
        $(event.target).focus().select();
    }
});

function multiSelectSpecialSelectAllItems(element) {
    showSpinner(element).then(function (result) {
        let dropdown = $(element).parents('.multi-select-special-container:first').find('.multi-select-special');
        if (dropdown != undefined && dropdown !== null) {
            let options = $(dropdown).find('option').toArray().map(
                (obj) => obj.value
            );
            $(dropdown).dropdown('set exactly', options);
            setTimeout(function () {
                hideSpinner(element);
            },50);
        }
    });
}

function multiSelectSpecialClearSelection(element) {
    let dropdown = $(element).parents('.multi-select-special-container:first').find('.multi-select-special');
    if (dropdown != undefined && dropdown !== null) {
        $(dropdown).dropdown('clear');
    }
}

function showErrorMessage(title, text) {
    Swal.fire({
        allowEscapeKey: false,
        allowOutsideClick: false,
        allowEnterKey: false,
        showCancelButton: false,
        confirmButtonText: 'ОК',
        confirmButtonColor: "#BD3324",
        title: title,
        text: text,
        icon: "error"
    });
}

function showSuccessMessage(title, text) {
    Swal.fire({
        allowEscapeKey: false,
        allowOutsideClick: false,
        allowEnterKey: false,
        showCancelButton: false,
        confirmButtonText: 'ОК',
        confirmButtonColor: "#B1DA8A",
        title: title,
        text: text,
        icon: "success"
    });
}

var saveBlob = (function () {
    var a = document.createElement("a");
    document.body.appendChild(a);
    a.style = "display: none";
    return function (blob, fileName) {
        var url = window.URL.createObjectURL(blob);
        a.href = url;
        a.download = fileName;
        a.click();
        window.URL.revokeObjectURL(url);
    };
}());

$(function () {
    if (typeof $('.input-validation-error').first().offset() !== 'undefined') {
        $('html, body').animate({
            scrollTop: $('.input-validation-error').first().offset().top
        }, 1500);
    }
});