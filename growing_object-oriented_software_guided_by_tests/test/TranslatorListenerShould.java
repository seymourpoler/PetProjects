import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;


public class TranslatorListenerShould {

    @Mock
    Translator translator;
    Message message;
    Listener listener;


    @BeforeEach
    public void setUp(){
        message = new Message();
        translator = new Translator();
        listener = new Listener(translator);
    }

    @Test
    public void
    notifiesAuctionClosedWhenCloseMessageReceived() {
        message.setBody("SQLVersion: 1.1; Event: CLOSE");

        listener.auctionClosed();

        translator.processMessage(listener.UNUSED_CHAT, message);
    }
}
