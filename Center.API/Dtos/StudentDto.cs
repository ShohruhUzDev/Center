using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class CreateStudentDto
    {
        [Required(ErrorMessage = "FirstName is Required")]
        [MaxLength(20, ErrorMessage = "FirstName length very long")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(20, ErrorMessage = "LastName length very long")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(20, ErrorMessage = "Phone length very long")]
        public string Phone { get; set; }
    }
    public class StudentDto
    {
        public Guid Id { get; set; }
 
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
       
        public string Phone { get; set; }
        public ICollection<UpdateGroupDto > Groups { get; set; }
    }
    public class AddGroupsToStudent
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid StudentId { get; set; }
       
        [Required]

        public IList<Guid> GroupsId { get; set; }
    }
    public class UpdateStudentDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "FirstName is Required")]
        [MaxLength(20, ErrorMessage = "FirstName length very long")]
        public string FirstName { get; set; }



        [Required(ErrorMessage = "LastName is Required")]
        [MaxLength(20, ErrorMessage = "LastName length very long")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Phone is Required")]
        [MaxLength(20, ErrorMessage = "Phone length very long")]
        public string Phone { get; set; }
    }

}
