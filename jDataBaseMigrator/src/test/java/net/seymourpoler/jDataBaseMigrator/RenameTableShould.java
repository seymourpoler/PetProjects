package net.seymourpoler.jDataBaseMigrator;

import org.junit.Test;

import static org.assertj.core.api.Assertions.assertThat;

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

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_old_name_is_white_space(){
        var renameTable = new RenameTable("      ", "new_table");

        renameTable.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_new_name_is_null(){
        var renameTable = new RenameTable("old_table", null);

        renameTable.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_new_name_is_empty(){
        var renameTable = new RenameTable("old_name", "");

        renameTable.toSql();
    }

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_new_name_is_white_space(){
        var renameTable = new RenameTable("old_name", "     ");

        renameTable.toSql();
    }

    @Test
    public void
    return_rename_table_sql(){
        var renameTable = new RenameTable("old_name", "new_name");

        var result = renameTable.toSql();

        assertThat(result).isEqualTo("ALTER TABLE old_name RENAME TO new_name;");
    }
}
