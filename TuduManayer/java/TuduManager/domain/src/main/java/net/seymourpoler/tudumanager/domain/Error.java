package net.seymourpoler.tudumanager.domain;

public class Error {
    public final String fieldId;
    public final ErrorCodes errorCode;

    public Error(String fieldId, ErrorCodes errorCode) {
        this.fieldId = fieldId;
        this.errorCode = errorCode;
    }
}
