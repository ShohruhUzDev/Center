using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.GroupService
{
    public class Group
    {
        [JsonProperty("Id")]
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }


        [JsonProperty("GroupName")]
        [Required(ErrorMessage = "GroupName is Required")]
        [MaxLength(20, ErrorMessage = "GroupName length is very long")]
        public string GroupName { get; set; }


        [JsonProperty("TeacherId")]

        public Guid? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        [JsonProperty("SubjectId")]

        public Guid? SubjectId { get; set; }
        public Subject Subject { get; set; }

        public ICollection<Student> Students { get; set; }


        public Group()
        {
            Students = new List<Student>();
        }
    }
}
