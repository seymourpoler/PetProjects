package org.underscore;

public class Checker {
    public static <TException, TElement> void ifNull(final Class<TException> clazz,
                                                     final TElement element) throws Throwable {
        if(element == null){
            throw (Throwable) clazz.newInstance();
        }
    }
}
