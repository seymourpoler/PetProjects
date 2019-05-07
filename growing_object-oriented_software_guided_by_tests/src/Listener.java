public class Listener {
    Translator _translator;

    public final static String UNUSED_CHAT = "un-used_chat";
    public final static String MESSAGE_BODY = "SQLVersion: 1.1; Event: CLOSE";

    public Listener(Translator translator) {
        _translator = translator;
    }

    public void auctionClosed(){
        Message message = new Message();
        message.setBody(MESSAGE_BODY);
        _translator.processMessage(UNUSED_CHAT, message);
    }
}
