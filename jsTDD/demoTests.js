testCase("demo tests", {
    setUp: function(){
        console.log('setup');
    },

    "test --> with false assertion": function(){
        assert("is false", true == false);
    },
    "test --> with true assertion": function(){
        assert("is true", true == true);
    },
    "test --> assert equals": function(){
        assertEquals(2,3);
    },

    tearDown: function(){
        console.log('tearDown');
    }
});

testCase("namespace", {
    "test when namespace is requested" : function(){
        var tddjs = new Tddjs();

        var namespace = tddjs.namespace("tdd.js.tests");

        assertObject(namespace);
        assertObject(namespace.tdd);
        assertObject(namespace.tdd.js);
        assertObject(namespace.tdd.js.tests);
    }
});

testCase("uid",{
    "test returns the same uid with the same parameter" : function(){
        var tddjs = new Tddjs();
        var object = {};
        
        var uid = tddjs.uid(object);

        assertEquals(uid, tddjs.uid(object));
    },
});