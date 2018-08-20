using FluentValidation;

namespace Promelectro.Api.ViewModels.Validations
{
    public class RegistrationViewModelValidator : AbstractValidator<RegistrationViewModel>
    {
        public RegistrationViewModelValidator()
        {
            RuleFor(vm => vm.Email).NotEmpty().WithMessage("поле email не может быть пустым");
            RuleFor(vm => vm.Password).NotEmpty().WithMessage("поле пароль не может быть пустым");
            RuleFor(vm => vm.UserName).NotEmpty().WithMessage("поле логин не может быть пустым");
            RuleFor(vm => vm.FirstName).NotEmpty().WithMessage("Имя не может быть пустым");
        }
    }
}