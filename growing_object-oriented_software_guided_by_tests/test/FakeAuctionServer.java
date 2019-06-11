import org.hamcrest.Matcher;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import static java.lang.String.format;

public class FakeAuctionServer implements IAuctionServer {

    public static final String ITEM_ID_AS_LOGIN = "auction-%s";
    public static final String AUCTION_RESOURCE = "Auction";
    public static final String XMPP_HOSTNAME = "localhost";
    private static final String AUCTION_PASSWORD = "auction";

    private final XMPPConnection connection;
    private final String _item;
    private Chat currentChat;
    private final MessageListener messageListener;

    FakeAuctionServer(String item){
        _item = item;
        connection = new XMPPConnection(XMPP_HOSTNAME);
        messageListener = new SingleMessageListener();
    }

    public String getItemId(){
        return _item;
    }

    public void hasReceivedJoinRequestedFromSniper() {
        throw  new NotImplementedException();
    }

    public void startSellingItem(){
        connection.connect();
        connection.login(ITEM_ID_AS_LOGIN, AUCTION_PASSWORD, AUCTION_RESOURCE);

        connection.getChatManager().addChatListener(
            new ChatManagerListener(){
                public void chatCreated(Chat chat, boolean createdLocally) {
                    currentChat = chat;
                    chat.addMessageListener(messageListener);
                }});

    }

    public void hasReceivedJoinRequestedFromSniper(String sniperXmppId){
        messageListener.receivesAMessage(sniperXmppId);
    }

    public void announceClosed(){
        messageListener.sendMessage(new Message());
    }

    public void stop(){
        connection.disconnect();
    }

    public void reportPrice(int price, int increment, String bidder) {
        String message = format("SOLVersion: 1.1; Event: PRICE; CurrentPrice: %d; Increment: %d; Bidder: %s;", price, increment, bidder);
        currentChat.sendMessage(message);
    }

    public void hasReceivedBid(int bid, String sniperXmppId) throws RuntimeException{
        if(currentChat.getParticipant() != sniperXmppId){
            throw new RuntimeException();
        }
        String message = format("SOLVersion: 1.1; Command: BID; Price: %d;", bid);
        messageListener.receivesAMessage(message);
    }

    private void receivesAMessageMatching(String sniperId, Matcher<? super String> messageMatcher) {
        //messageListener.receivesAMessage(messageMatcher);
        //assert(currentChat.getParticipant(), equalTo(sniperId));
    }
}
