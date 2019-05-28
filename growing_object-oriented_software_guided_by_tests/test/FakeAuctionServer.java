import sun.reflect.generics.reflectiveObjects.NotImplementedException;

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

    public void startSellingItem(){
        connection.connect();
        connection.login(ITEM_ID_AS_LOGIN, AUCTION_PASSWORD, AUCTION_RESOURCE);

        connection.getChatManager().addCharListener(
            new ChatManagerListener(){
                public void chatCreated(Chat chat, boolean createdLocally) {
                    currentChat = chat;
                    chat.addMessageListener(messageListener);
                }});

    }

    public void hasReceivedJoinRequestedFromSniper(){
        messageListener.receivesAMessage();
    }

    public void announceClosed(){
        messageListener.sendMessage(new Message());
    }

    public void stop(){
        connection.disconnect();
    }

    public void reportPrice(int price, int anotherPrice, String bidder) {
        throw new NotImplementedException();
    }

    public void hasReceivedBid(int price, String SniperXmppId) {
        throw new NotImplementedException();
    }
}
