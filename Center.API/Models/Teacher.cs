﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Models
{
    public class Teacher
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "FirstName is Required")]
        [MaxLength(20, ErrorMessage = "FirstName length very long")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(20, ErrorMessage = "LastName length very long")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(20, ErrorMessage = "Phone length very long")]
        public string Phone { get; set; }


        public virtual ICollection<Group> Groups  { get; set; }
        public Teacher()
        {
            Groups = new List<Group>();
        }
    }
}
