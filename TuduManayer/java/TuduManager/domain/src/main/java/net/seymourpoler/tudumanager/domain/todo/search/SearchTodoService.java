package net.seymourpoler.tudumanager.domain.todo.search;

import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;

@Component
public class SearchTodoService implements ISearchTodoService {

    private final ISearchTodoRepository repository;

    @Autowired
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
