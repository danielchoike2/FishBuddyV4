
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace FishBuddy.Models
{ 
 
    public class FishLog
    {
        public int ID { get; set; }

       

        //DataType Annotation 
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = "Date")]
        public string? Date { get; set; }
        
        //required used
        [Required]
        //column property 

        [Column("Fish Name")]
            [Display(Name = "Fish Name")]
        //string length annotation 
        [StringLength(30, ErrorMessage = "Please enter a fish name 30 characters or less.")]
        //RegularExpression 1 
        [RegularExpression("^[a-zA-Z]+(\\s[a-zA-Z]+)?$", ErrorMessage = "Only alphabetic letters and spaces are allowed for fish names.")]
        
        public string? FishName { get; set; }
        
        //required used
        [Required]
        [Display(Name = "Location")]
        [StringLength(30, ErrorMessage = "Please enter a location name 30 characters or less.")]
        //Regular Expression 2
        [RegularExpression("^[a-zA-Z]+(\\s[a-zA-Z]+)?$", ErrorMessage = "Only alphabetic letters and spaces are allowed for location names.")]
        public string? Location { get; set; }
        
        //required used 
        [Required]
        [Display(Name = "Length")]
        public string? MaxLength { get; set; }

        [StringLength (20)]
        [Column("Weight")]
        [Display(Name = "Weight")]
        public string? MaxWeight { get; set; }

       


    }
}
