package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;

import java.util.List;

public class CreateTodoService implements ICreateTodoService {
    @Override
    public ServiceExecutionResult create(TodoCreationRequest request) {

        if(request.title == null){
            return ServiceExecutionResult.of(List.of(new Error("title", ErrorCodes.Required)));
        }
        throw new RuntimeException();
    }
}
