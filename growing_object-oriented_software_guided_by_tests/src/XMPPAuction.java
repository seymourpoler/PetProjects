public class XMPPAuction implements Auction {

    private final String BID_COMMAND_FORMAT = "bid-command";
    private final String JOIN_COMMAND_FORMAT = "join-command";

    private Chat chat;

    public XMPPAuction(Chat chat){

        this.chat = chat;
    }

    public void bid(int amount) {
        String message = String.format(BID_COMMAND_FORMAT, amount);
        chat.sendMessage(message);
    }

    public void join(){
        chat.sendMessage(JOIN_COMMAND_FORMAT);
    }
}
