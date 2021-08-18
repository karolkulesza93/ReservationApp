using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class FloorCreateValidator : AbstractValidator<FloorCreateDto>
    {
        public FloorCreateValidator()
        {
            RuleFor(f => f.Number).NotNull();
            RuleFor(f => f.Name).MaximumLength(50);
        }

        public static async Task ValidateFloorCreateDto(FloorCreateDto dto)
        {
            var validator = new FloorCreateValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new DtoInvalidException($"Floor dto is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
