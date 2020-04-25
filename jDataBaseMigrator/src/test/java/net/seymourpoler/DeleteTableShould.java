package net.seymourpoler;

import org.junit.Assert;
import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

public class DeleteTableShould {

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_null(){
        var deleteTable = new DeleteTable(null);

        deleteTable.toSql();

        Assert.fail("exception expected");
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_empty(){
        var deleteTable = new DeleteTable("");

        deleteTable.toSql();

        Assert.fail("exception expected");
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_table_name_is_white_space(){
        var createTable = new DeleteTable("   ");

        createTable.toSql();

        Assert.fail("exception expected");
    }

    @Test
    public void
    return_delete_table_sql(){
        var createTable = new DeleteTable("users");

        var result = createTable.toSql();

        assertThat(result).isEqualTo("DELETE TABLE users");
    }
}
