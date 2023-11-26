
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FishBuddy.Models
{ 
 
    public class FishSpecies
    {
        public int FishSpeciesId { get; set; }

        [Display(Name = "Common Name")]
        public string? FishCommonName { get; set; }
        [Display(Name = "Species Name")]
        public string? FishSpeciesName { get; set; }
        [Display(Name = "Habitat")]
        public string? FishHabitat { get; set; }
        [Display(Name = "Record Weight")]
        public string? RecordWeight { get; set; }
        [Display(Name = "Record Length")]
        public string? RecordLength { get; set; }

        

    }
}
