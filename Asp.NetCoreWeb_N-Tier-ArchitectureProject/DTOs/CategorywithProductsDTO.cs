﻿using Asp.NetCoreWeb_N_Tier_ArchitectureProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asp.NetCoreWeb_N_Tier_ArchitectureProject.DTOs
{
    public class CategorywithProductsDTO:CategoryDTO
    {
        public List<Product>? Products { get; set; }
    }
}
