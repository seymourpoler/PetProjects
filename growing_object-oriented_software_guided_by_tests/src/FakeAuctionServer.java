public class FakeAuctionServer implements IAuctionServer {

    public static final String ITEM_ID_AS_LOGIN = "auction-%s";
    public static final String AUCTION_RESOURCE = "Auction";
    public static final String XMPP_HOSTNAME = "localhost";
    private static final String AUCTION_PASSWORD = "auction";

    private final XMPPConnection connection;
    private final String _item;
    private Chat currentChat;

    FakeAuctionServer(String item){
        _item = item;
        connection = new XMPPConnection(XMPP_HOSTNAME);
    }

    public String getItemId(){
        return _item;
    }

    public void startSellingItem(){
        connection.connect();
        connection.login(format(ITEM_ID_AS_LOGIN, _item), AUCTION_PASSWORD, AUCTION_RESOURCE);

    }

    public void hasReceivedJoinRequestedFromSniper(){
    }

    public void announceClosed(){
    }

    public void stop(){
    }
}
