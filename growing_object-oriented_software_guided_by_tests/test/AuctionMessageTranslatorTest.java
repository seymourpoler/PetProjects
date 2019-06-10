import org.junit.jupiter.api.Test;

public class AuctionMessageTranslatorTest {
    @Test
    public void notifiesAuctionClosedWhenCloseMessageReceived()
    {
        Chat aChat = null;
        AuctionMessageTranslator translator = new AuctionMessageTranslator();
        Message aMessage  = new Message();
        aMessage.setBody("SOLVersion: 1.1; Event: CLOSE;");

        translator.processMessage(aChat, aMessage);
    }
}
