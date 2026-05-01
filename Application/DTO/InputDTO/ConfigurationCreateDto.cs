namespace Api.Application.DTO.InputDTO
{
    public record ConfigurationCreateDto(
        int UserId,
        int LanguageId,
        int BackgroundColorId,
        bool IsVoiceActive = false
    );
}