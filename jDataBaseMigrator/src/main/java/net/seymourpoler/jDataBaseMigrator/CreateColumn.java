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
        return name + " " + type.toString().toLowerCase();
    }

    public CreateColumn asInteger() {
        type = JDBCType.INTEGER;
        return this;
    }

    public CreateColumn asSmallInteger() {
        type = JDBCType.SMALLINT;
        return this;
    }

    public CreateColumn asBigInteger() {
        type = JDBCType.BIGINT;
        return this;
    }

    public CreateColumn asString() {
        type = JDBCType.VARCHAR;
        return this;
    }
}
