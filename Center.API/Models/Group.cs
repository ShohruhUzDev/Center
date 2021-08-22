using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Center.API.Models
{
    public class Group
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required(ErrorMessage = "GroupName is Required")]
        [MaxLength(20, ErrorMessage = "GroupName length is very long")]
        public string GroupName { get; set; }

       
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }


        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public virtual ICollection<StudentGroup> StudentGroups { get; set; }

        public Group()
        {
            StudentGroups = new List<StudentGroup>();
        }

    }

}
