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
    setUp: function(){
        this.tddjs = new Tddjs();
    },
    "test when namespace is requested" : function(){
        var namespace = this.tddjs.namespace("tdd.js.tests");

        assertObject(namespace);
        assertObject(namespace.tdd);
        assertObject(namespace.tdd.js);
        assertObject(namespace.tdd.js.tests);
    }
});

testCase("uid",{
    setUp : function() {
        this.tddjs = new Tddjs();
    },
    "test returns the same uid with the same parameter" : function(){
        var object = {};

        var uid = this.tddjs.uid(object);

        assertEquals(uid, tddjs.uid(object));
    },
    "test returns diferent uid form diferent objects":function(){
        var aObject = {};
        var anotherObject = 12;

        assertNotEquals(this.tddjs.uid(anotherObject), this.tddjs.uid(aObject));
    } 
});