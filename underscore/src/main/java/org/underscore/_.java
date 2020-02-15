package org.underscore;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;

public class _ {
    public static <T> void each(List<T> elements, Consumer<T> consumer){
        for(T element: elements){
            consumer.accept(element);
        }
    }

    public static <T> List<T> where(List<T> elements, Function<T, Boolean> condition){
        List<T> result = new ArrayList<T>();
        for (T element: elements){
            if(condition.apply(element)){
                result.add(element);
            }
        }
        return result;
    }

    public static <T> List<T> where(List<T> elements, Predicate<T> condition){
        List<T> result = new ArrayList<T>();
        for (T element: elements){
            if(condition.test(element)){
                result.add(element);
            }
        }
        return result;
    }

    public static <T> Optional<T> find(List<T> elements, Function<T, Boolean> condition){
        for (T element: elements){
            if (condition.apply(element)) {
                return Optional.of(element);
            }
        }
        return Optional.empty();
    }

    public static <T, R> List<R> map(List<T> elements, Function<T, R> mapper){
        List<R> result = new ArrayList<R>();
        for (T element: elements) {
            result.add(mapper.apply(element));
        }
        return result;
    }

    public static <T> Optional<T> first(List<T> elements){
        if(isNull(elements) || isEmpty(elements)){
            return Optional.empty();
        }
        return Optional.of(elements.get(0));
    }

    public static <T> Optional<T> last(List<T> elements){
        if(isNull(elements) || isEmpty(elements)){
            return Optional.empty();
        }
        return Optional.of(elements.get(elements.size() -1));
    }

    public static <T> Boolean isEmpty(List<T> elements){
        final Integer hasNoElements = 0;
        return elements.size() == hasNoElements;
    }

    public static <T> Boolean isNotEmpty(List<T> elements){
        return !isEmpty(elements);
    }

    public static <T> Boolean isNull(List<T> elements){
        return elements == null;
    }

    public static <T> Boolean isNotNull(List<T> elements){
        return !isNull(elements);
    }

    public static Integer sum(List<Integer> numbers) {
        Integer result = 0;
        for (Integer number: numbers){
            result = result + number;
        }
        return result;
    }

    public static Integer max(List<Integer> numbers) {
        throw new RuntimeException();
    }
}
