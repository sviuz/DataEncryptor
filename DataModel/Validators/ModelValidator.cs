using DataModels.Models;
using FluentValidation;

namespace DataModels.Validators
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m => m.Id).NotNull();
            RuleFor(m => m.Name).NotNull();
            RuleFor(m => m.Description).NotNull();
            RuleFor(m => m.SecretValue).NotNull();
        }
    }
}
