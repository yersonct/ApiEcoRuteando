namespace Api.Application.DTO.OutputDTO
{
    public record ProfileResponseDto(
        //int UserId,
        string PhoneNumber ,
        string ProfilePicture,
        bool Active
    );
}