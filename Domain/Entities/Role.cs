using Api.Domain.Enums;
using Api.Domain.Enums.genery;
using System;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Role : EntityGenery
    {
        public RoleType Name { get; set; }
        public string Description { get; set; }
        public ICollection<RolePermission> RolePermission { get; set; } 
        public ICollection<UserRole> UserRole { get; set; } 
    }
}