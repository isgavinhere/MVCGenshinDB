using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GenshinDB.Models
{
    public class Artifact
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Highest Rarity")]
        [Range(1, 5)]
        [Required]
        public int Rarity { get; set; }

        [Display(Name = "Set Effect (2 Piece)")]
        [Required]
        public string SetEffect2 { get; set; }

        [Display(Name = "Set Effect (4 Piece)")]
        [Required]
        public string SetEffect4 { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Full Description")]
        [Required]
        public string FullDescription { get; set; }
    }
}
