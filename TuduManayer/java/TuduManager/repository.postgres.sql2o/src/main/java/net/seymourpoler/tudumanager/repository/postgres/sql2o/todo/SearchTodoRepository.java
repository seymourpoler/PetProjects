package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo;

import net.seymourpoler.tudumanager.domain.todo.search.ISearchTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class SearchTodoRepository implements ISearchTodoRepository {

    @Override
    public List<Todo> search(String searchText) {
        throw new RuntimeException();
    }
}
