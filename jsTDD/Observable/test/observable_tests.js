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
    "test should call all observers" : function () {
        var observable = new Observable();
        var observer1 = function () {
            observer1.called = true;
        };
        var observer2 = function () {
            observer2.called = true;
        };
        observable.addObserver(observer1);
        observable.addObserver(observer2);

        observable.notifyObservers();

        assertTrue(observer1.called);
        assertTrue(observer2.called);
    },
    "test should pass through arguments" : function(){
        var observable = new Observable();
        var actual;
        observable.addObserver(function(){
            actual = arguments;
        });

        observable.notifyObservers("String", 1, 32);

        assertEquals(3, actual.length);
        assertEquals("String", actual[0]);
    },
});