package net.seymourpoler.domain.todo.search;

import net.seymourpoler.domain.todo.search.models.Todo;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class SearchTodoService implements ISearchTodoService {

    private final ISearchTodoRepository repository;

    public SearchTodoService(ISearchTodoRepository repository) {
        this.repository = repository;
    }

    @Override
    public List<Todo> search(String searchText) {

        if(isNotValid(searchText)){
            return List.of();
        }

        return repository.search(searchText);
    }

    private boolean isNotValid(String searchText) {
        return searchText == null || isWhiteSpace(searchText);
    }


    private boolean isWhiteSpace(String searchText) {
        return searchText.replaceAll("\\s+", "").isEmpty();
    }
}
