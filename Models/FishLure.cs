using System.ComponentModel.DataAnnotations;

namespace FishBuddy.Models
{
    public class FishLure
    {

        public int FishLureId { get; set; }
        [Display(Name = "FishSpecies ID")]
        public int FishSpeciesId { get; set; }
        [Display(Name = "Fish Name")]
        public FishSpecies? FishSpecies { get; set; }
        [Display(Name = "Best Lures for Species")]
        public string? FishLureName { get; set; }



    }
}
