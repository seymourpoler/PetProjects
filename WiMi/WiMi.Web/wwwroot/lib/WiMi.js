window.WiMi = window.WiMi || {};
(function (WiMi) {
    function namespace (namespace) {
        var values = namespace.split(".");
        return buildNamespace(values);

        function buildNamespace(values) {
            if (values.length == 0 || values == undefined) {
                return {};
            }

            var head = values[0];
            var result = {};
            values.shift()
            result[head] = buildNamespace(values);
            return result;
        }
    };
    WiMi.namespace = namespace;
    function spyAllMethodsOf(collaborator) {
        for (var propName in collaborator) {
            if (typeof (collaborator[propName]) == 'function')
                spyOn(collaborator, propName);
        };
    }
    WiMi.spyAllMethodsOf = spyAllMethodsOf;
})(WiMi || {})