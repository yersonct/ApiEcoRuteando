using Api.Domain.Enums.genery;
using Api.Domain.ValueObjects;
using System.Collections.Generic;

namespace Api.Domain.Entities
{
    public class Profile : EntityGenery
    {
        public int UserId { get; set; }

        public User User { get; set; }
    
        public PhoneNumber PhoneNumber { get; set; }
        public UrlImagen ProfilePicture { get; set; }


    }
}