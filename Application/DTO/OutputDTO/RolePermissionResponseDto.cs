namespace Api.Application.DTO.OutputDTO
{
    public class RolePermissionResponseDto
    {
       public string RoleName { get; set; }
       public string PermissionName { get; set; }
       public bool Active { get; set; } = true;
    }
      
}