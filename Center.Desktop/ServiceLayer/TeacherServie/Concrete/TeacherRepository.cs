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
        public Task<bool> CreateTeacherAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTeacher(Guid id)
        {
            throw new NotImplementedException();
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

        public Task<Teacher> GetbyIdTeacherAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
            throw new NotImplementedException();
        }
    }
}
