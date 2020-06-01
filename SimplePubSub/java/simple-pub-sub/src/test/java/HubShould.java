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
        hub.subscribe(Message.class, x -> result[0] = x.content);
        var message = new Message(); message.content = contentMessage;

        hub.publish(message);

        assertThat(result[0]).isEqualTo(contentMessage);
    }

    @Test
    public void
    unsubscribe_one_handler()
    {
        final String[] result = {""};
        var contentMessage = "Message";
        hub.subscribe(Message.class, x -> result[0] = x.content);
        hub.subscribe(AnotherMessage.class , x -> result[0] = x.id);
        hub.unSubscribe(Message.class);
        var anotherMessage = new AnotherMessage(); anotherMessage.id = contentMessage;

        hub.publish(anotherMessage);

        assertThat(result[0]).isEqualTo(contentMessage);
    }

    @Test
    public void
    does_nothing_when_there_are_no_handlers()
    {
        var result = "";
        var contentMessage = "Message";
        var message = new Message(); message.content = contentMessage;

        hub.publish(message);

        assertThat(result).isNotEqualTo(contentMessage);
    }

    @Test
    public void
    publish_message_with_some_handlers()
    {
        final String[] result = {""};
        final String[] anotherResult = {""};
        var contentMessage = "Message";
        hub.subscribe(Message.class, x -> result[0] = x.content);
        hub.subscribe(AnotherMessage.class, x -> anotherResult[0] = x.id);
        var message = new Message(); message.content = contentMessage;

        hub.publish(message);

        assertThat(result[0]).isEqualTo(contentMessage);
        assertThat(anotherResult[0]).isEqualTo("");
    }

    @Test
    public void
    unSubscribe_when_there_is_no_handler() {
        final String[] result = {""};
        var contentMessage = "Message";
        hub.subscribe(AnotherMessage.class, x -> result[0] = x.id);
        hub.unSubscribe(Message.class);
        var message = new Message(); message.content = contentMessage;

        hub.publish(message);

    }

    @Test
    public void
    unSubscribe_when_there_are_handlers()
    {
        final String[] result = {""};
        var contentMessage = "Message";
        hub.subscribe(Message.class, x -> result[0] = x.content);
        hub.subscribe(AnotherMessage.class, x -> result[0] = x.id);
        hub.unSubscribe(Message.class);
        var message = new Message(); message.content = contentMessage;

        hub.publish(message);

        assertThat(result[0]).isNotEqualTo(contentMessage);
        assertThat(result[0]).isEqualTo("");
    }

    @Test
    public void
    unSubscribe_one_handler()
    {
        final String[] result = {""};
        var contentMessage = "Message";
        hub.subscribe(Message.class, x -> result[0] = x.content);
        hub.subscribe(AnotherMessage.class, x -> result[0] = x.id);
        hub.unSubscribe(Message.class);
        var anotherMessage = new AnotherMessage(); anotherMessage.id = contentMessage;

        hub.publish(anotherMessage);

        assertThat(result[0]).isEqualTo(contentMessage);
    }


    private class Message
    {
        public String content;
    }

    private class AnotherMessage
    {
        public String id;
    }
}
