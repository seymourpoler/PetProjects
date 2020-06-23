package net.seymourpoler.tudumanager.domain.todo.create;

import net.seymourpoler.tudumanager.domain.ErrorCodes;
import org.junit.Before;
import org.junit.Test;

import java.util.Random;

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

    @Test
    public void
    return_error_when_title_is_empty(){
        var request = new TodoCreationRequest("", null);

        var result = service.create(request);

        assertThat(result.errors().get(0).fieldId).isEqualTo("title");
        assertThat(result.errors().get(0).errorCode).isEqualTo(ErrorCodes.Required);
    }

    @Test
    public void
    return_error_when_title_is_white_space(){
        var request = new TodoCreationRequest("   ", null);

        var result = service.create(request);

        assertThat(result.errors().get(0).fieldId).isEqualTo("title");
        assertThat(result.errors().get(0).errorCode).isEqualTo(ErrorCodes.Required);
    }

    @Test
    public void
    return_error_when_title_is_longer_than_maximum_number_of_characters(){
        final String title = generate(CreateTodoService.MaximumNumberOfCharactersForTitle + 1);
        var request = new TodoCreationRequest(title, null);

        var result = service.create(request);

        assertThat(result.errors().get(0).fieldId).isEqualTo("title");
        assertThat(result.errors().get(0).errorCode).isEqualTo(ErrorCodes.InvalidLength);
    }

    private String generate(Integer numberOfCharacters){
        final int letter_a = 97;
        final int letter_z = 122;
        Random random = new Random();
        StringBuilder buffer = new StringBuilder(numberOfCharacters);
        for (int i = 0; i < numberOfCharacters; i++) {
            int randomLimitedInt = letter_a + (int)(random.nextFloat() * (letter_z - letter_a + 1));
            buffer.append((char) randomLimitedInt);
        }
        return buffer.toString();
    }
}
