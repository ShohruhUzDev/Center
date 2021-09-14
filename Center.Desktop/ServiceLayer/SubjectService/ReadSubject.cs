using Center.API.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.SubjectService
{
   public class ReadSubject
    {
          [JsonProperty("Id")]
        public Guid Id { get; set; }


          [JsonProperty("SubjectName")]

        public string SubjectName { get; set; }




        [JsonProperty("Price")]

        public int Price { get; set; }


        [JsonProperty("Groups")]

        public ICollection<UpdateGroupDto> Groups { get; set; }
       
    }
}
