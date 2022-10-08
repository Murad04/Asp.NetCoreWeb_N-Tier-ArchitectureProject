namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks
{
    public interface IUnitofWork
    {
        Task CommitAsync();
        void Commit();
    }
}
