package net.seymourpoler;

import org.junit.Test;

public class RenameTableShould {
    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_old_name_is_null(){
        var renameTable = new RenameTable(null, "new_table");

        renameTable.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_old_name_is_empty(){
        var renameTable = new RenameTable("", "new_table");

        renameTable.toSql();
    }
}
