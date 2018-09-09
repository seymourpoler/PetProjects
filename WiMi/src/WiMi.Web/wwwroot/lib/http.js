(function (WiMi) {
    function Http() {
        const contentTypeHeader = 'Content-Type';
        const contentTypeJson = 'application/json;charset=UTF-8';

        var self = this;
        var xmlHttpRequest = new XMLHttpRequest();

        self.get = function (url, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                xmlHttpRequestHandler('GET', url ,xmlHttpRequest, successHandler, errorHandler);
            }
            xmlHttpRequest.open('GET', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send();
        };

        self.post = function (url, request, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                xmlHttpRequestHandler('POST', url, xmlHttpRequest, successHandler, errorHandler);
            }
            xmlHttpRequest.open('POST', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send(JSON.stringify(request));
        };

        self.put = function (url, request, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                xmlHttpRequestHandler('PUT', url, xmlHttpRequest, successHandler, errorHandler);
            }
            xmlHttpRequest.open('PUT', url);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send(JSON.stringify(request));
        };

        self.delete = function (url, successHandler, errorHandler) {
            xmlHttpRequest.onreadystatechange = function () {
                xmlHttpRequestHandler('DELETE', url, xmlHttpRequest, successHandler, errorHandler);
            }
            xmlHttpRequest.open('DELETE', url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            xmlHttpRequest.send();
        };

        function xmlHttpRequestHandler(httpVerb, url, xmlHttpRequest, successHandler, errorHandler) {
            if (isOk(xmlHttpRequest)) {
                handleResponse(xmlHttpRequest.response, successHandler);
                return;
            }
            if (isAnError(xmlHttpRequest)) {
                handleResponse(xmlHttpRequest.response, errorHandler);
                return;
            }
            console.log('http ' + httpVerb + ': ' + url + ' with unkown response: ', xmlHttpRequest);

            function handleResponse(response, handler) {
                if (response === '') {
                    handler(response);
                    return;
                }
                const responseParsed = JSON.parse(response);
                handler(responseParsed);
            }
        }

        function isOk(response) {
            const ready = 4;
            const ok = 200;
            return response.readyState == ready &&
                response.status == ok;
        }

        function isAnError(response) {
            const internalServerErrorTypeNumber = 5;
            const requestErrorTypeNumber = 4;
            var divisionResult = response.status / 100;
            return divisionResult == internalServerErrorTypeNumber ||
                divisionResult == requestErrorTypeNumber;
        }
    }
    WiMi.Http = Http;

})(WiMi || {})