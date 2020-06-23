package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.Error;
import net.seymourpoler.tudumanager.domain.ErrorCodes;
import org.assertj.core.api.AssertionsForClassTypes;
import org.junit.Before;
import org.junit.Test;

import java.util.List;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;

public class CreateTodoServiceShould {
    private ICreateTodoService service;

    @Before
    public void setUp(){
        service = new CreateTodoService();
    }

    @Test
    public void
    return_error_when_title_is_null(){
        var request = new TodoCreationRequest(null, null);

        var result = service.create(request);

        assertThat(result.errors().get(0).fieldId).isEqualTo("title");
        assertThat(result.errors().get(0).errorCode).isEqualTo(ErrorCodes.Required);
    }
}
