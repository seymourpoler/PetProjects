import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class AuctionSniper {

    private Auction auction;
    private SniperListener sniperListener;

    public AuctionSniper(
            Auction auction,
            SniperListener sniperListener) {
        this.auction = auction;
        this.sniperListener = sniperListener;
    }

    public void auctionClosed(){
        sniperListener.sniperLost();
    }

    public void currentPrice(int price, int increment){
        auction.bid(price + increment);
        sniperListener.sniperBidding();
    }
}
