using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Application.Interface
{
    public interface IConfigurationService
    {
        Task CreateConfiguration(ConfigurationCreateDto dto);
        Task<List<ConfigurationResponseDto>> GetAll();
    }
}