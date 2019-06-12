import org.jmock.Expectations;
import org.jmock.Mockery;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.junit.runners.JUnit4;

@RunWith(JUnit4.class)
public class AuctionSniperTest {
    private final Mockery context = new Mockery();
    private final SniperListener sniperListener = context.mock(SniperListener.class);
    private final AuctionSniper sniper = new AuctionSniper(sniperListener);

    @Test
    public void reportsLostWhenAuctionCloses(){
            context.checking(new Expectations() {{
                one(sniperListener).sniperLost();
            }});
            sniper.auctionClosed();
    }

}
