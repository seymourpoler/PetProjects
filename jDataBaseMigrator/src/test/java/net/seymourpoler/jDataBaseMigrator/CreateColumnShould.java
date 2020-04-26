package net.seymourpoler.jDataBaseMigrator;

import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class CreateColumnShould {
    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_null(){
        var column = new CreateColumn(null);

        column.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_empty(){
        var column = new CreateColumn("");

        column.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_white_space(){
        var column = new CreateColumn("     ");

        column.toSql();
    }

    @Test
    public void
    create_integer_column(){
        var column = new CreateColumn("a_column").asInteger();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column integer");
    }

    @Test
    public void
    create_small_integer_column(){
        var column = new CreateColumn("a_column").asSmallInteger();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column smallint");
    }

    @Test
    public void
    create_big_integer_column(){
        var column = new CreateColumn("a_column").asBigInteger();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column bigint");
    }

    @Test
    public void
    create_string_column(){
        var column = new CreateColumn("a_column").asString();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column varchar");
    }

    @Test
    public void
    create_length_string_column(){
        var column = new CreateColumn("a_column").asString(50);

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column varchar(50)");
    }

    @Test
    public void
    create_boolean_column(){
        var column = new CreateColumn("a_column").asBoolean();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column boolean");
    }

    @Test
    public void
    create_boolean_with_default_value_column(){
        var column = new CreateColumn("a_column").asBoolean(false);

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column boolean default false");
    }

    @Test
    public void
    create_not_null_column(){
        var column = new CreateColumn("a_column").asInteger().notNull();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column integer not null");
    }

    @Test
    public void
    create_primary_key_column(){
        var column = new CreateColumn("a_column").asInteger().asPrimaryKey();

        var result = column.toSql();

        assertThat(result).isEqualTo("a_column integer not null primary key");
    }
}
