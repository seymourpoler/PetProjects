package net.seymourpoler.jDataBaseMigrator;

public class Column {
    private final String name;

    public Column(String name) {
        this.name = name;
    }

    public String toSql(){
        if(name == null || name.equals("") || name.trim().equals("") ){
            throw new IllegalArgumentException();
        }
        throw new RuntimeException();
    }
}
