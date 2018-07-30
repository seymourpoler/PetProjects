using System;

namespace WiMi.Domain.Pages.Create
{
    public class PageCreator : IPageCreator
    {
		readonly IPageRepository repository;

		public PageCreator(IPageRepository repository)
		{
			this.repository = repository;
		}

        public ServiceExecutionResult Create(PageCreationRequest request)
        {
			var result = new ServiceExecutionResult();
			if(String.IsNullOrWhiteSpace(request.Title))
            {
				result.AddError(
					new Error(fieldId: nameof(request.Title), errorCode: nameof(Error.ErrorCodes.Required)));
            }
			if(String.IsNullOrWhiteSpace(request.Body))
			{
                result.AddError(
					new Error(fieldId: nameof(request.Body), errorCode: nameof(Error.ErrorCodes.Required)));
			}

			if(!result.IsOk)
			{
                return result;
			}
			var page = new Page(title: request.Title, body: request.Body);
			repository.Save(page);
			return new ServiceExecutionResult();
        }
    }
}
