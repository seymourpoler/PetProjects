package net.seymourpoler.tudumanager.web.api.spring.boot.todo.create;

import net.seymourpoler.tudumanager.domain.todo.create.ICreateTodoService;
import net.seymourpoler.tudumanager.domain.todo.create.TodoCreationRequest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class CreateTodoController {
    private final ICreateTodoService service;

    public CreateTodoController(ICreateTodoService createTodoService) {
        this.service = createTodoService;
    }

    public ResponseEntity create(HttpTodoCreationRequest request){
        var creationRequest = new TodoCreationRequest(request.title, request.description);
        var creationResult = service.create(creationRequest);

        if(creationResult.isOk()){
            return new ResponseEntity(HttpStatus.OK);
        }
        return new ResponseEntity(creationResult.errors(), HttpStatus.BAD_REQUEST);
    }
}
