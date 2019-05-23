import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class ApplicationRunner {

    private static final String XMPP_HOSTNAME = "xmpp_server_host_name";
    private static final String SNIPER_ID = "sniper";
    private static final String SNIPER_PASSWORD = "password";
    private static final String STATUS_JOINING = "joining";

    private AuctionSniperDriver driver;
    private XMPPMessageSender messageSender;

    public  ApplicationRunner(){
        driver = new AuctionSniperDriver();
        messageSender = new XMPPMessageSender();
    }

    public void startBiddingIn(final IAuctionServer auction){
        messageSender.send(XMPP_HOSTNAME, SNIPER_ID, SNIPER_PASSWORD, auction.getItemId());
        driver.showsSniperStatus(STATUS_JOINING);
    }

    public void showsSniperHasLostAuction(){
        throw new NotImplementedException();
    }

    public void stop(){
        throw new NotImplementedException();
    }
}