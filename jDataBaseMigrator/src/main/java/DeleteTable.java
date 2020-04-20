public class DeleteTable {
    private final String name;

    public DeleteTable(String name) {
        this.name = name;
    }

    public String toSql() {
        throw new RuntimeException();
    }
}
