package net.seymourpoler.tudumanager.domain.todo.create.models;

import java.time.LocalDateTime;

public class Todo {
    public String title;
    public String description;
    public LocalDateTime creationDate;
    public LocalDateTime updatedDate;

    public Todo(String title, String description) {
        this.title = title;
        this.description = description;
        creationDate = LocalDateTime.now();
        updatedDate = null;
    }
}
