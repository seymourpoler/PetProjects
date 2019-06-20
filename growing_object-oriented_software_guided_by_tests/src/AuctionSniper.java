public class AuctionSniper implements  AuctionEventListener{

    private Auction auction;
    private SniperListener sniperListener;
    private boolean isWinning;


    public AuctionSniper(
            Auction auction,
            SniperListener sniperListener) {
        this.auction = auction;
        this.sniperListener = sniperListener;
        isWinning = false;
    }

    public void auctionClosed(){
        if(isWinning){
            sniperListener.sniperWon();
        }else {
            sniperListener.sniperLost();
        }
    }

    public void currentPrice(int price, int increment, PriceSource priceSource){
        switch (priceSource) {
            case FromSniper:
                isWinning = true;
                sniperListener.sniperWinning();
                break;
            case FromOtherBidder:
                auction.bid(price + increment);
                sniperListener.sniperBidding();
                break;
        }
    }
}
