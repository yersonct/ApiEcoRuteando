namespace Api.Application.DTO.OutputDTO
{
    public record ConfigurationResponseDto(
        //int UserId,
        string Language,
        string BackgroundColor,
        bool IsVoiceActive,
        bool Active = true
    );
}