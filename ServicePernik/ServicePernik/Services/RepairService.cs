using ServicePernik.Abstractions;
using ServicePernik.Data;
using ServicePernik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Services
{
    public class RepairService : IRepairService
    {
        private readonly ApplicationDbContext _context;

        public RepairService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool CreateRepair(string code, string name, int repairCategoryId, decimal price, string description)
        {
            var repair = new Repair
            {
                Code = code,
                Name = name,
                RepairCategoryId = repairCategoryId,
                Price = price,
                Description = description
            };

            _context.Repairs.Add(repair);
            _context.SaveChanges();
            return _context.SaveChanges() != 0;
        }

        public List<RepairCategory> GetRepairCategories()
        {
            List<RepairCategory> repairs = _context.RepairCategories
                 .ToList();
            return repairs;
        }

        public List<Repair> GetRepairs()
        {
            List<Repair> repairs = _context.Repairs
                 .ToList();
            return repairs;
        }
    }
}
