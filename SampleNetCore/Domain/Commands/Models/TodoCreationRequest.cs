using Infrestructura;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Domain.Commands.Models
{
    public class TodoCreationRequest
    {
        private const int maximumNumberOfCharactersForTitle = 50;
        private const int maximumNumberOfCharactersForDescription = 100;

        public string Title { get; }
        public string Description { get; }

        private TodoCreationRequest(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public static CreationResult<TodoCreationRequest> Create(string title, string description)
        {
            var errors = new List<ValidationError>();
            if (String.IsNullOrWhiteSpace(title))
            {
                errors.Add(new ValidationError("title", ValidationErrorType.Required));
            }
            else if (title.Length > maximumNumberOfCharactersForTitle)
            {
                errors.Add(new ValidationError("title", ValidationErrorType.WrongLength));
            }
            if (!String.IsNullOrWhiteSpace(description) && description.Length > maximumNumberOfCharactersForDescription)
            {
                errors.Add(new ValidationError("description", ValidationErrorType.WrongLength));
            }
            if (errors.Any())
            {
                return new CreationResult<TodoCreationRequest>(
                    errors: errors);
            }
            return new CreationResult<TodoCreationRequest>(
                model: new TodoCreationRequest(
                    title: title,
                    description: description));
        }
    }
}
