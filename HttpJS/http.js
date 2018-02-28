function Http(){
    var self = this;

    self.get = function(url, uccessHandler, errorHandler){
        var xmlHttpRequest = new XMLHttpRequest();
        xmlHttpRequest.onreadystatechange = function () {
            if (isOk(xmlHttpRequest)) {
                successHandler(xmlHttpRequest);
                return;
            }
            errorHandler(xmlHttpRequest);
            return;

            function isOk(response){
                const ready = 4;
                const ok = 200;
                return response.readyState == ready && 
                    response.status == ok;
            }
        }
        xmlHttpRequest.open('GET', url, true);
        xmlHttpRequest.setRequestHeader('Content-type', 'application/json; charset=utf-8');
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