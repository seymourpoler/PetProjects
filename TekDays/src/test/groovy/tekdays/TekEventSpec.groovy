package tekdays

import grails.testing.gorm.DomainUnitTest
import spock.lang.Specification

class TekEventSpec extends Specification implements DomainUnitTest<TekEvent> {

    def setup() {
    }

    def cleanup() {

    }

    void "test toString"(){
        def event = new TekEvent(
                name: "Groovy One",
                city: "San Francisco, co",
                organizer: "John Doe",
                venue: "Moscone Center",
                startDate: new Date("06/02/2009"),
                endDate:  new Date("06/05/2009"),
                description: "this conference cover ...")

        assertEquals "Groovy One, San Francisco, co", event.toString()
    }

    void "test something"() {
        expect:"fix me"
            true == false
    }
}
