package net.seymourpoler.domain.todo.search;

import org.junit.Test;

import java.util.List;

import static org.assertj.core.api.AssertionsForInterfaceTypes.assertThat;

public class SearchTodoServiceShould {

    @Test
    public void
    accept_null_search_text(){
        var service = new SearchTodoService();

        var todos = service.search(null);

        assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    accept_string_empty_search_text(){
        var service = new SearchTodoService();

        var todos = service.search("");

        assertThat(todos).isEqualTo(List.of());
    }

    @Test
    public void
    accept_white_space_search_text(){
        var service = new SearchTodoService();

        var todos = service.search("    ");

        assertThat(todos).isEqualTo(List.of());
    }
}
