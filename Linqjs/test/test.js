var sut = require("../source/sut.js"),
 expect = require("expect.js");
Array.prototype.Count = function(first_argument) {
  return this.length;
};


describe("linq in jabascript using TDD", function(){
  it("Given empty array when call Count method then returns zero ", function(){
    var numbers =[];
    expect(numbers.Count()).to.eql(0);
  });

  it("Given array when call Count method then returns the number of elements ", function(){
    var numbers =[1,2,3,4];
    expect(numbers.Count()).to.eql(4);
  });
});
