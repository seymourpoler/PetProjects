package koans

import static java.util.Calendar.*

/*
* Groovy Dates
*
* Instructions: Replace __ with your answer.
*
* For more information, See:
* - http://groovy.codehaus.org/JN0545-Dates
* - http://groovy.codehaus.org/groovy-jdk/java/util/Date.html
* - http://download.oracle.com/javase/6/docs/api/java/util/Date.html 
* - http://groovy.codehaus.org/groovy-jdk/java/util/Calendar.html
* - http://download.oracle.com/javase/6/docs/api/java/util/Calendar.html
*
*/
class DateKoans extends Koans {
	// Creating Dates
	void testParseStringToDate() {
		def date = new Date().parse('yyyy/MM/dd', '2001/09/11')
		assert 'java.util.Date' == date.class.name
		assert 101 == date.year
		assert 8 == date.month
		assert 11 == date.date
		assert 0 == date.hours
		assert 0 == date.minutes
	}
	
	void testCreateDateViaConstructor() {
		// Java Constructor
		def date = new Date(101,8,11)
		assert 'java.util.Date' == date.class.name
		assert 101 == date.year
		assert 8 == date.month
		assert 11 == date.date
		assert 0 == date.hours
		assert 0 == date.minutes
		
		// Groovy Named Parameters
		def date2 = new Date(year: 101, month: SEPTEMBER, date: 11, hours:0, minutes: 0, seconds: 0)
		assert 'java.util.Date' == date2.class.name
		assert 101 == date2.year
		assert 8 == date2.month
		assert 11 == date2.date
		assert 0 == date2.hours
		assert 0 == date2.minutes
	}
	
	void testCreateDateFromCalendar() {
		def cal = Calendar.instance
		cal.set(year: 2001, month: SEPTEMBER, date: 11, hourOfDay: 0, minute: 0, second: 0)
		assert 'java.util.GregorianCalendar' == cal.class.name
		assert 'java.util.Date' == cal.time.class.name
		def date = cal.time
		assert 101 == date.year
		//assert 8 == date.month
		//assert 11 == date.date
		//assert 0 == date.hours
		//assert 0 == date.minutes
	}
	
	void testDateSetter() {
		def date = new Date()
		date.set(hourOfDay: 0, minute: 0, second: 0, year: 2001, month: SEPTEMBER, date: 11)
		assert 'java.util.Date' == date.class.name
		assert 101 == date.year
		assert 8 == date.month
		assert 11 == date.date
		assert 0 == date.hours
		assert 0 == date.minutes
		
		def date2 = new Date()
		date2.year = 101
		date2.month = SEPTEMBER
		date2.date = 11
		date2.hours = 0
		date2.minutes = 0
		date2.seconds = 0
		assert 101 == date2.year
		assert 8 == date2.month
		assert 11 == date2.date
		assert 0 == date2.hours
		assert 0 == date2.minutes
	}
	
	void testClearTime() {
		def date = new Date()
		date.clearTime()
		assert 0 == date.hours
		assert 0 == date.minutes
		assert 0 == date.seconds
	}
	
	// accessors
	void testDateFieldAccessLikeMap() {
		def date = new Date(year: 101, month: SEPTEMBER, date: 11, hours:0, minutes: 0, seconds: 0)
		assert 2001 == date[YEAR]
		assert 8 == date[MONTH]
		assert 11 == date[DATE]
		assert 0 == date[HOUR]
		assert 0 == date[MINUTE]
		assert 0 == date[SECOND]
	}
	
	void testDateFieldAccessLikeGetter() {
		def date = new Date(year: 101, month: SEPTEMBER, date: 11, hours:0, minutes: 0, seconds: 0)
		assert 101 == date.year
		assert 8 == date.month
		assert 11 == date.date
		assert 0 == date.hours
		assert 0 == date.minutes
		assert 0 == date.seconds
	}
	
	void testDateStringGetters() {
		def date = new Date(year: 41, month: DECEMBER, date: 07, hours:7, minutes: 55, seconds: 0)
		assert '12/7/41' == date.dateString	
		assert '7:55:00 AM' == date.timeString 
		assert '12/7/41, 7:55:00 AM' == date.dateTimeString
	}
	
	
	// Date Math
	void testDateMath() {
		def date = new Date(year: 101, month: SEPTEMBER, date: 11, hours:0, minutes: 0, seconds: 0)
		def datePlusOne = date + 1
		def dateMinusOne = date - 1
		assert 101 == datePlusOne.year
		assert 8 == datePlusOne.month
		assert 12 == datePlusOne.date
		assert 0 == datePlusOne.hours
		assert 0 == datePlusOne.minutes
		assert 0 == datePlusOne.seconds
		
		assert 101 == dateMinusOne.year
		assert 8 == dateMinusOne.month
		assert 10 == dateMinusOne.date
		assert 0 == dateMinusOne.hours
		assert 0 == dateMinusOne.minutes
		assert 0 == dateMinusOne.seconds
		
		def dateIncrement = ++date
		assert 101 == dateIncrement.year
		assert 8 == dateIncrement.month
		assert 12 == dateIncrement.date
		assert 0 == dateIncrement.hours
		assert 0 == dateIncrement.minutes
		assert 0 == dateIncrement.seconds
		
		def dateDecrement = --date
		assert 101 == dateDecrement.year
		assert 8 == dateDecrement.month
		assert 11 == dateDecrement.date
		assert 0 == dateDecrement.hours
		assert 0 == dateDecrement.minutes
		assert 0 == dateDecrement.seconds
	}
	
	// Compare Dates
	void testCompareDates() {
		def date = new Date(year: 101, month: SEPTEMBER, date: 11, hours:0, minutes: 0, seconds: 0)
		def datePlusOne = date + 1
		def dateMinusOne = date - 1
		
		assert datePlusOne.after(date)
		assert dateMinusOne.before(date)
		assert datePlusOne.compareTo(date) > 0
		assert dateMinusOne.compareTo(date) < 0
		assert date.compareTo(date) == 0
	}

}
