package net.seymourpoler.tudumanager.domain.todo.search;

import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import org.assertj.core.api.AssertionsForInterfaceTypes;
import org.junit.Before;
import org.junit.Test;

import java.util.List;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;
import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.when;

public class SearchTodoServiceShould {

    private ISearchTodoRepository repository;

    private ISearchTodoService service;

    @Before
    public void setUp(){
        repository = mock(ISearchTodoRepository.class);
        service = new SearchTodoService(repository);
    }

    @Test
    public void
    accept_null_search_text(){
        var todos = service.search(null);

        AssertionsForInterfaceTypes.assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    accept_string_empty_search_text(){
        var todos = service.search("");

        AssertionsForInterfaceTypes.assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    accept_white_space_search_text(){
        var todos = service.search("    ");

        AssertionsForInterfaceTypes.assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    return_todos_by_search_text(){
        final String searchText = "search-text";
        var todos = List.of(new Todo(1, "title"));
        when(repository.search(searchText)).thenReturn(todos);

        var result = service.search(searchText);

        AssertionsForInterfaceTypes.assertThat(result).isEqualTo(todos);
    }
}
