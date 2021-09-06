using Center.API.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.TeacherServie.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        public async Task<bool> CreateTeacherAsync(TeacherForCreationDto teacher)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TeacherAPI.Post_URL);


            string  json = JsonConvert.SerializeObject(teacher);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PostAsync(client.BaseAddress, stringContent);
            string responce =await res.Content.ReadAsStringAsync();
            return responce == "true";



        }
        public async Task<bool> DeleteTeacher(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TeacherAPI.Delete_URL);
            var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
            string responce = await res.Content.ReadAsStringAsync();
            return responce == "true";
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TeacherAPI.GetAll_URL);
            var res =await client.GetAsync(client.BaseAddress);
            string response = await res.Content.ReadAsStringAsync();
           IEnumerable<Teacher> teachers = JsonConvert.DeserializeObject<IEnumerable<Teacher>>(response);
            return teachers;
        }

        public async Task<Teacher> GetbyIdTeacherAsync(Guid id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TeacherAPI.Get_URL);
            var res =await client.GetAsync(client.BaseAddress + $"/{id}");
            string response = await res.Content.ReadAsStringAsync();
            Teacher teacher = JsonConvert.DeserializeObject<Teacher>(response);
            return teacher;
        }

        public async Task<bool> UpdateTeacherAsync(Guid id, Teacher teacher)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(TeacherAPI.Put_URL+$"/{id}");
         
            var json=  JsonConvert.SerializeObject(teacher);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            var res = await client.PutAsync(client.BaseAddress, stringContent);
            string responce = await res.Content.ReadAsStringAsync();
            return responce == "true";
        }
    }
}
