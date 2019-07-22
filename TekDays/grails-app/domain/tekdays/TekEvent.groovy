package tekdays

class TekEvent {

    String city
    String name
    String organizer
    String venue
    Date startDate
    Date endDate
    String description

    String toString(){
        "$name, city"
    }

    static constraints = {
    }
}
