using Center.API.Dtos;
using Center.Desktop.ServiceLayer.GroupService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.StudentService
{
  public  class ReadStudent
    {
       [JsonProperty("Id")]
        public Guid Id { get; set; }


       [JsonProperty("FirstName")]

        public string FirstName { get; set; }



       [JsonProperty("LastName")]

        public string LastName { get; set; }


       [JsonProperty("Phone")]
       public string Phone { get; set; }


        [JsonProperty("Groups")]
        public ICollection<UpdateGroupDto> Groups { get; set; }
       
    }
}
