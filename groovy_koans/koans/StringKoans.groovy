package koans;

/*
* Groovy Strings
*
* Instructions: Replace __ with your answer.
*
* For more information, See:
* - http://groovy.codehaus.org/Strings+and+GString
* - http://groovy.codehaus.org/JN1525-Strings
*
*/
class StringKoans extends Koans {
	
	
	void testDoubleQuoteStringType() {
		assertEquals "java.lang.String", "Any ole String".class.name
	}
	
	void testSingleQuoteStringType() {
		assertEquals "java.lang.String", 'A Single Quote String'.class.name
	}
	
	void testSlashyQuoteStringType() {
		assertEquals "java.lang.String", /A Slashy String/.class.name
	}

	void testMultiLineStringType() {
		assertEquals "java.lang.String", """A Triple Quote String""".class.name
	}

	void testStringInterpolation() {
		def answer = "c"
		assertEquals "abc", "ab${answer}"
		//assertEquals "abc", 'ab${answer}'
		//assertEquals ("ab[[c]]", /ab${answer}/);
	}
	
	void testInterpolatedStringType() {
		def answer = "c"
		assertEquals "org.codehaus.groovy.runtime.GStringImpl", "ab${answer}".class.name
		assertEquals "java.lang.String", 'ab${answer}'.class.name
		assertEquals "org.codehaus.groovy.runtime.GStringImpl", /ab${answer}/.class.name
	}
	
	void testMultiLineString() {
		def myStr1 = "Stuff"
		def myStr2 = "More Stuff"
		def name = """${myStr1}${myStr2}"""
		assertEquals """StuffMore Stuff""", name
		
		name = """${myStr1} \
${myStr2}"""
		assertEquals """Stuff More Stuff""", name
	}
	
	void testStringConcatenation() {
		def myStr1 = "ab"
		def myStr2 = "cd"
		assertEquals "ab cd", myStr1 + " " + myStr2
		assertEquals "ab cd", (myStr1 << " " << myStr2).toString() // leftShift returns a StringBuffer
		assertEquals "ab cd", myStr1.plus(" ").plus(myStr2)
	}
	
	void testStringMutable() {
		def myString = "abc"
		assertEquals "abc", myString
		assertEquals "cba", myString.reverse()
		assertEquals "abc", myString
	}
	
	void testStringBuilderMutable(){
		def myStrBldr = new StringBuilder("abc")
		assertEquals "abc", myStrBldr.toString()
		assertEquals "cba", myStrBldr.reverse().toString()
		assertEquals "cba", myStrBldr.toString()
	}
	
	
	void testSubScriptingStrings() {
		assert 'abcdefg'[ 3 ] == "d"
		assert 'abcdefg'.getAt( 3 ) == "d" //equivalent method name
		assert 'abcdefg'.charAt( 3 ) == "d" //alternative method name
		assert 'abcdefg'[ 3..5 ] == "def"
		assert 'abcdefg'.getAt( 3..5 ) == "def"
		assert 'abcdefg'[ 1, 3, 5, 6 ] == "bdfg"
		assert 'abcdefg'[ 1, 3..5 ] == "bdef"
		assert 'abcdefg'[-5..-2] == "cdef"
		assert 'abcdefg'.getAt( [ 1, 3..5 ] ) == "bdef"
	}
	
	
	void testSubScriptingStringBuilder() {
		def myStrBldr = new StringBuilder("abcd")
		assert "bcd" == myStrBldr[1..3]
		assert "abcd" == myStrBldr.toString()
	}
	
	void testAppendingStringBuilder() {
		def myStrBldr = new StringBuilder("ab")
		myStrBldr.append "cd"
		assert "abcd" == myStrBldr.toString()
		myStrBldr << "ef"
		assert "abcdef" == myStrBldr.toString()
	}
}
