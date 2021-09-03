using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class CustomSubjectDto
    {

        [Required(ErrorMessage = "SubjectName is Required")]
        [MaxLength(20, ErrorMessage = "SubjectName length very long")]
        public string SubjectName { get; set; }



        [Required(ErrorMessage = "Price is Required")]

        public int Price { get; set; }
    }
    public class SubjectDto : CustomSubjectDto
    {
        public Guid Id { get; set; }
        public ICollection<GroupDto> Guruhlar { get; set; }
      
    }
    public class SubjectForCreationDto:CustomSubjectDto
    {
      
    }

}
