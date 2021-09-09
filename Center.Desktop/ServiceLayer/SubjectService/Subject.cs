using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.SubjectService
{
   public class Subject
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "SubjectName is Required")]
        [MaxLength(20, ErrorMessage = "SubjectName length very long")]
        public string SubjectName { get; set; }



        [Required(ErrorMessage = "Price is Required")]

        public int Price { get; set; }


        //public virtual ICollection<Group> Groups { get; set; }
        //public Subject()
        //{
        //    Groups = new List<Group>();
        //}
    }
}
