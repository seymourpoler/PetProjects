package net.seymourpoler.web.api.spring.boot.todo;

import net.seymourpoler.domain.todo.search.ISearchTodoService;
import org.junit.Test;

import static org.mockito.Mockito.mock;

public class SearchTodoControllerShould {

    @Test
    void return_todos() {
        var searchTodoService = mock(ISearchTodoService.class);
        var controller = new SearchTodoController(searchTodoService);
    }
}