package jascal;

public class StringsUtils {
    public static Boolean isNullOrWhiteSpace(String text){
        return text == null || text.trim().isEmpty();
    }
}
