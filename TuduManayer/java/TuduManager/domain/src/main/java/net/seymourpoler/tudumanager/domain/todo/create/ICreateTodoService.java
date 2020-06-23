package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

public interface ICreateTodoService {
    ServiceExecutionResult create(TodoCreationRequest request);
}
