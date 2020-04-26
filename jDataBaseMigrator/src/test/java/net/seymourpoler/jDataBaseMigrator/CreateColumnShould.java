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
}
