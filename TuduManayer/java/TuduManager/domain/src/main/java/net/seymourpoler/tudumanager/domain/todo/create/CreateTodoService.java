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
        var errors = validate(request);
        if (!errors.isEmpty()){
            return ServiceExecutionResult.of(errors);
        }

        return createTodo(request);
    }

    private ServiceExecutionResult createTodo(TodoCreationRequest request) {
        var todo = new Todo(request.title, request.description);
        repository.save(todo);
        return ServiceExecutionResult.ok();
    }

    private List<Error> validate(TodoCreationRequest request){
        final String titleField = "title";

        if(request.title == null || request.title.isEmpty() || request.title.trim().isEmpty() ){
            return List.of(new Error(titleField, ErrorCodes.Required));
        }
        if(request.title.length() > MaximumNumberOfCharactersForTitle){
            return List.of(new Error(titleField, ErrorCodes.InvalidLength));
        }
        return List.of();
    }
}
