package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo;

import net.seymourpoler.tudumanager.domain.todo.search.ISearchTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.search.models.Todo;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.stereotype.Repository;

import java.util.List;

@Repository
public class SearchTodoRepository implements ISearchTodoRepository {

    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    public SearchTodoRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public List<Todo> search(String searchText) {
        throw new RuntimeException();
    }
//
//    @Override
//    public List<net.seymourpoler.user.application.find.User> find() {
//        try(var connection = dataBaseConnectionFactory.create()){
//            return connection
//                    .createQuery("select * from public.users")
//                    .executeAndFetch(User.class).stream()
//                    .map(x -> new net.seymourpoler.user.application.find.User(x.id, x.email))
//                    .collect(Collectors.toList());
//        }
//    }
}
