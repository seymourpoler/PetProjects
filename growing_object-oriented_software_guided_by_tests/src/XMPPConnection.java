import sun.reflect.generics.reflectiveObjects.NotImplementedException;

public class XMPPConnection {

    private final String hostName;
    private String login;

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

    public String getServiceName(){
        throw new NotImplementedException();
    }

    public String getUser(){
        return login;
    }
}
