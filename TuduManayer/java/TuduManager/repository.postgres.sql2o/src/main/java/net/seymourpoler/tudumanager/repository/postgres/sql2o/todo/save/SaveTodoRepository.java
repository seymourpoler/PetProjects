package net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.save;

import net.seymourpoler.tudumanager.domain.todo.create.ISaveTodoRepository;
import net.seymourpoler.tudumanager.domain.todo.create.models.Todo;
import net.seymourpoler.tudumanager.repository.postgres.sql2o.DataBaseConnectionFactory;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;

@Component
public class SaveTodoRepository implements ISaveTodoRepository {
    private final DataBaseConnectionFactory dataBaseConnectionFactory;

    @Autowired
    public SaveTodoRepository(DataBaseConnectionFactory dataBaseConnectionFactory) {
        this.dataBaseConnectionFactory = dataBaseConnectionFactory;
    }

    @Override
    public void save(Todo todo) {
        final String sql = "INSERT INTO public.todo (title, description, creation_date) VALUES (:email, :description, :creation_date)";
        var dbModel = buildFrom(todo);
        try (var connection = dataBaseConnectionFactory.create()) {
            connection
                    .createQuery(sql)
                    .bind(dbModel)
                    .executeUpdate();
        }
    }

    private net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.save.models.Todo buildFrom(Todo todo) {
        var result = new net.seymourpoler.tudumanager.repository.postgres.sql2o.todo.save.models.Todo();
        result.title = todo.title;
        result.description = todo.description;
        result.creation_date = todo.creationDate;
        return result;
    }
}
