package net.seymourpoler.domain.todo.search;

import net.seymourpoler.domain.todo.search.models.Todo;

import java.util.List;

public interface ISearchTodoService {
    List<Todo> search(String searchText);
}
