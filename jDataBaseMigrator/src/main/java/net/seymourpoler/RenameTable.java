package net.seymourpoler;

public class RenameTable {
    private final String oldName;
    private final String newTable;

    public RenameTable(String oldName, String newTable) {
        this.oldName = oldName;
        this.newTable = newTable;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(oldName);
            throw new RuntimeException();
    }
}
