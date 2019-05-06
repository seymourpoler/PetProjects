import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class Listener {

    Translator _translator;

    public String UNUSED_CHAT = "un-used_chat";

    public Listener(Translator translator) {
        _translator = translator;
    }

    public void auctionClosed(){
        throw new NotImplementedException();
    }
}
