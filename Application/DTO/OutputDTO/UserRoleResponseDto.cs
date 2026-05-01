namespace Api.Application.DTO.OutputDTO
{
    public class UserRoleResponseDto
    {
        public string RoleName { get; set; }
        public string UserEmail { get; set; }
        public bool Active { get; set; } = true;
    }
    
}