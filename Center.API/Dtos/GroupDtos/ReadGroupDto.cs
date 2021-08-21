using Center.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class ReadGroupDto
    {
       
        public int Id { get; set; }

        public string GroupName { get; set; }


        public int TeacherId { get; set; }
      

        public int SubjectId { get; set; }
     

      //  public List<Student> Students { get; set; } = new List<Student>();
    }
}
