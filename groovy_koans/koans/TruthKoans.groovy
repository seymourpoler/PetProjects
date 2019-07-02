package koans;

/**
* Groovy Truth
* 
* Instructions: Replace __ with either a true or false.
*
* For more information, See:
* - http://groovy.codehaus.org/Groovy+Truth
*
*/
class TruthKoans extends Koans {
	public static ZERO = 0
	public static NON_ZERO = 3
	public static EMPTY_STRING = ""
	public static NEGATIVE_NUMBER = -1

	// Boolean Expressions
	
	void testTrueForTruth() {
		assertTruth true, true
	}
	
	void testFalseForTruth() {
		assertTruth false, false
	}
	
	// Objects
	
	void testNullForTruth() {
		assertTruth __, null
	}

	void testObjectReferencesForTruth() {
		assertTruth true, new Object()
	}
	
	// Numbers
	
	void testZeroForTruth() {
		assertTruth false, ZERO
	}
	
	void testNonZeroForTruth() {
		assertTruth (true, NON_ZERO);
	}
	
	void testNegativeNumberForTruth() {
		assertTruth (false, NEGATIVE_NUMBER)
	}
	
	// Strings
	
	void testEmptyStringForTruth() {
		assertTruth false, EMPTY_STRING
	}
	
	void testNonEmptyForTruth() {
		assertTruth __, "Groovy is cool!!!"
	}
	
	// Collections
	
	void testEmptyCollectionForTruth() {
		assertTruth __, []
	}
	
	void testCollectionWithItemsForTruth() {
		assertTruth __, [1,2,3] 
	}
	
	void testIteratorOnEmptyCollectionForTruth() {
		assertTruth __, [].iterator()
	}
	
	void testIteratorOnNonEmptyForTruth() {
		assertTruth __, [1,2,3].iterator()
	}
	
	// Maps
	
	void testEmptyMapForTruth() {
		assertTruth false, [:]
	}
	
	void testPopulatedMapForTruth() {
		assertTruth __, ['one':1]
	}
	
	// Matchers
	
	void testUnMatchingMatcherForTruth() {
		assertTruth __, 'Hello Groovy' =~ /World/
	}
	
	void testMatchingMatcherForTruth() {
		assertTruth __, 'Hello World' =~ /World/
	}
	
	// Implementing your own Groovy Truth
	
	void testPossitiveCustomTruth() {
		def customTruth = new CustomTruth(value:true);
		assertTruth (new CustomTruth(value: true).asBoolean(), customTruth.asBoolean());
	}

	void testNegativeCustomTruth() {
		def customTruth = new CustomTruth(value:false);
		assertTruth false, customTruth
	}
	
}

class CustomTruth {
	boolean value

	public boolean asBoolean() {
		return value;
	}
	
}
