using ServicePernik.Entities;
using ServicePernik.Models.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Models.Repair
{
    public class AddRepairVM
    {
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        public int RepairCategoryId { get; set; }
      //  public virtual RepairCategory RepairCategory { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

       // public virtual ICollection<Report> Reports { get; set; }
        public virtual List<CategoryPairVM> RepairCategories { get; set; }
    }
}
