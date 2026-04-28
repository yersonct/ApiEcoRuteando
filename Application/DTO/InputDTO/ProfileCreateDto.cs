namespace Api.Application.DTO.InputDTO
{
    public record ProfileCreateDto(
        int UserId,
        string PhoneNumber = null,
        string ProfilePicture = null
    );
}