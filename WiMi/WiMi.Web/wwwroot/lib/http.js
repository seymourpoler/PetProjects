window.Http = window.Http|| {};
(function (WiMi) {
    function Http() {
        const contentTypeHeader = 'Content-type';
        const contentTypeJson = 'application/json; charset=utf-8';

        var self = this;
        var xmlHttpRequest = new XMLHttpRequest();

        self.get = function (url, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                if (isOk(xmlHttpRequest)) {
                    successHandler(xmlHttpRequest);
                    return;
                }
                errorHandler(xmlHttpRequest);
                return;
            }
            xmlHttpRequest.open('GET', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send();
        };

        self.post = function (url, request, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                if (isOk(xmlHttpRequest)) {
                    successHandler(xmlHttpRequest);
                    return;
                }
                errorHandler(xmlHttpRequest);
                return;
            }
            xmlHttpRequest.open('POST', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send(JSON.stringify(request));
        };

        self.put = function (url, request, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                if (isOk(xmlHttpRequest)) {
                    successHandler(xmlHttpRequest);
                    return;
                }
                errorHandler(xmlHttpRequest);
                return;
            }
            xmlHttpRequest.open('PUT', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send(JSON.stringify(request));
        };

        self.delete = function (url, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                if (isOk(xmlHttpRequest)) {
                    successHandler(xmlHttpRequest);
                    return;
                }
                errorHandler(xmlHttpRequest);
                return;
            }
            xmlHttpRequest.open('DELETE', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send();
        };

        function isOk(response) {
            const ready = 4;
            const ok = 200;
            return response.readyState == ready &&
                response.status == ok;
        }
    }
    Http = Http;
})(Http || {})