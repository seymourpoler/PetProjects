using System;

namespace WiMi.Domain.Pages
{
    public interface IPageCreator
    {
        ServiceExecutionResult Create(PageCreationRequest request);
    }

    public class PageCreator : IPageCreator
    {
        public ServiceExecutionResult Create(PageCreationRequest request)
        {

			if(String.IsNullOrWhiteSpace(request.Title))
            {
                return new ServiceExecutionResult(new Error(
                    fieldId: nameof(request.Title), errorCode: nameof(Error.ErrorCodes.Required)));
            }
			if(request.Body is null)
			{
				return new ServiceExecutionResult(new Error(
					fieldId: nameof(request.Body), errorCode: nameof(Error.ErrorCodes.Required)));
			}
            throw new System.NotImplementedException();
        }
    }
}
