using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pokedex.DataAccessLibrary.Models
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Type is required")]
        [MinLength(3, ErrorMessage = "Type must be at least 3 characters long!")]
        public string Type { get; set; }
        public string Abilities { get; set; }
        [Required(ErrorMessage = "Hp is required")]
        [Range(1, 300)]
        public int Hp { get; set; }
        [Required(ErrorMessage = "Attack is required")]
        [Range(1, 300)]      
        public int Attack { get; set; }
        [Required(ErrorMessage = "SpecialAttack is required")]
        [Range(1, 300)]
        public int SpecialAttack { get; set; }
        [Required(ErrorMessage = "Defense is required")]
        [Range(1, 300)]
        public int Defense { get; set; }
        [Required(ErrorMessage = "SpecialDefense is required")]
        [Range(1, 300)]
        public int SpecialDefense { get; set; }
        [Required(ErrorMessage = "Speed is required")]
        [Range(1, 300)]
        public int Speed { get; set; }
        [Range(1, 100)]
        public double Height { get; set; }
        [Range(1, 4000)]
        public double Weight { get; set; }
        [StringLength(250, ErrorMessage = "Max 250 characters allowed")]
        public string Description { get; set; }

        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }

    }
}
