using System;
using System.ComponentModel.DataAnnotations;

namespace RotaryClubOfTruro.Models {


    public class School {
        [Key]
        public int schoolID {get; set;}
        public string schoolName {get; set;}
    }


}