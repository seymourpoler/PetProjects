describe("functional programming", function(){
	describe("map function", function(){
		it("return array with mapped data", function(){
			var data = [1,2,3,4,5];
			var resultExpected = [2,3,4,5,6];
			
			var mappedResult = map(data, function(number){
				return number + 1;
			});

			expect(resultExpected).to.eql(mappedResult);
		});
	});
	describe("reduce function", function(){
		it("return the sum of numbers", function(){
			var data = [1,2,3,4,5];
			var resultExpected = 15;
			var initialValue = 0;
			
			var reducedResult = reduce(data, initialValue, function(acumulativeNumber, eachNumber){
				return acumulativeNumber + eachNumber;
			});

			expect(resultExpected).to.eql(reducedResult);
		});
	});
	describe("filter function", function(){
		it("return an array only with numbers", function(){
			var data = [1,'2',3,'4',5];
			var resultExpected = [1, 3, 5];
	
			var filteredResult = filter(data, function(eachElement){
				if(typeof eachElement === "number"){
					return true;
				}
				return false;
			});

			expect(resultExpected).to.eql(filteredResult);
		});
	});
	describe("combine filter, map & reduce", function(){
		it("return the result of combination of filter, mal and reduce", function(){
			var data = [1,2,3,4,5,6];
			var resultExpected = 15;

			var result = reduce(
								map(
									filter(
										data, functionForFilter
									), 
									functionForMap
								), 
								0, functionForReduce
							);

			expect(resultExpected).to.eql(result);
		});
		function functionForMap(y){
			return y + 1;
		}
		function functionForFilter(x){
			return	x % 2 == 0;
		}
		function functionForReduce(acumulative, z){ 
			return acumulative + z;
		}
	});
	describe("forEach function", function(){
		it("return the concatenation of the array", function(){
			var data = ['he', 'llo ', 'ever','ybody']
			var expectedResult = 'hello everybody';
			var concatenatedResult = '';

			forEach(data, function(text){
				concatenatedResult += text;
			});

			expect(expectedResult).to.eql(concatenatedResult);
		});
	});
	describe("pipe function", function(){
		it("return the concatenation of the functions result", function(){
			var expectedResult = 'HELLO EVERYBODY';
			var data = ['he', 'llo ', 'ever','ybody']

			var functionOne = function(data){
				return map(data, function(text){
					return text.toUpperCase();
				})
			};
			var functionTwo = function(data){
				var initialValue = '';
				return reduce(data, initialValue, function(acumulativeResult, letter){
					return acumulativeResult + letter.toUpperCase();
				});
			};

			var pipedResult = pipe(pipe(data, functionOne), functionTwo);

			expect(expectedResult).to.eql(pipedResult);
		});
	});
	describe("PipeLine object", function(){
		it("make pipe line through different functions", function(){
			var arrayOfData = [1,2,3];
			var expectedResult = 9;
			var handlerOne = function(data){
				return map(data, function(number){
					return number +1;
				});
			}
			var handlerTwo = function(data){
				var result = 0;
				return reduce(data, result, function(result, number){
					return result + number;
				});
			}
			var pipeLine = new PipeLine();

			var pipeLineResult = pipeLine.pipe(handlerOne)
										 .pipe(handlerTwo)
										 .execute(arrayOfData);

			expect(expectedResult).to.eql(pipeLineResult);							
		});
	});
	describe("compose function", function(){});
	describe("curry function", function(){
		var expectedResult = 10;
		var add = function(a, b, c, d){
			return a + b + c + d;
		}
		var curriedFunction = curry(add);

		var result = curriedFunction(1)(2)(3)(4);

		expect(expectedResult).to.eql(result);
	});
});