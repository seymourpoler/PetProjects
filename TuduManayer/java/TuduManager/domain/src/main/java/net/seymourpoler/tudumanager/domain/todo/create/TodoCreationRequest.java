package net.seymourpoler.tudumanager.domain.todo.create;

public class TodoCreationRequest {

    public final String title;
    public final String description;

    public TodoCreationRequest(String title, String description) {
        this.title = title;
        this.description = description;
    }
}
