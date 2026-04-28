using Api.Domain.Enums.genery;
using System;

namespace Api.Domain.Entities
{
    public class DailyStatistics: EntityGenery
    {

        public DateTime ReportDate { get; set; }

        public decimal TotalDistance { get; set; }
        public decimal TotalCO2Saved { get; set; }

        public int BicycleUsersCount { get; set; }
        public int PublicTransportUsersCount { get; set; }
    }
}
