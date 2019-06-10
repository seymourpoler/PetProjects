public class Main {

    private static final int ARG_HOSTNAME = 0;
    private static final int ARG_USERNAME = 1;
    private static final int ARG_PASSWORD = 2;
    private static final int ARG_ITEM_ID = 3;

    public static final String AUCTION_RESOURCE = "Auction";
    public static final String ITEM_ID_AS_LOGIN = "auction-%s";
    public static final String AUCTION_ID_FORMAT = ITEM_ID_AS_LOGIN + "@%s/" + AUCTION_RESOURCE;

    public static final String JOIN_COMMAND_FORMAT = "join-command-format";

    public static void main(String[] args) throws Exception{
        UI ui = new UI();
        ui.addWindowListener();
        XMPPConnection connection = connectTo(args[ARG_HOSTNAME],
            args[ARG_USERNAME],
            args[ARG_PASSWORD]);

        Chat chat = connection.getChatManager().createChat(
                auctionId(args[ARG_ITEM_ID], connection),
                new SingleMessageListener() {
                    public void processMessage(Chat aChat, Message aMessage) {
                        ui.showStatus("status-lost");
                    }
                });
        chat.sendMessage(JOIN_COMMAND_FORMAT);
    }

    private static XMPPConnection connectTo(String hostName, String userName, String password) throws XMPPException  {
        XMPPConnection connection = new XMPPConnection(hostName);
        connection.connect();
        connection.login(userName, password, AUCTION_RESOURCE);

        return connection;
    }

    private static String auctionId(String itemId, XMPPConnection connection){
        return String.format(AUCTION_ID_FORMAT, itemId, connection.getServiceName());
    }
}
