using Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs;
using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using System.Linq.Expressions;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Services
{
    public interface IServiceWithDTO<Entity, DTO> where Entity : BaseEntity where DTO : class
    {
        Task<CustomResponseDTO<DTO>> GetByIDAsync(int id);
        Task<CustomResponseDTO<IEnumerable<DTO>>> GetAllAsync();

        Task<CustomResponseDTO<IEnumerable<DTO>>> Where(Expression<Func<Entity, bool>> expression);
        Task<CustomResponseDTO<bool>> AnyAsync(Expression<Func<Entity, bool>> expression);

        Task<CustomResponseDTO<DTO>> AddAsync(DTO dto);
        Task<CustomResponseDTO<IEnumerable<DTO>>> AddRangeAsync(IEnumerable<DTO> dto);

        Task<CustomResponseDTO<NoContentDTO>> UpdateAsync(DTO dto);

        Task<CustomResponseDTO<NoContentDTO>> DeleteAsync(int id);

        Task<CustomResponseDTO<NoContentDTO>> RemoveRangeAsync(IEnumerable<int> ids);
    }
}
