describe("list in javascript using TDD", function(){
	describe(".count()", function(){
		it("Given empty list when call Count method then returns zero ", function(){
			var numbers = new List();
			expect(numbers.count()).to.eql(0);
		});
		it("Given list when call Count method then returns the number of elements ", function(){
			var numbers = new List([1,2,3,4]);
			expect(numbers.count()).to.eql(4);	
		});
	});
	describe(".sum()", function(){
		it("Given list when call Sum method then returns Zero ", function(){
			var numbers = new List();
			expect(numbers.sum()).to.eql(0);
		});
		it("Given list with numbers when call Sum method then returns the sumary", function(){
			var numbers = new List([1,2,3,4]);
			expect(numbers.sum()).to.eql(10);
		});
		it("Given list with strings when call Sum method then returns only the sum of the numbers ", function(){
			var numbers = new List([1,'w', {a:1, b:3}, 5, 'rdf']);
			expect(numbers.sum()).to.eql(6);
		});
		it("Given list with obejcts when call Sum method then returns only the sum of the filtered elements", function(){
			var numbers = new List([{a:1, b:3},{a:6, b:3}]);
			expect(numbers.sum(function(x){
									return x.a;
								})).to.eql(7);
		});
	});
	describe(".take(<number>)", function(){
	    it("Given list when call Take method then returns new empty List ", function(){
	      var numbers = new List();
	      var result = numbers.take(3);
	      expect(result.count()).to.eql(0);
	    });
	    it("Given list  with numbers when call Sum method then returns the sumatory", function(){
	      var numbers = new List([5,3,7,9]);
	      var result = numbers.take(2);
	      expect(result.isEqual(new List([5,3]))).to.be(true);
	    });
  	});
  	describe(".add()", function(){
  		it("Given empty List, add new element, return a list with this element", function(){
  			var listOfNumbers = new List();
  			listOfNumbers.add(1);
  			expect(listOfNumbers.isEqual(new List([1]))).to.be(true);
  		});
  		it("Given empty List, add new element, return a list with fluent api", function(){
  			var result = new List([3,4,5,6])
			  						.add(1)
			  						.add(7);
  			expect(result.isEqual(new List([3,4,5,6,1,7]))).to.be(true);
  		});
  	});
	describe(".addAt(position, element)", function(){
		it("Given an empty array, when position is under the limit, returns a list with this element", function(){
			var list = new List([]);

			var result = list.addAt(-1, 3);

  			expect(result.isEqual(new List([3]))).to.be(true);
		});
		it("Given an array with numbers, when position is under the limit, returns a list with this element", function(){
			var list = new List([4,5]);

			var result = list.addAt(-1, 3);

  			expect(result.isEqual(new List([3,4,5]))).to.be(true);
		});
		it("Given an enmpty array , when the position is over the limit, returns a list with this element", function(){
			var list = new List([]);

			var result = list.addAt(5, 3);

  			expect(result.isEqual(new List([3]))).to.be(true);
		});
		it("Given an array with numbers, when the position is over the limit, returns a list with this element", function(){
			var list = new List([4,5,6,7]);

			var result = list.addAt(9, 3);

  			expect(result.isEqual(new List([4,5,6,7,3]))).to.be(true);
		});
		it("Given an array with numbers, add an element in a position, returns a list with this element", function(){
			var list = new List([4,5,6,7]);

			var result = list.addAt(0, 3);

  			expect(result.isEqual(new List([3,4,5,6,7]))).to.be(true);
		});
	});
  	describe(".where(<condition>)", function(){
		it("Given list  with numbers when call where with a condition method then returns a new list with applied the condition", function(){
		  var numbers = new List([5,3,7,9]);
		  var result = numbers.where(function(x){ return x > 5;});
		  expect(result.isEqual(new List([7,9]))).to.be(true);
	    });
		it("Given list  with numbers when call where with a condition method then returns a new list with applied the condition", function(){
		  var numbers = new List([5,3,7,9]);
		  var result = numbers.where(function(x){ return x > 458});
		  expect(result.isEqual(new List())).to.be(true);
	    });
	    it("Given list  with numbers when call apply condition  with fluent api", function(){
		  var result = new List([1,2,4,3,5,3,7,9])
		  						.where(function(x){ return x > 1})
		  						.where(function(x){ return x < 5});
		  expect(result.isEqual(new List([2,4,3,3]))).to.be(true);
	    });
  	});
  	describe(".union(<list>)", function(){
  		it("Given an empty list when call union method then returns an empty list", function(){
		  var numbers = new List();
		  var result = numbers.union(new List());
		  expect(result.isEqual(new List())).to.be(true);
	    });
		it("Given a list with numbers when call union method then returns a new list with the union of the elements", function(){
		  var numbers = new List([5,3,7,9]);
		  var result = numbers.union(new List([1,2,3]));
		  expect(result.isEqual(new List([5,3,7,9, 1,2,3]))).to.be(true);
	    });
	    it("Given a list with numbers when call union method then returns a new list with fluent api", function(){
		  var numbers = new List([5,3,7,9]);
		  var result = numbers
		  					.union(new List([1,2,3]))
		  					.union(new List([4,5,6,7]));
		  expect(result.isEqual(new List([5,3,7,9, 1,2,3,4,5,6,7]))).to.be(true);
	    });
	});
	describe(".reverse(<list>)", function(){
		it("Given list  with numbers when call reverse method then returns a new list with the reverse of the elements", function(){
		  var result = new List([5,3,7,9]).reverse();
		  expect(result.isEqual(new List([9,7,3,5]))).to.be(true);
	    });
		it("Given an empty list when call reverse method then returns an empty list", function(){
		  var numbers = new List();
		  var result = numbers.reverse();
		  expect(result.isEqual(new List())).to.be(true);
	    });
	});
	describe(".select(<function>)", function(){
	  it("Given a list  with numbers when call select method then returns a new list with the of the method applied to each element", function(){
		    var numbers = new List([5,3,7,9]);
		    var result = numbers.select(function(x){return x+1;})
		    expect(result.isEqual(new List([6,4,8,10]))).to.be(true);
		});
	});
	describe(".remove(<condition>)", function(){
		it("Given a list  with numbers when call remove method then returns a new list without the element ot be in the condition", function(){
		    var numbers = new List([5,3,7,9]);
		    var result = numbers.remove(function(x){return x > 5;});
		    expect(result.isEqual(new List([7,9]))).to.be(true);
		});
		it("Given a list  with numbers when call remove method with fluent api", function(){
		    var result = new List([1,2,3,4,5,3,7,9])
					    		.remove(function(x){return x > 2;})
					    		.remove(function(x){return x < 9;});
		    expect(result.isEqual(new List([3,4,5,3,7]))).to.be(true);
		});
	});
	describe(".removeAt(position)", function(){
		it("Given an empty list, returns the same list", function(){
			var list = new List([]);

			var result = list.removeAt(1);

			expect(result.isEqual(new List([]))).to.be(true);
		});
		it("Given a list, when removes at outside position ,returns the same list", function(){
			var list = new List([1,2]);
			
			var result = list.removeAt(2);

			expect(result.isEqual(new List([1,2]))).to.be(true);
		});
		it("Given a list, remove at position, returns the same list without the element in the position", function(){
			var list = new List([1,2,4,5,6,7]);

			var result = list.removeAt(2);

			expect(result.isEqual(new List([1,2,5,6,7]))).to.be(true);
		});
	});
	describe(".clear()", function(){
	  	it("Given list  with numbers when call clear method then returns a new empty list", function(){
		    var numbers = new List([5,3,7,9]);
		    var result = numbers.clear();
		    expect(numbers.isEqual(new List())).to.be(true);
		});
	});
	describe(".elementAt(<position>)", function(){
		it("Given an list with elements when call elementAt(<positiion>) method then returns the element at the position", function(){
			var list = new List(['dog', 'orange']);
			expect(list.elementAt(1)).to.eql('orange');
		});
		it("Given empty list when call isEmpty method then returns true", function(){
			expect(new List([]).elementAt(3)).to.eql(undefined);
		});
	});
	describe(".isEmpty()", function(){
		it("Given empty list when call isEmpty method then returns true", function(){
			expect(new List([]).isEmpty()).to.eql(true);
		});
		it("Given an list with elements when call isEmpty method then returns false", function(){
			expect(new List(['dog', 'orange']).isEmpty()).to.eql(false);
		});
	});
	describe(".first(<condition>)", function(){
		it("return the first element", function(){
			var numbers = new List(['One', 'Two', 'Three']);
			expect(numbers.first()).to.eql('One');
		});
		it("Given list with numbers when call first method then returns the first element that applied the condition", function(){
			var numbers = new List([{number:5, letra:'e'},{number:3, letra:'q'},{number:1, letra:'a'},{number:9, letra:'w'},{number:4, letra:'r'},{number:7, letra:'t'}]);
			expect(numbers.first(function(x){return x.number < 4; }))
				  .to.eql({number:3, letra:'q'});
		});
		it("Given list with numbers when call first method then returns the first element that applied the condition", function(){
			var numbers = new List([{number:5, letra:'e'},{number:3, letra:'q'},{number:1, letra:'a'},{number:9, letra:'w'},{number:4, letra:'r'},{number:7, letra:'t'}]);
			expect(numbers.first(function(x){return x.letra == '?';}))
			.to.eql(undefined);
		});
	});
	describe(".last(<condition>)", function(){
		it("Given list with numbers when call last method then returns the last element", function(){
			var numbers = new List([{number:5, letra:'e'},{number:3, letra:'q'},{number:1, letra:'a'},{number:9, letra:'w'},{number:4, letra:'r'},{number:7, letra:'t'}]);
			expect(numbers.last()).to.eql({number:7, letra:'t'});
		});
		it("Given an empty list then returns undefined", function(){
			var numbers = new List([]);
			expect(numbers.last()).to.eql(undefined);
		});
		it("Given list with numbers when call last method then returns the last element that applied the condition", function(){
			var numbers = new List([{number:5, letra:'e'},{number:3, letra:'q'},{number:1, letra:'a'},{number:9, letra:'w'},{number:4, letra:'r'},{number:7, letra:'t'}]);
			expect(numbers.last(function(x){return x.number < 6; }))
				  .to.eql({number:4, letra:'r'});
		});
		it("Given list with numbers when call last method then returns the last element that applied the condition", function(){
			var numbers = new List([{number:5, letra:'e'},{number:3, letra:'q'},{number:1, letra:'a'},{number:9, letra:'w'},{number:4, letra:'r'},{number:7, letra:'t'}]);
			expect(numbers.last(function(x){return x.letra == '?';}))
			.to.eql(undefined);
		});
	});
	describe(".orderAscending()", function(){
		it("Given list with numbers when call orderAscending method then returns a list ordered ascending", function(){
			var numbers = new List([5,3,1,9,4,7]);
			expect(numbers.orderAscending().isEqual(new List([1,3,4,5,7,9]))).to.be(true);
		});
	});
	describe(".orderDescending()", function(){
		it("Given list with numbers when call orderDescending method then returns a list ordered descending", function(){
			var numbers = new List([5,3,1,9,4,7]);
			expect(numbers.orderDescending().isEqual(new List([9,7,5,4,3,1]))).to.be(true);
		});
	});
	describe(".orderBy(<func>)", function(){
		it("Given list with numbers when call orderAscending method then returns an list ordered", function(){
			var numbers = new List([{number:5, letra:'e'},{number:3, letra:'q'},{number:1, letra:'a'},{number:9, letra:'w'},{number:4, letra:'r'},{number:7, letra:'t'}]);
			var result = numbers.orderBy(function(x, y){
								return (x.number - y.number);
								});
			expect(result.isEqual(new List([{number:1, letra:'a'},{number:3, letra:'q'},{number:4, letra:'r'},{number:5, letra:'e'},{number:7, letra:'t'},{number:9, letra:'w'}])))
				.to.be(true);
		});
	});
	describe(".skip(<number>)", function(){
    it("Given list with numbers when call skip method then return an empty list", function(){
      var numbers = new List();
	  var result = numbers.skip(3);
      expect(result.isEqual(new List())).to.be(true);
    });
    it("Given list with numbers when call skip method then Ignores the specified number of items and returns a sequence starting at the item after the last skipped item (if any)", function(){
      var numbers = new List([1,2,3,4,5,6,7,8]);
	  var result = numbers.skip(3);
      expect(result.isEqual(new List([4,5,6,7,8]))).to.be(true);
    });
  });
  describe(".getRange(<position, length>)", function(){
    it("Given an list with elements when call getRange(<position, length>) method then return a list with the elements in the range", function(){
      var numbers = new List([1,2,3,4,54,62, 81]);
	  var result = numbers.getRange(2,3);
      expect(result.isEqual(new List([3,4,54]))).to.be(true);
    });
    it("Given an empty list when call getRange(<position, length>) method then return an empty list", function(){
      var numbers = new List();
	  var result = numbers.getRange(2,3);
      expect(result.isEqual(new List())).to.be(true);
    });
  });
  describe(".isEqual(<list>)", function(){
    it("Given an list with elements when call isEqual method, with the same elements, then return true", function(){
      var numbers = new List([1,2]);
      expect(numbers.isEqual(new List([1,2]))).to.be(true);
    });
	it("Given an empty list when call isEqual method, with another empty list then, return true", function(){
      var numbers = new List();
      expect(numbers.isEqual(new List())).to.be(true);
    });
    it("Given an list with numbers when call isEqual method, with a different numbers then, return false", function(){
      var numbers = new List([1,3,4,5,6]);

      expect(numbers.isEqual(new List([4,5,6,7,8,5,4,5,6]))).to.be(false);
    });
  });
  describe(".join()", function(){
    it("Given an list with elements when call join method, then return the elements joined", function(){
      var numbers = new List([1,2]);

      expect(numbers.join()).to.eql("12");
    });
    it("Given an empty list when call join method, return string empty", function(){
      var numbers = new List([]);
      expect(numbers.join()).to.eql("");
    });
    it("Given an list with numbers when call join method, with comma character then, return the elements joined", function(){
      var numbers = new List([1,3,4,5,6]);
      expect(numbers.join(",")).to.eql("1,3,4,5,6");
    });
  });
  describe(".zip(<list>)", function(){
	  it("Given an list with elements when call zip method with empty list, then return the same list", function(){
		  var numbers = new List([1,2]);

		  expect(numbers.zip(new List()).isEqual(numbers)).to.be(true);
	});
	it("Given an empty list with elements when call zip method with a list with elements, then return a list with the elements", function(){
		  var numbers = new List();

		  expect(numbers.zip(new List([1,2])).isEqual(new List([1,2]))).to.be(true);
	});
	it("Given an empty list when call zip method with empty list, return an empty list", function(){
      var numbers = new List([]);

      expect(numbers.zip(new List([])).isEqual(new List([]))).to.be(true);
    });
	it("Given an list with numbers when call zip method, return the elements zipped", function(){
      var numbers = new List([1]);

	  var result = numbers.zip(new List([2]));
	
      expect(result.isEqual(new List([1,2]))).to.be(true);
    });
	it("Given an list with numbers when call zip method, return the elements zipped", function(){
      var numbers = new List([1,3,5]);

	  var result = numbers.zip(new List([2,4,6]));

      expect(result.isEqual(new List([1,2,3,4,5,6]))).to.be(true);
    });
    it("Given different lists with numbers when call zip method, return a list with zipped elements", function(){
      var numbers = new List([1,3,5]);

	  var result = numbers.zip(new List([2,4]));

      expect(result.isEqual(new List([1,2,3,4,5]))).to.be(true);
    });
    it("Given different lists with numbers when call zip method, return a list with zipped elements", function(){
      var numbers = new List([1,3]);

	  var result = numbers.zip(new List([2,4,6]));

      expect(result.isEqual(new List([1,2,3,4,6]))).to.be(true);
    });
  });
  describe(".distinct()", function(){
	it("Given an empty list with elements when call distinct method with, then return an empty list", function(){
		var numbers = new List();

		var result = numbers.distinct();

		expect(result.isEqual(new List())).to.be(true);
	});
	it("Given an list with elements when call distinct method with, then return a list with unique elements", function(){
		var numbers = new List([1,2,3,4]);

		var result = numbers.distinct();

		expect(result.isEqual(new List([1,2,3,4]))).to.be(true);
	});
	it("Given an list with repeated elements when call distinct method with, then return a list with unique elements", function(){
		var numbers = new List([1,2,4,3,4]);
		var result = numbers.distinct();
		expect(result.isEqual(new List([1,2,4,3]))).to.be(true);
	});
	it("Given an list with repeated objects when call distinct method with, then return a list with unique objects", function(){
		var numbers = new List([{number:1, letter:'a'},{number:2, letter:'b'},{number:4, letter:'c'},{number:3, letter:'f'},{number:4, letter:'c'}]);
		var result = numbers.distinct();
		var expected = new List([{number:1, letter:'a'},{number:2, letter:'b'},{number:4, letter:'c'},{number:3, letter:'f'}]);
		expect(result.isEqual(expected)).to.be(true);		
	});
  });
	describe(".indexOf(<element>)", function(){
		it("Given an empty list and call a indexOf, returns -1", function(){
			var numbers = new List();
			expect(numbers.indexOf(3)).to.be(-1);
		});
		it("Given a list with elements, return the element in de position", function(){
			var numbers = new List([1,2,3,4,5,6,7,8,9]);
			expect(numbers.indexOf(5)).to.be(4);
		});
		it("Given a list with elements, call indexOf with an number that doesn´ t exists, return -1", function(){
			var numbers = new List([1,2,3,7]);
			expect(numbers.indexOf(5)).to.be(-1);
		});
		it("Given a list with objects, call indexOf then returns the position of the object in the list", function(){
			var numbers = new List([{number:1, letter:'a'},{number:2, letter:'b'},{number:4, letter:'c'},{number:3, letter:'f'}]);
			expect(numbers.indexOf({number:2, letter:'b'})).to.be(1);
		});
	});
});
