﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Center.API.Models
{
    public class Subject
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "SubjectName is Required")]
        [MaxLength(20, ErrorMessage = "SubjectName length very long")]
        public string SubjectName { get; set; }



        [Required(ErrorMessage = "Price is Required")]
       
        public decimal Price { get; set; }


        public List<Group> Groups { get; set; }
    }
}