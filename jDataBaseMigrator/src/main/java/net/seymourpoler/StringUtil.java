package net.seymourpoler;

public class StringUtil {
    public static Boolean isNullOrWhiteSpace(String value){
        if (value == null || value == ""){
            return true;
        }
        throw new RuntimeException();
    }
}
