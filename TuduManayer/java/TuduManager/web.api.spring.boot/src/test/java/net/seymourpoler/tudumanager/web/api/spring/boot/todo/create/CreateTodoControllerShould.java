package net.seymourpoler.tudumanager.web.api.spring.boot.todo.create;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import net.seymourpoler.tudumanager.domain.ServiceExecutionResult;
import net.seymourpoler.tudumanager.domain.todo.create.ICreateTodoService;
import org.junit.Before;
import org.junit.Test;
import org.springframework.http.HttpStatus;

import java.util.List;

import static org.assertj.core.api.Assertions.assertThat;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class CreateTodoControllerShould {

    ICreateTodoService service;
    CreateTodoController controller;

    @Before
    public void setUp(){
        service = mock(ICreateTodoService.class);
        controller = new CreateTodoController(service);
    }

    @Test
    public void
    return_bad_request_when_there_are_errors(){
        var errors = List.of(new net.seymourpoler.tudumanager.domain.Error("email", ErrorCodes.Required));
        var errorResult = ServiceExecutionResult.of(errors);
        when(service.create(any())).thenReturn(errorResult);
        var request = new HttpTodoCreationRequest();

        var response = controller.create(request);

        assertThat(response.getStatusCode()).isEqualTo(HttpStatus.BAD_REQUEST);
        assertThat(response.getBody()).isEqualTo(errors);
    }
}
