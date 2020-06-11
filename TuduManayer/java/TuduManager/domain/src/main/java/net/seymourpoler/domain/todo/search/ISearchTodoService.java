package net.seymourpoler.domain.todo.search;

import net.seymourpoler.domain.todo.search.models.Todo;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public interface ISearchTodoService {
    List<Todo> search(String searchText);
}
