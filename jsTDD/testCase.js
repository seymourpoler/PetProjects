function testCase(name, tests){
    assert.count = 0;
    var successful  = 0;
    var testCount = 0;
    var hasSetUp = typeof tests.setUp == 'function';
    var hasTearDown = typeof tests.tearDown == 'function';

    for(var test in tests){
        if(!/^test/.test(test)){
            continue;
        }
        testCount ++;
        try{
            if (hasSetUp){
                test.setUp();
            }
            tests[test]();
            output(tests, '#0c0');

            if(hasTearDown){
                test.tearDown();
            }

            successful++;
        }catch(e){
            output(test + ' failed: ' + e.message, '#c00');
        }
    }
}