using System.Collections.Generic;
using WiMi.CrossCutting;

namespace WiMi.Domain
{
    public class ServiceExecutionResult
    {
		List<Error> errors;
        public IReadOnlyList<Error> Errors { get { return errors.AsReadOnly(); } }
        public bool IsOk { get { return errors.IsEmpty(); } }

        public ServiceExecutionResult()
        {
            errors = new List<Error>();
        }

        public ServiceExecutionResult(Error error)
        {
            errors = new List<Error> { error };
        }

		public ServiceExecutionResult(List<Error> errors) : this()
        {
			if (errors is null) { return; }
			this.errors = errors;
        }

        public void AddError(Error error)
        {
            if (error is null) { return; }
            errors.Add(error);
        }

        public void AddErrors(IReadOnlyList<Error> errors)
        {
            if(errors is null) { return; }
            if(errors.IsEmpty()) { return; }
			this.errors.AddRange(errors);
        }
    }
}
