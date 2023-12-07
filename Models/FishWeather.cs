using System.ComponentModel.DataAnnotations;

namespace FishBuddy.Models
{
    public class FishWeather
    {

        public int FishWeatherId { get; set; }
        [Display(Name = "FishSpecies ID")]
        public int FishSpeciesId { get; set; }

        [Display(Name = "Fish Name")]
        public FishSpecies? FishSpecies { get; set; }

        [Display(Name = "Best Weather To Catch")]
        public string? BestWeathers { get; set; }

    }

}
