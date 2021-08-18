using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class SeatUpdateValidator : AbstractValidator<SeatUpdateDto>
    {
        public SeatUpdateValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(s => s.Description).MaximumLength(200);
        }

        public static async Task ValidateSeatUpdateDto(SeatUpdateDto dto)
        {
            var validator = new SeatUpdateValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new DtoInvalidException($"Seat dto is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
