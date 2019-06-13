import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class SingleAuctionEventListener implements AuctionEventListener {

    public void auctionClosed() {
        throw new NotImplementedException();
    }

    public void currentPrice(int price, int increment) {
        throw new NotImplementedException();
    }
}
