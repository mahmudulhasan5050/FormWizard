﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FormWizard.Model
{
    public class MyForm
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        [Display(Name="Category")]
        public int CategoryId { get; set; }

        [ValidateNever]
        public Country Country { get; set; }
        
        [Required]
        [Display(Name = "Country")]

        public int CountryId { get; set; }
    }
}
