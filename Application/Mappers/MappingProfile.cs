using AutoMapper;
using Api.Domain.Entities;
using Api.Domain.ValueObjects;
using System;
using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;

using Profile = Api.Domain.Entities.Profile;

namespace Api.Application.Mappers
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDto, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => new Username(src.Name)))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => new Email(src.Email)))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => new Password(src.Password)))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<User, UserResponseDto>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
             .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Value))
             .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<PermissionCreateDto, Permission>();
            CreateMap<Permission, PermissionResponseDto>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.Value))
             .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
             .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<RoleCreateDto, Role>();
            CreateMap<Role, RoleResponseDto>();

            CreateMap<RolePermissionCreateDto, RolePermission>();
            CreateMap<RolePermission, RolePermissionResponseDto>()
              .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
             .ForMember(dest => dest.PermissionName, opt => opt.MapFrom(src => src.Permission.Name.Value))
             .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<UserRoleCreateDto, UserRole>();
            CreateMap<UserRole, UserRoleResponseDto>()
          .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name))
             .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email.Value))
             .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<RequestPasswordRecoveryDto, PasswordRecovery>();
            CreateMap<PasswordRecovery, PasswordRecoveryResponseDto>();

            CreateMap<SupportTicketCreateDto, SupportTicket>();
            CreateMap<SupportTicket, SupportTicketResponseDto>()
                .ConstructUsing(src => new SupportTicketResponseDto(
                    src.UserId,
                    src.Subject != null ? src.Subject.Value : "Sin Asunto",
                    src.Priority != null ? src.Priority.ToString() : "Baja",
                    src.CreatedAt,
                    src.Active
               ));

            CreateMap<SessionCreateDto, Session>();
            CreateMap<Session, SessionResponseDto>()
                 .ForMember(dest => dest.Email,
                  opt => opt.MapFrom(src => src.User.Email.Value))
                .ForMember(dest => dest.IpAddress,
                  opt => opt.MapFrom(src => src.IpAddress.Value));

            CreateMap<ProfileCreateDto, Profile>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => new PhoneNumber(src.PhoneNumber)))
                .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => new UrlImagen(src.ProfilePicture)));

            CreateMap<Profile, ProfileResponseDto>()
            .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber.Value))
             .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture.Value))
             .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<ConfigurationCreateDto, Configuration>();
            CreateMap<Configuration, ConfigurationResponseDto>()
                .ConstructUsing(src => new ConfigurationResponseDto(
                    src.Language != null ? src.Language.ToString() : "Default",
                    src.BackgroundColor != null ? src.BackgroundColor.ToString() : "Default",
                    src.IsVoiceActive,
                    src.Active
                ));

            CreateMap<ObstacleReportCreateDto, ObstacleReport>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => new UrlImagen(src.PhotoUrl)));

            CreateMap<ObstacleReport, ObstacleReportResponseDto>()
                .ConstructUsing(src => new ObstacleReportResponseDto(
                    src.UserId,
                    src.ObstacleType != null ? src.ObstacleType.ToString() : "Desconocido",
                    src.Description,
                    src.Location != null ? src.Location.Latitude : 0,
                    src.Location != null ? src.Location.Longitude : 0,
                    src.PhotoUrl != null ? src.PhotoUrl.Value : null,
                    src.CreatedAt,
                    src.Active
                ));

            CreateMap<PointOfInterestCreateDto, PointOfInterest>();
            CreateMap<PointOfInterest, PointOfInterestResponseDto>()
                .ConstructUsing(src => new PointOfInterestResponseDto(
                    src.Name?? "Sin Nombre",
                    src.Category != null ? src.Category.ToString() : "Sin Categoría",
                    src.Location != null ? src.Location.Latitude : 0,
                    src.Location != null ? src.Location.Longitude : 0,
                    src.Active
                ));

            CreateMap<RouteCreateDto, Route>()
                .ForMember(dest => dest.Path, opt => opt.MapFrom(src => src.PathJson));

            CreateMap<Route, RouteResponseDto>()
                .ConstructUsing(src => new RouteResponseDto(
                    src.Name != null ? src.Name.Value : "Sin Nombre",
                    src.Description,
                    src.Path != null ? src.Path.SerializedPoints : null,
                    src.DistanceKm != null ? (double)src.DistanceKm.Value : 0.0,
                    src.EstimatedTime != null ? src.EstimatedTime.Value : 0,
                    src.CreatedBy,
                    src.CreatedAt,
                    src.Active
                ));

            CreateMap<RouteReviewCreateDto, RouteReview>();
            CreateMap<RouteReview, RouteReviewResponseDto>();

            CreateMap<ReportValidationCreateDto, ReportValidation>();
            CreateMap<ReportValidation, ReportValidationResponseDto>()
                .ConstructUsing(src => new ReportValidationResponseDto(
                    src.UserId,
                    src.ReportId,
                    src.ConfirmationStatus != null ? src.ConfirmationStatus.ToString() : "Pendiente",
                    src.VotedAt,
                    src.Active
                ));

            CreateMap<TravelHistoryCreateDto, TravelHistory>();
            CreateMap<TravelHistory, TravelHistoryResponseDto>()
                .ConstructUsing(src => new TravelHistoryResponseDto(
                        src.UserId,
                        src.RouteId,
                        src.CO2SavedKg != null ? (double)src.CO2SavedKg.Value : 0.0,
                        FormatTimeRange(src.TimeRange),
                        src.IsCompleted,
                        src.Active
                 ));

            CreateMap<AuditLogCreateDto, AuditLog>();
            CreateMap<AuditLog, AuditLogResponseDto>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name.Value))
              .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.Action != null ? src.Action.ToString() : "Acción Desconocida"))
              .ForMember(dest => dest.TableName, opt => opt.MapFrom(src => src.TableName.ToString()))
              .ForMember(dest => dest.OldData, opt => opt.MapFrom(src => src.OldData))
              .ForMember(dest => dest.NewData, opt => opt.MapFrom(src => src.NewData))
              .ForMember(dest => dest.IpAddress, opt => opt.MapFrom(src => src.IpAddress != null ? src.IpAddress.Value : "0.0.0.0"))
              .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
              .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));
                }

        private static string FormatTimeRange(TimeRange timeRange)
        {
            if (timeRange == null)
                return "Sin Rango";
            if (timeRange.Start != default && timeRange.End != default)
                return $"{timeRange.Start:yyyy-MM-dd HH:mm} - {timeRange.End:yyyy-MM-dd HH:mm}";
            if (timeRange.Duration != default)
                return timeRange.Duration.ToString(@"hh\:mm\:ss");
            return "Sin Rango";
        }
    }
}