using System;
using System.Collections.Generic;
using WiMi.CrossCutting.Extensions;

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
			var errors = new List<Error>();
			if(String.IsNullOrWhiteSpace(request.Title))
            {
				errors.Add(
					new Error(fieldId: nameof(request.Title), errorCode: nameof(Error.ErrorCodes.Required)));
            }
			if(String.IsNullOrWhiteSpace(request.Body))
			{
				errors.Add(
					new Error(fieldId: nameof(request.Body), errorCode: nameof(Error.ErrorCodes.Required)));
			}
			if(errors.IsNotEmpty())
			{
				return new ServiceExecutionResult(errors);
			}
			var page = new Page(title: request.Title, body: request.Body);
			repository.Save(page);
			return new ServiceExecutionResult();
        }
    }
}
