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
        public string Name { get; set; }
        public string Type { get; set; }
        public string Abilities { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int SpecialAttack { get; set; }
        public int Defense { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }
        public DateTime Added { get; set; }
        public DateTime Modified { get; set; }

    }
}
