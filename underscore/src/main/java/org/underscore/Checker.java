package org.underscore;

public class Checker {
    public static <T, U> void ifNull(Class<T> clazz, U element)
            throws Throwable {
        if(element == null){
            throw (Throwable) clazz.newInstance();
        }
    }
}
