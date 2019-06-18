import java.util.HashMap;
import java.util.Map;

public class AuctionEvent {

    private Map<String, String> fields = new HashMap<String, String>();
    public String type() {
        return get("Event");
    }
    public int currentPrice() {
        return getInt("CurrentPrice");
    }
    public int increment() {
        return getInt("Increment");
    }

    public static AuctionEvent from(String body){
        AuctionEvent result = new AuctionEvent();
        for (String field : fieldsIn(body)) {
            result.addField(field);
        }
        return result;
    }

    public PriceSource isFrom(String sniperId){
        if(sniperId.equals(bidder())){
            return PriceSource.FromSniper;
        }
        return PriceSource.FromOtherSniper;
    }

    private String bidder() {
        return get("Bidder");
    }

    private int getInt(String fieldName) {
        return Integer.parseInt(get(fieldName));
    }
    private String get(String fieldName) {
        return fields.get(fieldName);
    }

    private void addField(String field){
        String[] pair = field.split(":");
        fields.put(pair[0].trim(), pair[1].trim());

    }
    private static String[] fieldsIn(String messageBody) {
        return messageBody.split(";");
    }
}
