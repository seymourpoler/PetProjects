public class FakeAuctionServer implements IAuctionServer {
    private String _item;

    FakeAuctionServer(String item){
        _item = item;
    }

    public String getItemId(){
        return _item;
    }

    public void startSellingItem(){
    }

    public void hasReceivedJoinRequestedFromSniper(){
    }

    public void announceClosed(){
    }

    public void stop(){
    }
}
