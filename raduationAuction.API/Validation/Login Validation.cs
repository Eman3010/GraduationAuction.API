using FluentValidation;

namespace raduationAuction.API.Validation
{
    public class Login_Validation: AbstractValidator<LoginRequest>
    {
        public Login_Validation()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotEmpty();
        }
    }
}
