package net.seymourpoler.jDataBaseMigrator;

public class CreateColumn {
    private final String name;

    public CreateColumn(String name) {
        this.name = name;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(name);
        throw new RuntimeException();
    }

    public CreateColumn asInteger() {
        throw new RuntimeException();
    }
}
