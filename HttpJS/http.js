function Http(){
    var self = this;

    self.get = function(url, request, successHandler, errorHandler){
        var xmlHttpRequest = new XMLHttpRequest();
        xmlHttpRequest.setRequestHeader("Content-type", "application/json; charset=utf-8");
        xmlHttpRequest.onreadystatechange = function () {
            if (isOk(xmlHttpRequest)) {
                successHandler(response);
                return;
            }
            errorHandler(response);
            return;

            function isOk(response){
                const ready = 4;
                const ok = 200;
                return response.readyState == ready && 
                    response.status == ok;
            }
        }
        xmlHttpRequest.open("GET", url, true);
        xmlHttpRequest.send();
    };

    self.put = function(){
        throw 'not implemented exception';
    };

    self.post = function(){
        throw 'not implemented exception';
    };

    self.delete = function(){
        throw 'not implemented exception';
    };
}