package org.underscore;

import java.util.List;
import java.util.function.Function;

public class Underscore<T> {
    List<T> elements;

    public Underscore(List<T> elements){
        this.elements = elements;
    }

    public <T, R> Underscore<R>  map(Function<T, R> function){
        throw new RuntimeException();
    }

    public <T> Underscore<T> filter(Function<T, Boolean> condition){
        throw new RuntimeException();
    }

    public List<T> result(){
        return elements;
    }
}
