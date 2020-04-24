package net.seymourpoler;

public class Check {
    public static void isNullOrWhiteSpace(String value) {
        if(value == null || value.equals("") || value.trim().equals("")){
            throw new IllegalArgumentException();
        }
    }
}
