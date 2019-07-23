package com.tekdays

class TekEvent {
	String city
	String name
	String organizer
	String venue
	Date startDate
	Date endDate
	String description

    static constraints = {
    }

    String toString(){
    	"$name, $city"
    }
}
