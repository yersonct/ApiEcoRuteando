using System;

namespace Api.Application.DTO.OutputDTO
{
    public class DailyStatisticsResponseDto
    {
        public DateTime ReportDate { get; set; }
        public decimal TotalDistance { get; set; }
        public decimal TotalCO2Saved { get; set; }
        public int BicycleUsersCount { get; set; }
        public int PublicTransportUsersCount { get; set; }
    }
}
