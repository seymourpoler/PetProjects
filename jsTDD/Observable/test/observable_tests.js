testCase("Observable", {
    "test should store function" : function(){
        var observable = new Observable();
        function observer(){};

        observable.addObserver('event', observer);

        assertEquals(observer, observable.observers['event'][0]);
    },
    "test should return true when has observer" : function(){
        var observable = new Observable();
        function observer(){};
        observable.addObserver('event', observer);

        assertTrue(observable.hasObserver('event', observer));
    },
    "test should return false when no observers" : function () {
        var observable = new Observable();

        assertFalse(observable.hasObserver('event', function(){}));
    },
    "test should store functions" : function () {
        var observable = new Observable();
        var observers = [function(){}, function () {}];

        observable.addObserver('event', observers[0]);
        observable.addObserver('anotherEvent', observers[1]);

        assertTrue(observable.hasObserver('event', observers[0]));
        assertTrue(observable.hasObserver('anotherEvent', observers[1]));
    },
    "test should call all observers" : function () {
        var observable = new Observable();
        var observer1 = function () {
            observer1.called = true;
        };
        var observer2 = function () {
            observer2.called = true;
        };
        observable.addObserver('event',observer1);
        observable.addObserver('anotherEvent', observer2);

        observable.notifyObservers('event');

        assertTrue(observer1.called);
        assertFalse(observer2.called);
    },
    "test should pass through arguments" : function(){
        var observable = new Observable();
        var actual;
        observable.addObserver('event', function(){
            actual = arguments;
        });

        observable.notifyObservers('event', "String", 1, 32);

        assertEquals(3, actual.length);
        assertEquals("String", actual[0]);
    },
    "test should throw for uncallable observer" : function(){
        var observable = new Observable();

        assertException(function () {
            observable.addObserver('event', {});
        }, "TypeError");
    },
    "test should notify all even when some fail" : function(){
        var observable = new Observable();
        function observer1(){throw new Error('Oops');}
        var observer2 = function () { observer2.called = true; };
        observable.addObserver('event', observer1);
        observable.addObserver('anotherEvent', observer2);

        observable.notifyObservers('anotherEvent');

        assertTrue(observer2.called);
    },
    "test should call observers in the order they were added" : function () {
        var observable = new Observable();
        var calls = [];
        var observer1 = function () { calls.push(observer1); };
        var observer2 = function () { calls.push(observer2); };
        observable.addObserver('event', observer1);
        observable.addObserver('anotherEvent', observer2);

        observable.notifyObservers('event');

        assertEquals(observer1, calls[0]);
        //assertNotEquals(observer2, calls[1]);
    },
});