function Http(){
    var self = this;
    var xmlHttpRequest = new XMLHttpRequest();
    function isOk(response){
        const ready = 4;
        const ok = 200;
        return response.readyState == ready && 
            response.status == ok;
    }

    self.get = function(url, uccessHandler, errorHandler){
        xmlHttpRequest.onreadystatechange = function () {
            if (isOk(xmlHttpRequest)) {
                successHandler(xmlHttpRequest);
                return;
            }
            errorHandler(xmlHttpRequest);
            return;
        }
        xmlHttpRequest.open('GET', url, true);
        xmlHttpRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
        xmlHttpRequest.send();
    };

    self.post = function(url, request, successHandler, errorHandler){
        xmlHttpRequest.onreadystatechange = function () {
            if (isOk(xmlHttpRequest)) {
                successHandler(xmlHttpRequest);
                return;
            }
            errorHandler(xmlHttpRequest);
            return;
        }
        xmlHttpRequest.open('POST', url, true);
        xmlHttpRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
        xmlHttpRequest.send(JSON.stringify(request));
    };

    self.put = function(){
        throw 'not implemented exception';
    };

    self.delete = function(){
        throw 'not implemented exception';
    };
}