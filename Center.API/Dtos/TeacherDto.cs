using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class CustomTeacherDto
    {
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
        public Guid Id { get; set; }
        public ICollection<GroupDto> Guruhlar { get; set; }

    }
    public class TeacherForCreationDto:CustomTeacherDto
    {
     //  public IList<Guid> Ids { get; set; }
    }
}
