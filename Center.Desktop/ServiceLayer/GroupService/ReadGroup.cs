using Center.API.Dtos;
using Center.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.GroupService
{
    class ReadGroup
    {
        [JsonProperty("Id")]
        
        public Guid Id { get; set; }


        [JsonProperty("GroupName")]
       
        public string GroupName { get; set; }


        [JsonProperty("TeacherId")]

        public Guid? TeacherId { get; set; }
      
       
        [JsonProperty("Teacher")]
        public ReadTeacherDto Teacher { get; set; }

        [JsonProperty("subjectId")]
        public Guid? SubjectId { get; set; }

        [JsonProperty("Subject")]
        public ReadSubjectDto Subject { get; set; }

        [JsonProperty("Students")]

        public ICollection<UpdateStudentDto> Students { get; set; }


       
    }
}
