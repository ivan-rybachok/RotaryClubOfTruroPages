using System;
using System.ComponentModel.DataAnnotations;

namespace RotaryClubOfTruro.Models {


    public class Info {
        
        [Key]
        public int infoID {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="plans")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage="* Please fill in the text field")]
        public string plans {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="financial need")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage="* Please fill in the text field")]
        public string finNeed {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="employment")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage="* Please fill in the textField ")]
        public string job {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="volunteer")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage="* Please fill in the text field *")]
        public string volunteer {get; set;}
    }


}