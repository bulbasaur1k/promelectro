using FluentValidation.Attributes;
using Promelectro.Api.ViewModels.Validations;

namespace Promelectro.Api.ViewModels
{
    [Validator(typeof(CredentialsViewModelValidator))]
    public class CredentialsViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}