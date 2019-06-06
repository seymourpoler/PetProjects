public interface MessageListener {
    void receivesAMessage();

    void sendMessage(Message message);

    void processMessage(Chat chat, Message message);

    void receivesAMessage(String message);
}
