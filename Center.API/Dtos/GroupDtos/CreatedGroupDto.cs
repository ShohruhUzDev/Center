using Center.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class CreatedGroupDto
    {
       

        [Required(ErrorMessage = "GroupName is Required")]
        [MaxLength(20, ErrorMessage = "GroupName length is very long")]
        public string GroupName { get; set; }


        public int TeacherId { get; set; }
       

        public int SubjectId { get; set; }
        

        
    }
}
