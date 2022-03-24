using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Entities
{
    public class Service
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
        public int CategoryId { get; set; }
        public virtual ServiceCategory ServiceCategory { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
