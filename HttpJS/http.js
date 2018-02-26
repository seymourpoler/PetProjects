function Http(){
    var self = this;

    self.get = function(request, successHandler, errorHandler){
        var xmlHttpRequest = new XMLHttpRequest();
        xmlHttpRequest.setRequestHeader("Content-type", "application/json; charset=utf-8");
        throw 'not implemented';
    };
}