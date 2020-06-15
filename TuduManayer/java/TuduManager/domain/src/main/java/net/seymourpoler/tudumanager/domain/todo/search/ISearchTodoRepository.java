package net.seymourpoler.tudumanager.domain.todo.search;

import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public interface ISearchTodoRepository {
    List<Todo> search(String searchText);
}
