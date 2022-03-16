﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicePernik.Entities
{
    public class Employee
    {
        [Key]

        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]

        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }

        [Required]
        [MaxLength(10)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Email")]

        public string Email { get; set; }

        [Required]
        [MaxLength(30)]

        public string JobTitle { get; set; }

        public string UserId { get; set; }

        public virtual ServiceUser User { get; set; }
    }
}
