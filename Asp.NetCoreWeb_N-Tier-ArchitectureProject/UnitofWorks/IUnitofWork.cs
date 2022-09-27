using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.UnitofWorks
{
    public interface IUnitofWork
    {
        Task CommitAsync();
        void Commit();
    }
}
