import java.util.HashMap;

public class AuctionMessageTranslator {

    private AuctionEventListener listener;

    public AuctionMessageTranslator(AuctionEventListener listener){
        this.listener = listener;
    }

    public void processMessage(Chat aChat, Message aMessage){
        HashMap<String, String> event = unpackEventFrom(aMessage);
        String type = event.get("Event");
        if ("CLOSE".equals(type)) {
            listener.auctionClosed();
        } else if ("PRICE".equals(type)) {
            listener.currentPrice(Integer.parseInt(event.get("CurrentPrice")),
                    Integer.parseInt(event.get("Increment")));
        }
    }

    private HashMap<String, String> unpackEventFrom(Message message) {
        HashMap<String, String> event = new HashMap<String, String>();
        for (String element : message.getBody().split(";")) {
            String[] pair = element.split(":");
            event.put(pair[0].trim(), pair[1].trim());
        }
        return event;
    }
}
