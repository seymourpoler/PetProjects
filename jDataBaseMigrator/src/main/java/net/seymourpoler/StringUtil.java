package net.seymourpoler;

public class StringUtil {
    public static Boolean isNullOrWhiteSpace(String value){
        final String stringEmpty = "";
        return value == null ||
                value.equals(stringEmpty) ||
                value.trim().equals(stringEmpty);
    }
}
