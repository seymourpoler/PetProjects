var numberOfAsserts = 0;  

function assert(message, expression){
    if(!expression){
        throw new Error(message);
    }
    numberOfAsserts ++;
}

function assertEquals(expected, got){
    if(expected != got){
        throw new Error('expected: ' + expected + ', but got: ' + got);
    }
    numberOfAsserts ++;
}

function assertObject(value){
    if(value != undefined && typeof(value) === Object(value)){
        throw new Error(value + ' is not an object');
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
    var testHasSetUp = typeof tests.setUp == 'function';
    var testHasTearDown = typeof tests.tearDown == 'function';

    for(var test in tests){
        if(!/^test/.test(test)){
            continue;
        }
        numberOfTests ++;
        try{
            if (testHasSetUp){
                tests.setUp();
            }
            tests[test]();
            output(test, '#0c0');

            if(testHasTearDown){
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


function Tddjs(){
    var self = this;
    var id = 0;

    self.namespace = function(namespace){
        var values = namespace.split(".");
        return buildNamespace(values);
    
        function buildNamespace(values){
            if (values.length == 0 || values == undefined){
                return {};
            }
            
            var head = values[0];
            var result = {};
            values.shift()
            result[head] = buildNamespace(values);
            return result;
        }
    };

    self.uid = function(object){
        if(typeof(object.__uid) == 'Number'){
            object.__uid = id;
            id++;
        }
        return object.__uid;
    };
}
