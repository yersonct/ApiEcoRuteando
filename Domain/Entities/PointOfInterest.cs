using Api.Domain.Enums;
using Api.Domain.Enums.genery;
using Api.Domain.ValueObjects;

namespace Api.Domain.Entities
{
    public class PointOfInterest : EntityGenery
    {
        public string Name { get; set; }

        public int ProfileId { get; set; }
        public int UserId { get; set; }  

        public POICategory Category { get; set; }

        public GeoPoint Location { get; set; }

        public string GooglePlaceId { get; set; }
        public User User { get; set; }   

        public Profile Profile { get; set; }

    }
}