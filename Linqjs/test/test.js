var sut = require("../source/sut.js"),
 expect = require("expect.js");

describe("linq in javascript using TDD", function(){
  describe(".count()", function(){
    it("Given empty array when call Count method then returns zero ", function(){
      var numbers =[];
      expect(numbers.count()).to.eql(0);
    });

    it("Given array when call Count method then returns the number of elements ", function(){
      var numbers =[1,2,3,4];
      expect(numbers.count()).to.eql(4);
    });
  });
  describe(".sum()", function(){
    it("Given array when call Sum method then returns Zero ", function(){
      var numbers = [];
      expect(numbers.sum()).to.eql(0);
    });
    it("Given array  with numbers when call Sum method then returns the sumatory", function(){
      var numbers = [1,2,3,4];
      expect(numbers.sum()).to.eql(10);
    });
	it("Given array with strings when call Sum method then returns only the sum of the numbers ", function(){
      var numbers = [1,'w', {a:1, b:3}, 5, 'rdf'];
      expect(numbers.sum()).to.eql(6);
    });
  });
  describe(".take(<number>)", function(){
    it("Given array when call Sum method then returns Zero ", function(){
      var numbers = [];
      expect(numbers.take(3)).to.eql([]);
    });
    it("Given array  with numbers when call Sum method then returns the sumatory", function(){
      var numbers = [5,3,7,9];
      expect(numbers.take(2)).to.eql([5,3]);
    });
  });
  describe(".where(<condition>)", function(){
	it("Given array  with numbers when call where with a condition method then returns a new array with applied the condition", function(){
	  var numbers = [5,3,7,9];
	  expect(numbers.where(function(x){ return x > 5})).to.eql([7,9]);
    });
	it("Given array  with numbers when call where with a condition method then returns a new array with applied the condition", function(){
	  var numbers = [5,3,7,9];
	  expect(numbers.where(function(x){ return x > 458})).to.eql([]);
    });
  });
  describe(".union(<array>)", function(){
	it("Given array  with numbers when call union method then returns a new array with the union of the elements", function(){
	  var numbers = [5,3,7,9];
	  expect(numbers.union([1,2,3])).to.eql([5,3,7,9, 1,2,3]);
    });
	it("Given an empty array when call union method then returns an empty array", function(){
	  var numbers =[];
	  expect(numbers.union([])).to.eql([]);
    });
  });
  describe(".reverse(<array>)", function(){
	it("Given array  with numbers when call reverse method then returns a new array with the reverse of the elements", function(){
	  var numbers = [5,3,7,9];
	  expect(numbers.reverse()).to.eql([9,7,3,5]);
    });
	it("Given an empty array when call reverse method then returns an empty array", function(){
	  var numbers =[];
	  expect(numbers.reverse()).to.eql([]);
    });
  });
  describe(".select(<function>)", function(){
  it("Given array  with numbers when call select method then returns a new array with the of the method applied to each element", function(){
    var numbers = [5,3,7,9];
    expect(numbers.select(function(x){return x+1;})).to.eql([6,4,8,10]);
    });
  });
  describe(".remove(<condition>)", function(){
  it("Given array  with numbers when call remove method then returns a new array without the element ot be in the condition", function(){
    var numbers = [5,3,7,9];
    expect(numbers.remove(function(x){return x > 5;})).to.eql([7,9]);
    });
  });
  describe(".clear()", function(){
  it("Given array  with numbers when call clear method then returns a new empty array", function(){
    var numbers = [5,3,7,9];
    expect(numbers.clear()).to.eql([]);
    });
  });
  describe(".orderAscending()", function(){
  it("Given array  with numbers when call orderAscending method then returns an array ordered ascending", function(){
    var numbers = [5,3,1,9,4,7];
    expect(numbers.orderAscending()).to.eql([1,3,4,5,7,9]);
    });
  });
  describe(".orderDescending()", function(){
  it("Given array  with numbers when call orderAscending method then returns an array ordered descending", function(){
    var numbers = [5,3,1,9,4,7];
    expect(numbers.orderDescending()).to.eql([9,7,5,4,3,1]);
    });
  });
});
