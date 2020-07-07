package net.seymourpoler.tudumanager.repository.postgres.sql2o;

import org.springframework.stereotype.Component;

@Component
public class DataBaseConfiguration {

    //TODO: move to Application.properties or Postgres.properties or ...
    public String url(){
        return "jdbc:postgresql://localhost:5432/TuduManager";
    }

    public String user(){
        return "admin";
    }

    public String password(){
        return "1234";
    }
}
