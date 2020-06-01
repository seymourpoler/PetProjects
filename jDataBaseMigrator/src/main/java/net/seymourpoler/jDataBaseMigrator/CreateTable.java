package net.seymourpoler.jDataBaseMigrator;

public class CreateTable {
    private final String name;

    public CreateTable(String name) {
        this.name = name;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(name);
        return "CREATE TABLE " + name + ";";
    }
}
