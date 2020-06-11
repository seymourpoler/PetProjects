package net.seymourpoler.domain.todo.search;

import net.seymourpoler.domain.todo.search.models.Todo;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SearchTodoService implements ISearchTodoService {

    public SearchTodoService(){}

    @Override
    public List<Todo> search(String searchText) {
        throw new RuntimeException();
    }
}
