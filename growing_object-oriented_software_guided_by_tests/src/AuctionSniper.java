public class AuctionSniper {
    private SniperListener sniperListener;

    public AuctionSniper(SniperListener sniperListener) {
        this.sniperListener = sniperListener;
    }

    public void auctionClosed(){
        sniperListener.sniperLost();
    }
}
