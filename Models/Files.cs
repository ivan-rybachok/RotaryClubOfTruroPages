using System;
using System.ComponentModel.DataAnnotations;

namespace RotaryClubOfTruro.Models {


    public class Files {
        
        [Key]
        public int fileID {get; set;}
        // [Required]
        // [MaxLength(100)]
        // [Display(Name="Resume")]
        // [RegularExpression(@"^(?!\s*$).+", ErrorMessage="Please fill in the textField")]
        public string resume {get; set;}
        // [Required]
        // [MaxLength(100)]
        // [Display(Name="Transcript")]
        // [RegularExpression(@"^(?!\s*$).+", ErrorMessage="Please fill in the textField")]
        public string transcript {get; set;}
        // [Required]
        // [MaxLength(100)]
        // [Display(Name="Reference Letter")]
        // [RegularExpression(@"^(?!\s*$).+", ErrorMessage="Please fill in the textField")]
        // public string refLetter {get; set;}
    }


}