var assert;  
assert.count = 0;

function assert(message, expression){
    if(!expression){
        throw new Error(message)
    }
    assert.count ++;
    return true;
}

function output(text, color){
    console.log('%c' + text, 'color: ' + color);
}

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
                tests.setUp();
            }
            tests[test]();
            output(test, '#0c0');

            if(hasTearDown){
                tests.tearDown();
            }

            successful++;
        }catch(e){
            output(test + ' failed: ' + e.message, '#c00');
        }
    }

    var color = successful == testCount? '#0c0' : '#c00';
    output(testCount + ' tests, '  + (testCount - successful) + ' failures', color);
}