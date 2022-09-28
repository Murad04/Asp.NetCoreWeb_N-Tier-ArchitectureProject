using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.Entity
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; } = null!;
        public decimal Weight { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }=null!;
    }
}
