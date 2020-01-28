package jascal;

public class StringTool {
    public static Boolean isNullOrWhiteSpace(String text){
        return text == null || text.trim().isEmpty();
    }
}
