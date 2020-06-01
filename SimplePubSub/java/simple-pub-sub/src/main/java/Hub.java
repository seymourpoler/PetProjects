import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.function.Consumer;

public class Hub {
    private Map<Class, List<Consumer>> handlers;

    public Hub() {
        this.handlers = new HashMap<>();
    }

    public <T> void subscribe(Class<T> eventType, Consumer<T> handler) {
        this.handlers.put(eventType , List.of(handler));
    }

    public <T> void unSubscribe(Class<T> eventType) {
        this.handlers.remove(eventType);
    }

    public <T> void publish(T event) {
        var currentHandlers = this.handlers.get(event.getClass());
        if(currentHandlers == null){ return; }
        
        for (var handler: currentHandlers) {
            handler.accept(event);
        }
    }
}
