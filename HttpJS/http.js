function Http(){
    var self = this;

    self.get = function(request, successHandler, errorHandler){
        var xmlHttpRequest = new XMLHttpRequest();
        xmlHttpRequest.setRequestHeader("Content-type", "application/json; charset=utf-8");
        xmlHttpRequest.onreadystatechange = function ParseResult(response) {
            if (response.readyState == 4 && response.status == 200) {
                successHandler(response);
                return;
            }
            errorHandler(response);
        }
        throw 'not implemented';
    };
}