import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

public class AuctionSniperEndToEndTest {

    private FakeAuctionServer auction;
    private ApplicationRunner application;

    @BeforeEach
    public void setUp(){
        auction = new FakeAuctionServer("item54321");
        application = new ApplicationRunner();
    }

    @Test
    public void sniperJoinsAuctionUntilAuctionCloses () throws  Exception {
        auction.startSellingItem();
        application.startBiddingIn(auction);
        auction.hasReceivedJoinRequestedFromSniper();
        auction.announceClosed();
        application.showsSniperHasLostAuction();
    }

    @Test
    public void sniperMakesAHigherBidButLoses() throws Exception{
        auction.startSellingItem();

        application.startBiddingIn(auction);
        auction.hasReceivedJoinRequestedFromSniper(ApplicationRunner.SNIPER_XMPP_ID);

        auction.reportPrice(1000, 98, "other bidder");
        application.hasShownSniperIsBidding();

        auction.hasReceivedBid(1098, application.SNIPER_XMPP_ID);

        auction.announceClosed();
        application.showsSniperHasLostAuction();
    }

    @AfterEach
    public void cleanUp(){
        auction.stop();
        application.stop();
    }
}
