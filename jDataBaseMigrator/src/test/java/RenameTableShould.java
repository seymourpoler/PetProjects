import org.junit.Assert;
import org.junit.Test;

public class RenameTableShould {
    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_old_name_is_null(){
        var renameTable = new RenameTable(null, "new_table");

        renameTable.toSql();

        Assert.fail("exception expected");
    }
}
