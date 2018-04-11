function benchmark(name, tests, iterations) {
    var iterations = iterations || 1000;
    var view = new View(name);
    runAllBenchmarks(tests, view, iterations);
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

        var benchmark = {name: test.name, total: total, iterations: iterations};
        view.show(benchmark);

    }, 15);
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