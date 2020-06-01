package net.seymourpoler.jDataBaseMigrator;

import java.sql.JDBCType;

public class CreateColumn {
    private final String name;
    private JDBCType type;
    private Integer length;
    private Boolean isNotNull;
    private Boolean isPrimaryKey;
    private Boolean defaultValue;
    private Integer decimalRealPart;
    private Integer decimalImaginaryPart;

    public CreateColumn(String name) {

        this.name = name;
        length = 0;
        defaultValue = null;
        isNotNull = false;
        isPrimaryKey = false;
        decimalRealPart = 8;
        decimalImaginaryPart = 2;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(name);
        return name + " " + getTypeName() + getIsNotNull() + getDefaultValue() + getIsPrimaryKey();
    }

    private String getDefaultValue() {
        if(defaultValue != null){
            return " default " + defaultValue.toString();
        }
        return "";
    }

    private String getIsPrimaryKey() {
        if(isPrimaryKey) {
            return " primary key";
        }
        return "";
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

    private String getTypeName(){
        if(JDBCType.VARCHAR == type){
            if(length == null) {
                return type.getName().toLowerCase();
            }
            return type.getName().toLowerCase() + "(" + length + ")";
        }
        if(JDBCType.DECIMAL == type || JDBCType.NUMERIC == type){
            return type.getName().toLowerCase() + "(" + decimalRealPart + "," + decimalImaginaryPart + ")";
        }
        return type.getName().toLowerCase();
    }

    public CreateColumn asBoolean() {
        type = JDBCType.BOOLEAN;
        return this;
    }

    public CreateColumn asBoolean(Boolean defaultBooleanValue) {
        type = JDBCType.BOOLEAN;
        this.defaultValue = defaultBooleanValue;
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

    public CreateColumn asPrimaryKey() {
        isNotNull = true;
        isPrimaryKey = true;
        return this;
    }

    public CreateColumn asDateTime() {
        type = JDBCType.TIMESTAMP;
        return this;
    }

    public CreateColumn asMoney() {
        type = JDBCType.DECIMAL;
        decimalRealPart = 12;
        decimalRealPart = 2;

        return this;
    }
}
