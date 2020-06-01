import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.function.Consumer;

public class Hub {
    private final Map<Class, List<Consumer>> handlers;

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
        if(isNotContainHandlersFor(event)){return;}

        handlers.get(event.getClass()).stream()
            .forEach(handler -> handler.accept(event));
    }

    private <T> boolean isNotContainHandlersFor(T event) {
        return !handlers.containsKey(event.getClass());
    }
}
