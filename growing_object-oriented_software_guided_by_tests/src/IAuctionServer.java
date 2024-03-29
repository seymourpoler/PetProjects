public interface IAuctionServer {
    String getItemId();
    void hasReceivedJoinRequestedFromSniper();
    void announceClosed();
    void stop();
    void reportPrice(int price, int anotherPrice, String bidder) throws XMPPException;
    void hasReceivedBid(int price, String SniperXmppId);
}
