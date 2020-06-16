package net.seymourpoler.tudumanager.repository.postgres.sql2o;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Component;
import org.sql2o.Connection;
import org.sql2o.Sql2o;

@Component
public class DataBaseConnectionFactory {
    private final DataBaseConfiguration dataBaseConfiguration;

    @Autowired
    public DataBaseConnectionFactory(DataBaseConfiguration dataBaseConfiguration) {
        this.dataBaseConfiguration = dataBaseConfiguration;
    }

    public Connection create(){
        return new Sql2o(dataBaseConfiguration.url(),
                dataBaseConfiguration.user(),
                dataBaseConfiguration.password()).open();
    }
}
