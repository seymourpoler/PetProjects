import org.hamcrest.Matcher;
import sun.reflect.generics.reflectiveObjects.NotImplementedException;

import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.TimeUnit;

public class SingleMessageListener implements MessageListener {
    private ArrayBlockingQueue<Message> messages;

    public SingleMessageListener(){
        messages = new ArrayBlockingQueue<Message>(1);
    }

    public void processMessage(Chat chat, Message message){
        messages.add(message);
    }

    public void receivesAMessage() {
        //assertThat("Message", messages.poll(5, SECONDS), is(notNullValue()));
        throw new NotImplementedException();
    }

    public void receivesAMessage(String message) {
        throw new NotImplementedException();
    }

    public void sendMessage(Message message) {
        throw new NotImplementedException();
    }

    public void receivesAMessage(Matcher<? super String> messageMatcher)
            throws InterruptedException
    {
        final Message message = messages.poll(5, TimeUnit.SECONDS);
        //assert("Message", message, is(notNullValue());
        //assert(message, is(notNullValue());
        //assert(message.getBody(), is(messageMatcher));
    }
}
