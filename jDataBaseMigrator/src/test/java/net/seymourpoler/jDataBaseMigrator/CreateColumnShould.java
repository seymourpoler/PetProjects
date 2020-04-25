package net.seymourpoler.jDataBaseMigrator;

import org.junit.Test;

public class CreateColumnShould {
    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_null(){
        var column = new Column(null);

        column.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_empty(){
        var column = new Column("");

        column.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_white_space(){
        var column = new Column("     ");

        column.toSql();
    }
}
