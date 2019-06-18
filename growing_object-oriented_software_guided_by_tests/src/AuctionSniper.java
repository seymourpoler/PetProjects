public class AuctionSniper implements  AuctionEventListener{
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

    public void currentPrice(int price, int increment, PriceSource priceSource){
        auction.bid(price + increment);
        sniperListener.sniperBidding();
        sniperListener.sniperWinning();
    }
}
