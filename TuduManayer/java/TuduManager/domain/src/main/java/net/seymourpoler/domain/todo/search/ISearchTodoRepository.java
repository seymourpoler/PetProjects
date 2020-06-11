package net.seymourpoler.domain.todo.search;

import net.seymourpoler.domain.todo.search.models.Todo;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public interface ISearchTodoRepository {
    List<Todo> search(String searchText);
}
