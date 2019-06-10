public class AuctionMessageTranslator {

    private AuctionEventListener listener;

    public AuctionMessageTranslator(AuctionEventListener listener){
        this.listener = listener;
    }

    public void processMessage(Chat aChat, Message aMessage){
        listener.auctionClosed();
    }
}
