import org.junit.Before;
import org.junit.Test;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;

public class HubShould {

    Hub hub;

    @Before
    public void setUp(){
        hub = new Hub();
    }

    @Test
    public void
    publish_message_with_one_handler(){
        final String[] result = {""};
        final String contentMessage = "Message";
        hub.subscribe(Message.class, x -> result[0] = x.Content);
        var message = new Message(); message.Content = contentMessage;

        hub.publish(message);

        assertThat(result[0]).isEqualTo(contentMessage);
    }

    private class Message
    {
        public String Content;
    }
}
