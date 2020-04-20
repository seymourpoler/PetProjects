import org.junit.Assert;
import org.junit.Test;

public class CreateTableShould {

    @Test
    public void
    create_table(){
        var createTable = new CreateTable("table_name");
        var result = createTable.toSql();

        Assert.assertEquals("CREATE TABLE table_name;", result);
    }
}
