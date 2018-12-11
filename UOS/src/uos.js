var UOS = UOS || {};
UOS.version = '0.0.1';

(function (UOS) {

    function namespace(ns) {
        var names = ns.split(".");
        var lastNameSpace = UOS || {};

        for (var i = 0, len = names.length; i < len; i++) {
            var name = names[i];
            if (lastNameSpace[name] === undefined)
                lastNameSpace[name] = {};

            lastNameSpace = lastNameSpace[name];
        }
    }
    UOS.namespace = namespace;

})(UOS);