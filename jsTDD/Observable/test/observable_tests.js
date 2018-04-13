testCase("Observable",{
    "test should store function" : function(){
        var observable = new Observable();
        function observer (){};

        observable.addObserver(observer);

        assertEquals(observer, observable.observers[0]);
    },
});