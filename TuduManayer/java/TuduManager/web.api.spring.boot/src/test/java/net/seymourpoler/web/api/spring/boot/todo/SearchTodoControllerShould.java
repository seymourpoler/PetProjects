package net.seymourpoler.web.api.spring.boot.todo;

import net.seymourpoler.domain.todo.search.ISearchTodoService;
import net.seymourpoler.domain.todo.search.models.Todo;
import org.junit.Test;

import java.util.List;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class SearchTodoControllerShould {

    @Test
    public void return_todos() {
        var searchTodoService = mock(ISearchTodoService.class);
        final String searchText = "search text";
        var todos = List.of(new Todo());
        when(searchTodoService.search(searchText)).thenReturn(todos);
        var controller = new SearchTodoController(searchTodoService);

        var result = controller.seach(searchText);

        assertThat(result.getBody()).isEqualTo(todos);
    }
}