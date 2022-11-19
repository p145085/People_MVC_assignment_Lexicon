// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getLastPerson(actionUrl) {
    $.get(actionUrl, function (response) {
        console.log("Response: ", response);
        document.getElementById("result").innerHTML = response;
    });
}

function postWithAjax(actionUrl, idInput) {
    let inputElement = $("#" + idInput)
    let data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputElement: ", inputElement);
    console.log("data: ", data);

    $.post(actionUrl, data, function (response) {
        console.log("response: ", response);
        document.getElementById("result").innerHTML = response;
    });
}

function postWithAjaxDelete(actionUrl, idInput) { // Identical to 'postWithAjax'.
    let inputElement = $("#" + idInput)
    let data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputElement: ", inputElement);
    console.log("data: ", data);

    $.post(actionUrl, data, function (response) {
        console.log("response: ", response);
        document.getElementById("result").innerHTML = response;
    });
}