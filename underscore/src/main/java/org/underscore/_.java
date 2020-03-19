package org.underscore;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;
import java.util.function.Consumer;
import java.util.function.Function;
import java.util.function.Predicate;

public class _ {

    private static  final Integer noElements = 0;

    public static <T> void each(final List<T> elements, final Consumer<T> consumer) {
        for (T element : elements) {
            consumer.accept(element);
        }
    }

    public static <T> List<T> where(final List<T> elements, final Predicate<T> condition) {
        if (isNull(elements)) {
            return new ArrayList<T>();
        }
        List<T> result = new ArrayList<T>();
        for (T element : elements) {
            if (condition.test(element)) {
                result.add(element);
            }
        }
        return result;
    }

    public static <T, R> List<R> map(final List<T> elements, final Function<T, R> mapper) {
        List<R> result = new ArrayList<R>();
        for (T element : elements) {
            result.add(mapper.apply(element));
        }
        return result;
    }

    public static <T> Optional<T> first(final List<T> elements, final Predicate<T> condition) {
        if(isNull(elements)){
            return Optional.empty();
        }
        for (T element : elements) {
            if (condition.test(element)) {
                return Optional.of(element);
            }
        }
        return Optional.empty();
    }

    public static <T> Optional<T> first(final List<T> elements) {
        if (isNull(elements) || isEmpty(elements)) {
            return Optional.empty();
        }
        return Optional.of(elements.get(0));
    }

    public static <T> List<T> first(final List<T> elements, final Integer numberOfElements) {
        if(isNull(elements)) {
            return Arrays.asList();
        }
        if(isEmpty(elements)){
            return elements;
        }
        if(numberOfElements >= elements.size()){
            return elements;
        }
        if(numberOfElements <= noElements){
            return Arrays.asList();
        }

        List<T> result = new ArrayList<>();

        for (T element: elements){
            if(result.size()<= numberOfElements){
                result.add(element);
            }else{
                return result;
            }
        }
        return result;
    }

    public static <T> Optional<T> last(final List<T> elements) {
        if (isNull(elements) || isEmpty(elements)) {
            return Optional.empty();
        }
        return Optional.of(elements.get(elements.size() - 1));
    }

    public static <T> List<T> last(final List<T> elements, final Integer numberOfElements) {
        if(isNull(elements)) {
            return Arrays.asList();
        }
        if(isEmpty(elements)){
            return elements;
        }
        if(numberOfElements >= elements.size()) {
            return elements;
        }
        if(numberOfElements <= noElements){
            return Arrays.asList();
        }

        List<T> result = new ArrayList<T>();

        for(Integer position=elements.size() - numberOfElements; position < elements.size(); position++){
            result.add((T)elements.get(position));
        }

        return result;
    }

    public static <T> Boolean isEmpty(final List<T> elements) {
        if(isNull(elements)) {
            return true;
        }
        return elements.size() == noElements;
    }

    public static <T> Boolean isNotEmpty(final List<T> elements) {
        return !isEmpty(elements);
    }

    public static <T> Boolean isNull(final List<T> elements) {
        return elements == null;
    }

    public static <T> Boolean isNotNull(final List<T> elements) {
        return !isNull(elements);
    }

    public static Integer sum(final List<Integer> numbers) {
        Integer result = 0;
        for (Integer number : numbers) {
            result = result + number;
        }
        return result;
    }

    public static Integer max(final List<Integer> numbers) {
        Integer result = Integer.MIN_VALUE;
        for (Integer number : numbers) {
            if (number > result) {
                result = number;
            }
        }

        return result;
    }

    public static Integer min(final List<Integer> numbers) {
        Integer result = Integer.MAX_VALUE;
        for (Integer number : numbers) {
            if (number < result) {
                result = number;
            }
        }

        return result;
    }

    public static <T> Integer count(final List<T> elements){
        if(isNull(elements) || isEmpty(elements)) {
            return noElements;
        }
        return elements.size();
    }

    public static <T> List<T> zip(final List<T> first, final List<T> two) {
        throw new RuntimeException();
    }

    public static <T> List<T> reverse(final List<T> elements) {
        List<T> result = new ArrayList<>();
        for (Integer position = elements.size() - 1; position >= 0; position--) {
            result.add(elements.get(position));
        }
        return result;
    }

    public static <T> Boolean any(final List<T> elements, final Predicate<T> condition) {
        for (T element: elements){
            if(condition.test(element)){
                return true;
            }
        }
        return false;
    }

    public static <T> Boolean all(final List<T> elements, final Predicate<T> condition) {
        for (T element: elements){
            if(!condition.test(element)){
                return false;
            }
        }
        return true;
    }

    public static <T> Boolean none(final List<T> elements, final Predicate<T> condition){
        for (T element: elements){
            if(condition.test(element)) {
                return false;
            }
        }
        return true;
    }

    public static void times(final Integer numberOfTimes, final Runnable runnable){
        if(runnable == null){
            throw new IllegalArgumentException();
        }
        for (Integer position = 0; position < numberOfTimes; position++){
            runnable.run();
        }
    }

    public static <T> Boolean include(final List<T> elements, final T includedElement){
        if(elements == null || includedElement == null){
            return false;
        }

        for (T element: elements){
            if(element.equals(includedElement)){
                return true;
            }
        }
        return false;
    }

    public static <T> List<T> union(final List<T> aList, final List<T> anotherList){
        if(isNull(aList) && isNull(anotherList)){
            return Arrays.asList();
        }
        if(isNull(aList) && isNotNull(anotherList)){
            return anotherList;
        }
        if(isNotNull(aList) && isNull(anotherList)){
            return aList;
        }
        List<T> result = new ArrayList<>();
        result.addAll(aList);
        result.addAll(anotherList);
        return result;
    }

    public static  <T> List<T> intersection(final List<T> firstList, final List<T> secondList){
        if(isNull(firstList) || isEmpty(firstList) ||
            isNull(secondList) || isEmpty(secondList)) {
            return Arrays.asList();
        }
        List<T> result = new ArrayList<>();
        for (T element: firstList){
            if(include(secondList, element)){
                result.add(element);
            }
        }
        return result;
    }
}
