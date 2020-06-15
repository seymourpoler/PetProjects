package net.seymourpoler.tudumanager.domain.todo.search;

import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public interface ISearchTodoService {
    List<Todo> search(String searchText);
}
