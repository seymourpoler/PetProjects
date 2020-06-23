package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.search;

import net.seymourpoler.tudumanager.domain.todo.search.ISearchTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

import java.util.List;
import java.util.stream.Collectors;

@Component
public class SearchTodoRepository implements ISearchTodoRepository {

    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    @Autowired
    public SearchTodoRepository(final DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public List<Todo> search(String searchText) {
        final String sql = "select id, title from public.todo where title like '%" + searchText + "%' OR body like '%" + searchText + "%'";

        try(var connection = dataBaseConnectionFactory.create()) {
            return connection
                    .createQuery(sql)
                    .executeAndFetch(Todo.class).stream()
                    .map(x -> new Todo(x.id, x.title))
                    .collect(Collectors.toList());
        }
    }
}
