package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

import java.util.List;

public class CreateTodoService implements ICreateTodoService {
    public static final Integer MaximumNumberOfCharactersForTitle = 250;

    @Override
    public ServiceExecutionResult create(TodoCreationRequest request) {

        if(request.title == null || request.title.isEmpty()){
            return ServiceExecutionResult.of(List.of(new Error("title", ErrorCodes.Required)));
        }

        if(request.title.length() > MaximumNumberOfCharactersForTitle){
            return ServiceExecutionResult.of(List.of(new Error("title", ErrorCodes.InvalidLength)));
        }

        throw new RuntimeException();
    }
}
