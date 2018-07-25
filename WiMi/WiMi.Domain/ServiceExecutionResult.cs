using System.Collections.Generic;
using WiMi.CrossCutting;

namespace WiMi.Domain
{
    public class ServiceExecutionResult
    {
        List<Error> _errors;
        public IReadOnlyList<Error> Errors { get { return _errors.AsReadOnly(); } }
        public bool IsOk { get { return _errors.IsEmpty(); } }

        public ServiceExecutionResult()
        {
            _errors = new List<Error>();
        }

        public ServiceExecutionResult(Error error)
        {
            _errors = new List<Error> { error };
        }

        public void AddError(Error error)
        {
            if (error is null) { return; }
            _errors.Add(error);
        }

        public void AddErrors(IReadOnlyList<Error> errors)
        {
            if(errors is null) { return; }
            if(errors.IsEmpty()) { return; }
            _errors.AddRange(errors);
        }
    }
}
