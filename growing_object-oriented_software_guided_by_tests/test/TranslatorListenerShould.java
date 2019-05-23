import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import static org.mockito.Matchers.any;
import static org.mockito.Matchers.eq;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

public class ListenerShould {

    Translator translator;
    Message message;
    Listener listener;

    @BeforeEach public void
    setUp(){
        message = new Message();
        translator = mock(Translator.class);
        listener = new Listener(translator);
    }

    @Test public void
    notifiesAuctionClosedWhenCloseMessageReceived() {
        message.setBody(listener.MESSAGE_BODY);

        listener.auctionClosed();

        verify(translator).processMessage(eq(listener.UNUSED_CHAT), any(Message.class));
    }
}
