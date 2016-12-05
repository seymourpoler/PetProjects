using System.Collections.Generic;
using Infrestructura.Extensions;

namespace Infrestructura
{
    public class CreationResult<T>  where T : class
    {
        public IReadOnlyCollection<ValidationError> Errors { get; }
        public T Model { get; }

        public CreationResult(IReadOnlyCollection<ValidationError> errors)
        {
            Errors = errors;
        }

        public CreationResult(T model)
        {
            Model = model;
        }

        public bool IsValid
        {
            get { return Errors.IsEmpty(); }
        }
    }

    public class ValidationError
    {
        public string FieldId { get; }
        public ValidationErrorType ErrorType { get; }

        public ValidationError(string fieldId, ValidationErrorType errorType)
        {
            FieldId = fieldId;
            ErrorType = errorType;
        }
    }

    public enum ValidationErrorType
    {
        Required,
        WrongLength
    }
}
