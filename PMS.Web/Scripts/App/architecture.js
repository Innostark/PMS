// Global Variable
var ist = {
    datePattern: "DD/MM/YY",
    timePattern: "HH:mm",
    dateTimePattern: "DD/MM/YY HH:mm",
    dateTimeWithSecondsPattern: "DD/MM/YY HH:mm:ss",
    // UTC Date Format
    utcFormat: "YYYY-MM-DDTHH:mm:ss",
    //server exceptions enumeration 
    exceptionType: {
        UserException: 1,
        UnspecifiedException: 2
    },
    //verify if the string is a valid json
    verifyValidJSON: function (str) {
        try {
            JSON.parse(str);
        }
        catch (exception) {
            return false;
        }
        return true;
    },
    // Validate Url
    validateUrl: function (field) {
        var regex = /^(?:(?:https?|ftp):\/\/)(?:\S+(?::\S*)?@)?(?:(?!10(?:\.\d{1,3}){3})(?!127(?:\.\d{1,3}){3})(?!169\.254(?:\.\d{1,3}){2})(?!192\.168(?:\.\d{1,3}){2})(?!172\.(?:1[6-9]|2\d|3[0-1])(?:\.\d{1,3}){2})(?:[1-9]\d?|1\d\d|2[01]\d|22[0-3])(?:\.(?:1?\d{1,2}|2[0-4]\d|25[0-5])){2}(?:\.(?:[1-9]\d?|1\d\d|2[0-4]\d|25[0-4]))|(?:(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)(?:\.(?:[a-z\u00a1-\uffff0-9]+-?)*[a-z\u00a1-\uffff0-9]+)*(?:\.(?:[a-z\u00a1-\uffff]{2,})))(?::\d{2,5})?(?:\/[^\s]*)?$/i;
        return (regex.test(field)) ? true : false;
    }
};

// Busy Indicator
var spinnerVisibleCounter = 0;

// Show Busy Indicator
function showProgress() {
    ++spinnerVisibleCounter;
    if (spinnerVisibleCounter > 0) {
        $("div#spinner").fadeIn("fast");
    }
};

// Hide Busy Indicator
function hideProgress() {
    --spinnerVisibleCounter;
    if (spinnerVisibleCounter <= 0) {
        spinnerVisibleCounter = 0;
        var spinner = $("div#spinner");
        spinner.stop();
        spinner.fadeOut("fast");
    }
};
//show toast on new item created or updated based on url parameter
$(function () {
    
    var messageVm = $("#Message").val();
    if ($("#IsSaved").val()) {
        if (messageVm !== '' && messageVm !== "" && messageVm !== null && messageVm !== undefined) {
            toastr.success(messageVm);
        }
    }
    else if ($("#IsUpdated").val()) {
        if (messageVm !== '' && messageVm !== "" && messageVm !== null && messageVm !== undefined) {
            toastr.success(messageVm);
        }
    }
    else if ($("#IsError").val()) {
        if (messageVm !== '' && messageVm !== "" && messageVm !== null && messageVm !== undefined) {
            toastr.error(messageVm);
        }
    }
    else {

    }

    $("#Message").val('');
});
