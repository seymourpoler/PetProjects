testCase("Observable", {
    "test should store function" : function(){
        var observable = new Observable();
        function observer(){};

        observable.addObserver(observer);

        assertEquals(observer, observable.observers[0]);
    },
    "test should return true when has observer" : function(){
        var observable = new Observable();
        function observer(){};
        observable.addObserver(observer);

        assertTrue(observable.hasObserver(observer));
    },
    "test should return false when no observers" : function () {
        var observable = new Observable();

        assertFalse(observable.hasObserver(function(){}));
    },
    "test should store functions" : function () {
        var observable = new Observable();
        var observers = [function(){}, function () {}];

        observable.addObserver(observers[0]);
        observable.addObserver(observers[1]);

        assertTrue(observable.hasObserver(observers[0]));
        assertTrue(observable.hasObserver(observers[1]));
    },
});