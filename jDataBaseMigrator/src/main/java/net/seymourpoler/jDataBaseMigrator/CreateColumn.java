package net.seymourpoler.jDataBaseMigrator;

import java.sql.JDBCType;

public class CreateColumn {
    private final String name;
    private JDBCType type;
    private Integer length;
    private Boolean isNotNull;

    public CreateColumn(String name) {

        this.name = name;
        length = 0;
        isNotNull = false;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(name);
        return name + " " + typeName() + getIsNotNull();
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

    public CreateColumn asString(Integer length) {
        type = JDBCType.VARCHAR;
        this.length = length;
        return this;
    }

    private String typeName(){
        if(length == 0){
            return type.getName().toLowerCase();
        }
        return type.getName().toLowerCase() + "(" + length + ")";
    }

    public CreateColumn asBoolean() {
        type = JDBCType.BOOLEAN;
        return this;
    }

    public CreateColumn notNull() {
        isNotNull = true;
        return this;
    }

    private String getIsNotNull(){
        if(isNotNull){
            return " not null";
        }
        return "";
    }
}
