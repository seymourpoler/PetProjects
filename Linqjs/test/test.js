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
      var numbers =[];
      expect(numbers.sum()).to.eql(0);
    });
    it("Given array  with numbers when call Sum method then returns the sumatory", function(){
      var numbers =[1,2,3,4];
      expect(numbers.sum()).to.eql(10);
    });
  });
  describe(".take(<number>)", function(){
    it("Given array when call Sum method then returns Zero ", function(){
      var numbers =[];
      expect(numbers.take(3)).to.eql([]);
    });
    it("Given array  with numbers when call Sum method then returns the sumatory", function(){
      var numbers =[5,3,7,9];
      expect(numbers.take(2)).to.eql([5,3]);
    });
  });
});
