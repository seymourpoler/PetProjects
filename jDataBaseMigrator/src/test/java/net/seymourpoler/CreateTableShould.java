package net.seymourpoler;

import net.seymourpoler.CreateTable;
import org.junit.Assert;
import org.junit.Test;

public class CreateTableShould {

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_table_name_is_empty(){
        var createTable = new CreateTable("");

        createTable.toSql();

        Assert.fail("exception expected");
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_table_name_is_white_space(){
        var createTable = new CreateTable("   ");

        createTable.toSql();

        Assert.fail("exception expected");
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_table_name_is_null(){
        var createTable = new CreateTable(null);

        createTable.toSql();

        Assert.fail("exception expected");
    }

    @Test
    public void
    create_table(){
        var createTable = new CreateTable("table_name");

        var result = createTable.toSql();

        Assert.assertEquals("CREATE TABLE table_name;", result);
    }
}
