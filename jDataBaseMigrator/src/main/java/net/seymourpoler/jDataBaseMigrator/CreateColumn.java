package net.seymourpoler.jDataBaseMigrator;

import java.sql.JDBCType;

public class CreateColumn {
    private final String name;
    private JDBCType type;
    public CreateColumn(String name) {
        this.name = name;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(name);
        return name + " integer";
    }

    public CreateColumn asInteger() {
        type = JDBCType.INTEGER;
        return this;
    }
}
