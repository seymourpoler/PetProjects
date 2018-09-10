(function (WiMi) {
    function Http() {
        const contentTypeHeader = 'Content-Type';
        const contentTypeJson = 'application/json;charset=UTF-8';

        var self = this;

        self.get = function (url, successHandler, errorHandler) {
            var xmlHttpRequest = buildXmlHttpRequest('GET', url, successHandler, errorHandler);
            xmlHttpRequest.send();
        };

        self.post = function (url, request, successHandler, errorHandler) {
            var xmlHttpRequest = buildXmlHttpRequest('POST', url, successHandler, errorHandler);
            xmlHttpRequest.send(JSON.stringify(request));
        };

        self.put = function (url, request, successHandler, errorHandler) {
            var xmlHttpRequest = buildXmlHttpRequest('PUT', url, successHandler, errorHandler);
            xmlHttpRequest.send(JSON.stringify(request));
        };

        self.delete = function (url, successHandler, errorHandler) {
            var xmlHttpRequest = buildXmlHttpRequest('DELETE', url, successHandler, errorHandler);
            xmlHttpRequest.send();
        };

        function buildXmlHttpRequest(httpVerb, url, successHandler, errorHandler) {
            var xmlHttpRequest = new XMLHttpRequest();
            xmlHttpRequest.onreadystatechange = function () {
                xmlHttpRequestHandler(httpVerb, url, xmlHttpRequest, successHandler, errorHandler);
            }
            xmlHttpRequest.open(httpVerb, url, true);
            xmlHttpRequest.setRequestHeader(contentTypeHeader, contentTypeJson);
            return xmlHttpRequest;
        }

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