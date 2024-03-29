import org.hamcrest.Matcher;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.HashMap;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.TimeUnit;

public class AuctionMessageTranslator implements MessageListener{

    private AuctionEventListener listener;
    private String sniperId;

    private ArrayBlockingQueue<Message> messages;

    public AuctionMessageTranslator(){
        messages = new ArrayBlockingQueue<Message>(1);
    }

    public void receivesAMessage() {
        //assertThat("Message", messages.poll(5, SECONDS), is(notNullValue()));
        throw new NotImplementedException();
    }

    public void receivesAMessage(String message) {
        throw new NotImplementedException();
    }

    public void sendMessage(Message message) {
        throw new NotImplementedException();
    }

    public void receivesAMessage(Matcher<? super String> messageMatcher)
            throws InterruptedException
    {
        final Message message = messages.poll(5, TimeUnit.SECONDS);
        //assert("Message", message, is(notNullValue());
        //assert(message, is(notNullValue());
        //assert(message.getBody(), is(messageMatcher));
    }

    public AuctionMessageTranslator(String sniperId, AuctionEventListener listener){
        this.sniperId = sniperId;
        this.listener = listener;
    }

    public void processMessage(Chat aChat, Message aMessage){
        AuctionEvent event = AuctionEvent.from(aMessage.getBody());
        String eventType = event.type();
        if ("CLOSE".equals(eventType)) {
            listener.auctionClosed();
        } else if ("PRICE".equals(eventType)) {
            listener.currentPrice(event.currentPrice(), event.increment(), event.isFrom(sniperId));
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
