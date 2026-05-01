using System;

namespace Api.Application.DTO.OutputDTO
{
    public class AuditLogResponseDto{

        public string UserName { get;}
        public string Action { get; }
        public string TableName { get;}
        public string OldData { get;}
        public string NewData { get; }
        public string IpAddress { get;}
        public DateTime CreatedAt { get;}
        public bool Active { get;} = true;
    }
}