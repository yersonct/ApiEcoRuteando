namespace Api.Application.DTO.InputDTO
{
    public record ResetPasswordDto(string Email, string Code, string NewPassword);
}
