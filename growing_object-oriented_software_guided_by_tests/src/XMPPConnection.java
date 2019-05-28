import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class XMPPConnection {

    private final String hostName;

    public XMPPConnection(String hostName){
        this.hostName = hostName;
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
