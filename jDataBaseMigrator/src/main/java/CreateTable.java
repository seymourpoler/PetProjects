public class CreateTable {
    private final String name;

    public CreateTable(String name) {
        this.name = name;
    }

    public String toSql(){
        if(name == ""){
            throw new IllegalArgumentException();
        }
        return "CREATE TABLE " + name + ";";
    }
}
