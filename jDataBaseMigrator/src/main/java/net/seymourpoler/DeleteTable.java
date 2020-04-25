package net.seymourpoler;

public class DeleteTable {
    private final String name;

    public DeleteTable(String name) {
        this.name = name;
    }

    public String toSql() {
        Check.isNullOrWhiteSpace(name);
        throw new RuntimeException();
    }
}
