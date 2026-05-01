namespace Api.Application.DTO.OutputDTO
{
    public record PointOfInterestResponseDto(
        string Name,
        string Category,
        double Latitude,
        double Longitude,

        bool Active
    );
}