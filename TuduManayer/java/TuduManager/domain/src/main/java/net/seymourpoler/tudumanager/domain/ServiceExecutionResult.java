package net.seymourpoler.tudumanager.domain;

import java.util.List;

public class ServiceExecutionResult {
    private final List<Error> errors;

    private ServiceExecutionResult(List<Error> errors){
        this.errors = errors;
    }

    private ServiceExecutionResult(){
        this.errors = List.of();
    }

    public Boolean isOk(){
        return errors.isEmpty();
    }

    public List<Error> errors(){
        return errors;
    }

    public static ServiceExecutionResult of(List<Error> errors){
        return new ServiceExecutionResult(errors);
    }

    public static ServiceExecutionResult ok(){
        return new ServiceExecutionResult();
    }
}
