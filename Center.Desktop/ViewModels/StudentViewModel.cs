using Center.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ViewModels
{
   public class StudentViewModel
    {

       
        public Guid Id { get; set; }


        

        public string FullName { get; set; }



      
        public string Phone { get; set; }


       
        public ICollection<UpdateGroupDto> Groups { get; set; }
    }
}
