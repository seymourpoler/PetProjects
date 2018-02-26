function Http(){
    var self = this;

    self.get = function(url, request, successHandler, errorHandler){
        var xmlHttpRequest = new XMLHttpRequest();
        xmlHttpRequest.setRequestHeader("Content-type", "application/json; charset=utf-8");
        xmlHttpRequest.onreadystatechange = function ParseResult(response) {
            if (isOk(response)) {
                successHandler(response);
                return;
            }
            errorHandler(response);
            return;

            function isOk(response){
                return response.readyState == 4 && 
                    response.status == 200;
            }
        }
        throw 'not implemented';
    };
}