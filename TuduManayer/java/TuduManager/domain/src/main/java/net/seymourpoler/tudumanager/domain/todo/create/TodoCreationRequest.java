package net.seymourpoler.tudumanager.domain.todo.create;

public class TodoCreationRequest {

    private final String title;
    private final String description;

    public TodoCreationRequest(String title, String description) {
        this.title = title;
        this.description = description;
    }
}
