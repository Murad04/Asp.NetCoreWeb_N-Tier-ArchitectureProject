using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Service.Services
{
    public class ServiceWithDTO<Entity, DTO> : IServiceWithDTO<Entity, DTO> where Entity : BaseEntity where DTO : class
    {
        private readonly IGenericRepository<Entity> _repository;
        protected readonly IUnitofWork _unitOfWork;
        protected readonly IMapper _mapper;

        public ServiceWithDTO(IGenericRepository<Entity> repository, IUnitofWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CustomResponseDTO<DTO>> AddAsync(DTO dto)
        {
            Entity entity = _mapper.Map<Entity>(dto);

            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();

            var newDTO = _mapper.Map<DTO>(entity);

            return CustomResponseDTO<DTO>.Success(StatusCodes.Status200OK, newDTO);
        }

        public async Task<CustomResponseDTO<IEnumerable<DTO>>> AddRangeAsync(IEnumerable<DTO> dtoList)
        {
            var newEntities = _mapper.Map<IEnumerable<Entity>>(dtoList);

            await _repository.AddRangeAsync(newEntities);
            await _unitOfWork.CommitAsync();

            var newDTO = _mapper.Map < IEnumerable<DTO>(newEntities);

            return CustomResponseDTO<IEnumerable<DTO>>.Success(StatusCodes.Status200OK, newDTO);
        }

        public async Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Entity, bool>> expression)
        {
            var hasResult = await _repository.AnyAsync(expression);

            return CustomResponseDTO<bool>.Success(StatusCodes.Status200OK, hasResult);
        }

        public Task<CustomResponseDTO<NoContentDTO>> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDTO<IEnumerable<DTO>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDTO<DTO>> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDTO<NoContentDTO>> RemoveRangeAsync(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(DTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDTO<IEnumerable<DTO>>> Where(Expression<Func<Entity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
