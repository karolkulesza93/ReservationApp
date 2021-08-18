using System.Threading.Tasks;
using API.Exceptions;
using FluentValidation;

namespace API.Validators
{
    public class IdValidator : AbstractValidator<int>
    {
        public IdValidator()
        {
            RuleFor(i => i).GreaterThan(0).NotNull();
        }

        public static async Task ValidateId(int id)
        {
            var validator = new IdValidator();
            var result = await validator.ValidateAsync(id);
            if (!result.IsValid)
            {
                throw new IdInvalidException($"Id={id} is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
