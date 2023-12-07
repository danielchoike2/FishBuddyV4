using System.ComponentModel.DataAnnotations;

namespace FishBuddy.Models
{
    public class FishTime
    {
        
        public int FishTimeId { get; set; }
        [Display(Name = "FishSpecies ID")]
        public int FishSpeciesId { get; set; }
        
        [Display(Name = "Fish Name")]
        public FishSpecies? FishSpecies { get; set; }
        [Display(Name = "Best Times To Catch")]
        public string? BestTimes { get; set; }

    }
}
