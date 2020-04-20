import org.junit.Assert;
import org.junit.Test;

public class DeleteTableShould {

    @Test(expected = IllegalArgumentException.class)
    public void
    throw_exception_when_name_is_null(){
        var deleteTable = new DeleteTable(null);

        deleteTable.toSql();

        Assert.fail("exception expected");
    }

}
