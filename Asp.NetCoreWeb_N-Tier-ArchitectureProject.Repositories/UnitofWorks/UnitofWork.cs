using Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Repositories.UnitofWorks
{
    public class UnitofWork : IUnitofWork
    {
        private readonly AppDBContext _dBContext;

        public UnitofWork(AppDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void Commit()
        {
            _dBContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dBContext.SaveChangesAsync();
        }
    }
}
