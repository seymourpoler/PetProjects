public interface IAuctionServer {
    String getItemId();
    void hasReceivedJoinRequestedFromSniper();
    void announceClosed();
    void stop();
}
