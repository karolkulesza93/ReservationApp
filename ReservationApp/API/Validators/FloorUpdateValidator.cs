using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class FloorUpdateValidator : AbstractValidator<FloorUpdateDto>
    {
        public FloorUpdateValidator()
        {
            RuleFor(f => f.Number).NotNull();
            RuleFor(f => f.Name).MaximumLength(50);
        }

        public static async Task ValidateFloorUpdateDto(FloorUpdateDto dto)
        {
            var validator = new FloorUpdateValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new DtoInvalidException($"Dto is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
