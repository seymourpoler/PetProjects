package koans

/*
* Groovy Operator Overloading
*
* Instructions: Replace __ with your answer.
*
* For more information, See:
* - http://groovy.codehaus.org/Operator+Overloading
* 
*/
class OperatorOverloadingKoans extends Koans  {
	
	def holder = new Holder()
	
	void testPlusOperator() {
		holder.value = 1
		holder + 1
		assertEquals 2, holder.value
	}
	
	void testMinusOperator() {
		holder.value = 1
		holder - 1
		assertEquals 0, holder.value
	}
	
	void testMultiplyOperator() {
		holder.value = 2
		holder * 3
		assertEquals 6, holder.value
	}
	
	void testPowerOperator() {
		holder.value = 2
		holder ** 3
		assertEquals 8, holder.value
	}
	
	void testDivOperator() {
		holder.value = 6
		holder / 3
		assertEquals 2, holder.value
	}
	
	void testModOperator() {
		holder.value = 5
		holder % 2
		assertEquals 1, holder.value
	}
	
	void testOrOperator() {
		holder.value = false
		holder | true
		assertEquals true, holder.value
	}
	
	void testAndOperator() {
		holder.value = false
		holder & true
		assertEquals false, holder.value
	}
	
	void testXorOperator() {
		holder.value = 1
		holder ^ 1
		assertEquals 0, holder.value
	}
	
	void testNextOperatorPrefix() {
		holder.value = 1
		++holder
		assertEquals 2, holder
	}
	
	void testNextOperatorPostfix() {
		holder.value = 1
		holder++
		assertEquals 2, holder
	}
	
	void testPreviousOperatorPrefix() {
		holder.value = 1
		--holder
		assertEquals 0, holder
	}
	
	void testPreviousOperatorPostfix() {
		holder.value = 1
		holder--
		assertEquals 0, holder
	}
	
	void testGetAtOperator() {
		holder.value = ["no","yes"]
		assertEquals "yes", holder[1]
	}
	
	void testPutAtOperator() {
		holder.value = ["abc", "def"]
		holder[1] = 123
		assertEquals 123 , holder[1]
	}
	
	void testLeftShiftOperator() {
		holder.value = "left"
		holder << "Shift"
		//assertEquals 'leftShift', holder.value
	}
	
	void testRightOperator() {
		holder.value = "rightShift"
		holder >> "Shift"
		assertEquals "right", holder.value
	}
	
	void testBitwiseNegativeOperator() {
		holder.value = 1
		~holder
		assertEquals 2, holder.value
	}
	
	void testPositiveOperator() {
		holder.value = -1
		(+holder)
		assertEquals 1, holder.value
	}
	
	void testNegativeOperator() {
		holder.value = 1
		-holder
		assertEquals "-1", holder.value.toString()	
	}
	void testEqualsOperator() {
		holder.value = 1
		assertEquals false, holder == 1
	}
	
	void testNotEqualsOperator() {
		holder.value = 1
		assertEquals true, holder != 1
	}
	
	void testCompareToOperator() {
		holder.value = 1
		def holder2 = new Holder(value:1)
		assertEquals 0, holder <=> holder2
	}
	
	void testGreaterThanOperator() {
		holder.value = 2
		def holder2 = new Holder(value:1)
		assertEquals true, holder > holder2
	}
	
	void testGreaterThanEqualToOperator() {
		holder.value = 1
		def holder2 = new Holder(value:1)
		assertEquals true, holder >= holder2
	}
	
	void testLessThanOperator() {
		holder.value = 2
		def holder2 = new Holder(value:1)
		assertEquals false, holder < holder2
	}

	void testLessThanEqualToOperator() {
		holder.value = 1
		def holder2 = new Holder(value:1)
		assertEquals true, holder <= holder2
	}
}

class Holder implements Comparable {
	def value
	/*
	 Operator	 Method
a + b	 a.plus(b)
a - b	 a.minus(b)
a * b	 a.multiply(b)
a ** b	 a.power(b)
a / b	 a.div(b)
a % b	 a.mod(b)
a | b	 a.or(b)
a & b	 a.and(b)
a ^ b	 a.xor(b)
a++ or ++a	 a.next()
a-- or --a	 a.previous()
a[b]	 a.getAt(b)
a[b] = c	 a.putAt(b, c)
a << b	 a.leftShift(b)
a >> b	 a.rightShift(b)
switch(a) { case(b) : }	 b.isCase(a)
~a	 a.bitwiseNegate()
-a	 a.negative()
+a	 a.positive()
	 */
	
	def plus(x) { value = value + x }
	def minus(x) { value = value - x }
	def multiply(x) { value = value * x}
	def power(x) { value = value  **  x }
	def div(x) { value = value / x }
	def mod(x) { value = value % x }
	def or(x) { value = value | x }
	def and(x) { value = value & x }
	def xor(x) {value = value ^ x }
	def next() { ++value }
	def previous() { --value }
	def getAt(x) { value[x] }
	def putAt(x,y) { value[x] = y}
	def leftShift(x) { value = value << x }
	def rightShift(x) { value = value.replace(x,"")  }
	def isCase(x) {"switch(${value}) { case(${x}) : }"}
	def bitwiseNegate() {value = -(~value) }
	def positive() { value = value < 0 ? -1 * value : value }
	def negative() { value = value > 0 ? -1 * value : value }
	
	def boolean equals(x) { value.equals(x) }
	def int compareTo(x) { value.compareTo(x.value) }

	
	
}
