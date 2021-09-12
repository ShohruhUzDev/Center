using Center.Desktop.ServiceLayer.StudentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ViewModels
{
   public  class GroupViewModel
    {
       
        public Guid Id { get; set; }
                     
        public string GuruhNomi { get; set; }
           
        public string Uqituvchi { get; set; }
              
        public string Fan { get; set; }
        public ICollection<Student> Students { get; set; } = new List<Student>();


       
    }
}
