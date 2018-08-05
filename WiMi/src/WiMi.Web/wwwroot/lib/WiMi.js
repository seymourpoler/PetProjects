window.WiMi = window.WiMi || {};

(function (WiMi) {
    function namespace(ns) {
        var names = ns.split(".");
        var lastNameSpace = WiMi || {};

        for (var i = 0, len = names.length; i < len; i++) {
            var name = names[i];
            if (lastNameSpace[name] == undefined)
                lastNameSpace[name] = {};

            lastNameSpace = lastNameSpace[name];
        }
    }
    WiMi.namespace = namespace;
    function spyAllMethodsOf(collaborator) {
        for (var propName in collaborator) {
            if (typeof (collaborator[propName]) == 'function')
                spyOn(collaborator, propName);
        };
    }
    WiMi.spyAllMethodsOf = spyAllMethodsOf;
    WiMi.httpStatusCode = {
        internalServerError: 500,
        badRequest: 400,
        ok : 200
    };
})(WiMi || {})