var numberOfAsserts;  
numberOfAsserts = 0;

function assert(message, expression){
    if(!expression){
        throw new Error(message)
    }
    numberOfAsserts ++;
}

function output(text, color){
    console.log('%c' + text, 'color: ' + color);
}

/*
function output(text, color) {
    var p = document.createElement("p");
    p.innerHTML = text;
    p.style.color = color;
    document.body.appendChild(p);
}
*/

function testCase(name, tests){
    numberOfAsserts = 0;
    var successfullyTests  = 0;
    var numberOfTests = 0;
    var hasSetUp = typeof tests.setUp == 'function';
    var hasTearDown = typeof tests.tearDown == 'function';

    for(var test in tests){
        if(!/^test/.test(test)){
            continue;
        }
        numberOfTests ++;
        try{
            if (hasSetUp){
                tests.setUp();
            }
            tests[test]();
            output(test, '#0c0');

            if(hasTearDown){
                tests.tearDown();
            }

            successfullyTests++;
        }catch(e){
            output(test + ' failed: ' + e.message, '#c00');
        }
    }

    var color = successfullyTests == numberOfTests? '#0c0' : '#c00';
    output(numberOfTests + ' tests, '  + (numberOfTests - successfullyTests) + ' failures', color);
}