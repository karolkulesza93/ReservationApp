using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class SeatCreateValidator :  AbstractValidator<SeatCreateDto>
    {
        public SeatCreateValidator()
        {
            RuleFor(s => s.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(s => s.Description).MaximumLength(200);
        }

        public static async Task ValidateSeatCreateDto(SeatCreateDto dto)
        {
            await IdValidator.ValidateId(dto.RoomId);
            var validator = new SeatCreateValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new DtoInvalidException($"Seat dto is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
