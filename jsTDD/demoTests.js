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
    
    tearDown: function(){
        console.log('tearDown');
    }
});