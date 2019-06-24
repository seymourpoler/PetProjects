import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.runner.RunWith;
import org.jmock.Mockery;
import org.junit.runners.JUnit4;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.Matchers.equalTo;

@RunWith(JUnit4.class)
public class SnipersTableModelTest {
    private Mockery context = new Mockery();
    private TableModelListener listener;
    private SnipersTableModel model;

    @BeforeEach
    public void setUp() {
        listener = context.mock(TableModelListener.class);
        model = new SnipersTableModel();
        model.addTableModelListener(listener);
    }

    @Test
    public void hasEnoughColumns(){
        assertThat(model.getColumnCount(), equalTo(Column.values().length));
    }
}
