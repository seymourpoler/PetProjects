import org.jmock.Expectations;
import org.jmock.Mockery;
import org.junit.Test;

public class AuctionMessageTranslatorTest {
    private Mockery context = new Mockery();
    private AuctionEventListener listener = context.mock(AuctionEventListener.class);
    private AuctionMessageTranslator translator  = new AuctionMessageTranslator(listener);
    private Chat aChat = new Chat();

    @Test
    public void notifiesAuctionClosedWhenCloseMessageReceived(){
        Message message = new Message();
        message.setBody("SOLVersion: 1.1; Event: CLOSE;");

        translator.processMessage(aChat, message);

        context.checking(new Expectations(){{
            oneOf(listener).auctionClosed();
        }});
    }
}
