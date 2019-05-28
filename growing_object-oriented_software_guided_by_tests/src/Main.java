import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class Main {

    private static final int ARG_HOSTNAME = 0;
    private static final int ARG_USERNAME = 1;
    private static final int ARG_PASSWORD = 2;
    private static final int ARG_ITEM_ID = 3;

    public static void main(String[] args){
        XMPPConnection connection = new XMPPConnection(args[ARG_HOSTNAME]);
        connection.connect();
        connection.login(
            args[ARG_USERNAME],
            args[ARG_PASSWORD],
            args[ARG_ITEM_ID]);

        Chat chat = connection.getChatManager().createChat(
                args[ARG_ITEM_ID],
                new SingleMessageListener(){
                    public void processMessage(Chat aChat, Message message){
                        throw new NotImplementedException();
                    }
                });
        chat.sendMessage(new Message());
    }
}
