using AutoMapper;
using Api.Application.DTO.InputDTO;
using Api.Application.DTO.OutputDTO;
using Api.Domain.Entities;
using Api.Domain.Interface;
using Api.Application.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Profile = Api.Domain.Entities.Profile; 

namespace Api.Application.Service
{
    public class ProfileService : IProfileService 
    {
        private readonly IProfileRepository _repository;
        private readonly IMapper _mapper;

        public ProfileService(IProfileRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateProfile(ProfileCreateDto dto)
        {
            var profile = _mapper.Map<Profile>(dto);
            await _repository.CreateAsync(profile);
        }

        public async Task<List<ProfileResponseDto>> GetAll()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<ProfileResponseDto>>(list);
        }
    }
}