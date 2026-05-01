using System;

namespace Api.Application.DTO.OutputDTO
{
    public class DailyStatisticsResponseDto
    {
        public DateTime ReportDate { get;}
        public decimal TotalDistance { get;}
        public decimal TotalCO2Saved { get;}
        public int BicycleUsersCount { get;}
        public int PublicTransportUsersCount { get;}
    }
}
