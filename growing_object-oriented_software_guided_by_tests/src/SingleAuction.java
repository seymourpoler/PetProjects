public class SingleAuction implements Auction {

    private final String BID_COMMAND_FORMAT = "bid-command";

    private Chat chat;

    public SingleAuction(Chat chat){
        this.chat = chat;
    }

    public void bid(int amount) {
        String message = String.format(BID_COMMAND_FORMAT, amount);
        chat.sendMessage(message);
    }
}
