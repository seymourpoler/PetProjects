import sun.reflect.generics.reflectiveObjects.NotImplementedException;
import java.util.concurrent.ArrayBlockingQueue;

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

    public void sendMessage(Message message) {

    }
}
