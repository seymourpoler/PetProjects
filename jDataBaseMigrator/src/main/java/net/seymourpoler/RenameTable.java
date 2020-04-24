package net.seymourpoler;

public class RenameTable {
    private final String oldName;
    private final String newName;

    public RenameTable(String oldName, String newName) {
        this.oldName = oldName;
        this.newName = newName;
    }

    public String toSql(){
        Check.isNullOrWhiteSpace(oldName);
        if(newName == null){
            throw new IllegalArgumentException();
        }
        throw new RuntimeException();
    }
}
