import java.util.*;

public class SnipersTableModel {
    private List<TableModelListener> listeners;

    public void SniperTableModel(){
        listeners = new ArrayList<TableModelListener>();
    }

    public void addTableModelListener(TableModelListener listener){
        listeners.add(listener);
    }

    public int getColumnCount(){
        return Column.values().length;
    }
}
