using Center.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class CustomTeacherDto
    {
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

    }
    public class TeacherDto:CustomTeacherDto
    {
       
        public ICollection<UpdateGroupDto> Groups { get; set; }

    }
    public class TeacherForCreationDto
    {
        //  public IList<Guid> Ids { get; set; }
        [Required(ErrorMessage = "FirstName is Required")]
        [MaxLength(20, ErrorMessage = "FirstName length very long")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(20, ErrorMessage = "LastName length very long")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(20, ErrorMessage = "Phone length very long")]
        public string Phone { get; set; }
    }
}
