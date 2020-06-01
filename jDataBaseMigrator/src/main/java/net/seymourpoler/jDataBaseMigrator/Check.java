package net.seymourpoler.jDataBaseMigrator;

public class Check {
    public static void isNullOrWhiteSpace(String value) {
        if(StringUtil.isNullOrWhiteSpace(value)){
            throw new IllegalArgumentException();
        }
    }
}
