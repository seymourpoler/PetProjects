import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class XMPPConnection {

    private final String connectionString;

    public XMPPConnection(String connectionString){
        this.connectionString = connectionString;
    }

    public void connect(){}
    public void login(String login, String password, String resource){
    }

    public ChatManager getChatManager(){
        throw new NotImplementedException();
    }

    public void disconnect() {
        throw new NotImplementedException();
    }
}
