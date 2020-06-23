package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.todo.create.models.Todo;

public interface ISaveTodoRepository {
    void save(Todo todo);
}
