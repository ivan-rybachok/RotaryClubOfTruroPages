using System;
using System.ComponentModel.DataAnnotations;

namespace RotaryClubOfTruro.Models {


    public class Student {
        [Key]
        public int appID {get; set;}
        public int schoolID {get; set;}
        public int infoID {get; set;}
        public int fileID {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="full name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage="Letters only please")]
        public string appName {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="address")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage="Please fill in the text field")]
        // [RegularExpression(@"[A-Za-z0-9-\s]+", ErrorMessage="Letters and Numbers only please")]
        public string address {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="email")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage="Please enter a valid email format example@example.com")]
        public string email {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="home phone")]
        [RegularExpression(@"[0-9]{3}-[0-9]{3}-[0-9]{4}", ErrorMessage="Please enter valid format")]
        // [RegularExpression(@"^(1-)?\d{3}-\d{3}-\d{4}$", ErrorMessage="Please enter valid format")]
        public string homePhone {get; set;}
        [Required]
        [MaxLength(100)]

        [Display(Name="cellphone")]
        [RegularExpression(@"([\-]?\d[\-]?){10}", ErrorMessage="Please enter valid format")]

        // [RegularExpression(@"^(1-)?\d{3}-\d{3}-\d{4}$", ErrorMessage="Please enter valid format")]
        public string cellPhone {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="grade average")]
        [RegularExpression(@"^(?!\s*$).+", ErrorMessage="Please enter numbers between 1-100 only")]
        // [RegularExpression(@"^[1-9][0-9]?$|^100$", ErrorMessage="Please enter numbers between 1 100 only")]
        public string gradeAvg {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="school")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage="Letters only please")]
        public string collegeName {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="acceptance letter")]
        [RegularExpression(@"^[y|Y][e|E][s|S]|[n|N][o|O]$", ErrorMessage="Yes or No only")]
        // [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage="Yes or No only")]
        public string hasLetter {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="program name")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage="Letters only please")]
        public string progName {get; set;}
        [Required]
        // [MaxLength(100)]
        [Display(Name="program start date")]
        
        // [RegularExpression(@"^(?!\s*$).+", ErrorMessage="Please fill in the textField")]
        public string progStart {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="program duration name")]
        [RegularExpression(@"[A-Za-z0-9-\s]+", ErrorMessage="Letters and Numbers only please")]
        public string progDuration {get; set;}
    }


}
