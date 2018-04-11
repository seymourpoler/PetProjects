function benchmark(name, tests, iterations) {
    var iterations = iterations || 1000;
    var view = new View(name);
    runAllBenchmarks(tests, view, iterations);
}

function runAllBenchmarks(benchmarks, view, iterations){
    for(var benchmark in  benchmarks){
        runOneBenchmark(benchmarks[benchmark], view, iterations);
    }
}

function runOneBenchmark(test, view, iterations){
    if(isNotValid(test)){
        return;
    }    
    var total = executeBenchmark(test, iterations)
    var benchmark = {name: test.name, total: total, iterations: iterations};
    view.show(benchmark);
    return;

    function isNotValid(benchmark){
        return typeof(benchmark) != 'function';
    }

    function executeBenchmark(test, iterations){
        var start = new Date().getTime();

        var l = iterations;
        while (l--) {
            test();
        }

        return new Date().getTime() - start;
    }
}

function View(name){
    var self = this;
    self.name = name;

    var heading = document.createElement("h2");
    heading.innerHTML = name;
    document.body.appendChild(heading);

    var ol = document.createElement("ol");
    document.body.appendChild(ol);

    self.show = function(benchmark){
        var li = document.createElement("li");
        li.innerHTML = benchmark.name + ": " + benchmark.total + " ms (total), "+ (benchmark.total / benchmark.iterations) + "ms (avg)";
        ol.appendChild(li);
    };
}