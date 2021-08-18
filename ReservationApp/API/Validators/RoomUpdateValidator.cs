using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class RoomUpdateValidator : AbstractValidator<RoomUpdateDto>
    {
        public RoomUpdateValidator()
        {
            RuleFor(r => r.Number).NotNull();
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(r => r.Description).MaximumLength(200);
        }

        public static async Task ValidateRoomUpdateDto(RoomUpdateDto dto)
        {
            var validator = new RoomUpdateValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new DtoInvalidException($"Room dto is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
