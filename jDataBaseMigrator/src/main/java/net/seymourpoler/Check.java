package net.seymourpoler;

public class Check {
    public static void isNullOrWhiteSpace(String value) {
        if(value == null || value.equals("")){
            throw new IllegalArgumentException();
        }
        throw new RuntimeException();
    }
}
