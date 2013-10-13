function getCurrentPageName() {
    var path = window.location.pathname;
    return path.substring(path.lastIndexOf('/') + 1);
}

function ajax(params, callBack) {
    var pageName = getCurrentPageName();
    params.nocache = new Date().getTime();

    $.getJSON(pageName, params, function (data) {
        callBack(data);
    });
}