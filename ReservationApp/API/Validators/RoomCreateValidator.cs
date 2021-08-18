using System.Threading.Tasks;
using API.Exceptions;
using API.Models;
using FluentValidation;

namespace API.Validators
{
    public class RoomCreateValidator : AbstractValidator<RoomCreateDto>
    {
        public RoomCreateValidator()
        {
            RuleFor(r => r.Number).NotNull();
            RuleFor(r => r.Name).NotNull().NotEmpty().MaximumLength(50);
            RuleFor(r => r.Description).MaximumLength(200);
        }

        public static async Task ValidateRoomCreateDto(RoomCreateDto dto)
        {
            await IdValidator.ValidateId(dto.FloorId);
            var validator = new RoomCreateValidator();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                throw new DtoInvalidException($"Room dto is invalid: {string.Join(' ', result.Errors)}");
            }
        }
    }
}
