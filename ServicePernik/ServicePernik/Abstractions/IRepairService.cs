using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Abstractions
{
    public interface IRepairService
    {
        bool CreateRepair( string code, string name, int repairCategoryId, decimal price, string Description);
    }
}
