package net.seymourpoler;

public class DeleteTable {
    private final String name;

    public DeleteTable(String name) {
        this.name = name;
    }

    public String toSql() {
        if(name == null || name == "" || name == "   "){
            throw new IllegalArgumentException();
        }
        throw new RuntimeException();
    }
}
