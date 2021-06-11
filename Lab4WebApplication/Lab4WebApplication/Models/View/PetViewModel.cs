﻿/*Abdullah Mutaz Alshawa
 * 6/9/2021
 * Pet view model
 */
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab4WebApplication.Models.View
{
    public class PetViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        [Display(Name = "Pet's Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Pet's Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Next Checkup")]
        public DateTime NextCheckup { get; set; }

        [Required]
        [Display(Name = "Vet Name")]
        public string VetName { get; set; }
    }
}