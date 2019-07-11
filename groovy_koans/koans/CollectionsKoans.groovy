package koans;
/**
 * Groovy Collections
 * 
 * Instructions: Replace __ with your answer.
 *
 * For more information, see:
 * - http://groovy.codehaus.org/JN1015-Collections
 * - http://groovy.codehaus.org/Collections
 * - http://groovy.codehaus.org/groovy-jdk/java/util/Collection.html
 * - http://groovy.codehaus.org/groovy-jdk/java/util/List.html
 * - http://groovy.codehaus.org/groovy-jdk/java/util/Set.html
 */
class CollectionsKoans extends Koans {
	
	void testCreateCollection() {
		def list = []
		assert 0 == list.size
	}

	void testCollectionInterface() {
		//assert [] instanceof List
	}
	
	void testCollectionType() {
		assert 'java.util.ArrayList' == [].class.name
	}
	
	void testInitializingCollection() {
		def list = ['a', 1, 'a', 'a', 2.5, 2.5f, 2.5d, 'hello', 7g, null, 9 as byte, ];
		assert 11 == list.size, "collections hold multiple types, duplicates and can contain an extra comma"
	}
	
	void testCollectionTruth() {
		assertTruth false,[]
		assertTruth true, ['a']
	}

	void testAccessingCollections() {
		def list = ['a', 'b', 'c', 'd', 'e'];
		
		assert 'c' == list.get(2), 'get method'
		assert 'd' == list[3], 'index access'
		assert 'a' == list.first(), 'first method'
		assert 'e' == list.last(), 'last method'
		assert 'a' == list.head(), 'head method'
		assert ['b', 'c', 'd', 'e'] == list.tail(), 'tail method'
	}
	
	void testAppendingCollections() {
		def list = ['a'];
		
		list.add('b')
		list.addAll(['c','d'])
		list.push('e')
		list << 'f'
		assert ['a', 'b', 'c', 'd', 'e', 'f'] == list, "add, push and << operator"
		
		assert ['a', 'b', 'c', 'd', 'e', 'f', 'g'] == list + 'g', "+ operator"
		
		list += 'h'
		assert ['a', 'b', 'c', 'd', 'e', 'f', 'h'] == list, "+= operator"
	}

	void testInsertIntoCollections() {
		def list = ['a','b','c'];
		
		list.add(1,'d')
		assert ['a', 'd', 'b', 'c'] == list, "add with index"
		
		list.addAll(2, ['e','f'])
		assert ['a','d', 'e','f', 'b', 'c'] == list, "add all with index"
	}
	
	void testUpdatingCollections() {
		def list = ['a','b','c'];
		
		list[0] = 'e'
		assert ['e','b','c'] == list, 'subscript index update'
		
		assert 'c' == list.set(2, 'f'), 'element replacement'
		assert ['e','b', 'f'] == list
	}
		
	void testChaninedAppending() {
		def list = ['a']
		
		list << 'g' << 'h'
		assert ['a', 'g', 'h'] == list
	}
	
	void testAppendingLists() {
		def list = ['a']
		
		list << ['i','j']
		assert ['a', ['i', 'j']] == list
	}

	void testFlatteningLists() {
		def list = [['a',['b','b']], ['c','d'], 'e'];
		
		assert ['a', 'b', 'b', 'c', 'd', 'e'] == list.flatten()
	}

	
	void testBeyondBounds() {
		int beyondBounds = 5
		def list = ['a', 'b','c'];
		
		assert __ == list[beyondBounds], "accessing element beyond current size"
		
		list[beyondBounds] = 'j'
		assert [__] == list, "setting element beyond current size"
	}

	void testNegativeIndices() {
		def list = ['a', 'b', 'c', 'd', 'e'];
		
		assert 'e' == list[-1], "-1 indices"
		assert 'd' == list[-2], "-2 indices"
	}
	
	void testSlicingCollection() {
		def list = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j'];
		
		assert ['b', 'c', 'd'] == list[1..3], "range slicing"
		assert ['a', 'c', 'e'] == list[0,2,4], "index slicing"	
		assert ['a', 'c', 'e', 'f', 'g', 'h', 'i'] == list[0,2,4,5..8], "combination of index and range slicing"
	}
	
	void testEachClosure() {
		def items = ""
		
		['a', 'b', 'c'].each{ items += "Item: $it \n" }

		assert 'Item: a \nItem: b \nItem: c \n' == items
	}
	
	void testEachIndexClosure() {
		def items = ""
	
		['a', 'b', 'c'].eachWithIndex{ it, i -> items += "$i: $it\n" }
		
		assert __ == items
	}
	
}
