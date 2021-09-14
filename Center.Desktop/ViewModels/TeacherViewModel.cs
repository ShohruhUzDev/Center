using Center.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ViewModels
{
    public class TeacherViewModel
    {
        public Guid  Id {get;set;}
        public string  Name { get; set; }
        public string Phone { get; set; }
        public ICollection<UpdateGroupDto> Groups { get; set; }
    }
}
