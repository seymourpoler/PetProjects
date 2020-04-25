package net.seymourpoler.jDataBaseMigrator;

import org.junit.Test;

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
}
