using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Models
{
    public class Student
    {

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       
        [Required(ErrorMessage ="FirstName is Required")]
        [MaxLength(20, ErrorMessage ="FirstName length very long")]
        public string  FirstName { get; set; }



        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(20, ErrorMessage = "LastName length very long")]
        public string  LastName { get; set; }


        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(20, ErrorMessage = "Phone length very long")]
        public string  Phone { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
        public Student()
        {
            StudentGroups = new List<StudentGroup>();
        }
        
    }
}
