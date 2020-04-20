public class CreateTable {
    private final String name;

    public CreateTable(String name) {
        this.name = name;
    }

    public String toSql(){
        return "CREATE TABLE " + name + ";";
    }
}
