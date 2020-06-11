package net.seymourpoler.domain.todo.search;

import org.junit.Before;
import org.junit.Test;

import java.util.List;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;

public class SearchTodoServiceShould {

    private ISearchTodoService service;

    @Before
    public void setUp(){
        service = new SearchTodoService();
    }

    @Test
    public void
    accept_null_search_text(){
        var todos = service.search(null);

        assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    accept_string_empty_search_text(){
        var todos = service.search("");

        assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    accept_white_space_search_text(){
        var todos = service.search("    ");

        assertThat(todos).isEqualTo(List.of());
    }
}
