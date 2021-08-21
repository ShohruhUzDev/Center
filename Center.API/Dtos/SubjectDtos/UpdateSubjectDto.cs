using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos.SubjectDtos
{
    public class UpdateSubjectDto
    {
        public int Id { get; set; }

        public string SubjectName { get; set; }

        public int Price { get; set; }
    }
}
