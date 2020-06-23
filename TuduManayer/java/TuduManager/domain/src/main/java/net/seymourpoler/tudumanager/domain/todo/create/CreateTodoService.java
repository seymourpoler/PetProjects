package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.todo.create.models.Todo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class CreateTodoService implements ICreateTodoService {
    public static final Integer MaximumNumberOfCharactersForTitle = 250;

    private final ISaveTodoRepository repository;

    @Autowired
    public CreateTodoService(ISaveTodoRepository saveTodoRepository) {
        this.repository = saveTodoRepository;
    }

    @Override
    public ServiceExecutionResult create(TodoCreationRequest request) {

        if(request.title == null || request.title.isEmpty() || request.title.trim().isEmpty() ){
            return ServiceExecutionResult.of(List.of(new Error("title", ErrorCodes.Required)));
        }

        if(request.title.length() > MaximumNumberOfCharactersForTitle){
            return ServiceExecutionResult.of(List.of(new Error("title", ErrorCodes.InvalidLength)));
        }

        var todo = new Todo(request.title, request.description);
        repository.save(todo);
        return ServiceExecutionResult.ok();
    }
}
