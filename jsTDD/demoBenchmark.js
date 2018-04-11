var loopLength = 500000;
var array = [];
for (var i = 0; i < loopLength; i++) {
    array[i] = "item" + i;
}


function forLoop(){
    for (var i = 0, item; i < array.length; i++) {
        item = array[i];
    }
}

function forLoopCachedLength() {
    for (var i = 0, l = array.length, item; i < l; i++) {
        item = array[i];
    }

}

/*
runBenchmark("forLoop", forLoop);
runBenchmark("forLoopCachedLength", forLoopCachedLength);
*/
benchmark("Benchmark",{
    "forLoop": function(){
        for (var i = 0, item; i < array.length; i++) {
            item = array[i];
        }
    },
    "forLoopCachedLength": function(){
        for (var i = 0, l = array.length, item; i < l; i++) {
            item = array[i];
        }
    }
}, 1000);