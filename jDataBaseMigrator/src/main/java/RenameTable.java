public class RenameTable {
    private final String oldName;
    private final String newTable;

    public RenameTable(String oldName, String newTable) {
        this.oldName = oldName;
        this.newTable = newTable;
    }

    public String toSql(){
        if(oldName == null){
            throw new IllegalArgumentException();
        }
        throw new RuntimeException();
    }
}
