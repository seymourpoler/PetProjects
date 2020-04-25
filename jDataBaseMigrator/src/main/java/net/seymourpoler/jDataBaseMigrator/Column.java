package net.seymourpoler.jDataBaseMigrator;

public class Column {
    private final String name;

    public Column(String name) {
        this.name = name;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(name);
        throw new RuntimeException();
    }
}
