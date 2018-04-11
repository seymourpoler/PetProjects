function benchmark(name, tests, iterations) {
    var iterations = iterations || 1000;
    var view = createView(name);
    runAllBenchmarks(tests, view, iterations);
}

//TODO: create view class with method append/show
function createView(name){
    var heading = document.createElement("h2");
    heading.innerHTML = name;
    document.body.appendChild(heading);

    var ol = document.createElement("ol");
    document.body.appendChild(ol);
    return ol;
}

function runAllBenchmarks(benchmarks, view, iterations){
    for(var benchmark in  benchmarks){
        if(typeof(benchmarks[benchmark]) != 'function'){
            continue;
        }
        runOneBenchmark(benchmarks[benchmark], view, iterations);
    }
}

function runOneBenchmark(test, view, iterations){
    setTimeout(function(){
        var start = new Date().getTime();

        var l = iterations;
        while (l--) {
            test();
        }

        var total = new Date().getTime() - start;

        var li = document.createElement("li");
        li.innerHTML = test.name + ": " + total + " ms (total), "+ (total / iterations) + "ms (avg)";
        view.appendChild(li);
    }, 15);
}


var ol
function runBenchmark(name, test){
    if(!ol){
        ol = document.createElement("ol");
    }
    document.body.appendChild(ol);

    setTimeout(function(){
        var start = new Date().getTime();

        test();

        var total = new Date().getTime() - start;

        var li = document.createElement("li");
        li.innerHTML = name + ": " + total + " ms";
        ol.appendChild(li);
    }, 15);
}