package net.seymourpoler;

public class StringUtil {
    public static Boolean isNullOrWhiteSpace(String value){
        if (value == null || value.equals("") || value.trim().equals("")){
            return true;
        }
        throw new RuntimeException();
    }
}
