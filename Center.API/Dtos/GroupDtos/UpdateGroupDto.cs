using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class UpdateGroupDto
    {
        public int Id { get; set; }

        public string GroupName { get; set; }


        public int TeacherId { get; set; }


        public int SubjectId { get; set; }
    }
}
