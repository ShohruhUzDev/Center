using Center.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ViewModels
{
    public class SubjectViewModel
    {
       
        public Guid Id { get; set; }


        
        public string SubjectName { get; set; }


        public int Price { get; set; }
        public ICollection<UpdateGroupDto> Groups { get; set; }
    }
}
