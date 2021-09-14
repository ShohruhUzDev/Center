using Center.API.Dtos;
using Center.Desktop.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.StudentService.Concrete
{
    public class StudentService : IStudentService
    {
        public Task<string> CreateStudent(CreateStudentDto createStudentDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteStudent(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StudentViewModel>> GetAllStudentsAsync()
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(StudentAPI.GetAll_URL);

                var res = await client.GetAsync(client.BaseAddress);

                string response = await res.Content.ReadAsStringAsync();

                IEnumerable<ReadStudent> readStudents = JsonConvert.DeserializeObject<IEnumerable<ReadStudent>>(response);

                List<StudentViewModel> studentViewModels = new List<StudentViewModel>();

                foreach(var i in readStudents)
                {
                    studentViewModels.Add(new StudentViewModel()
                    {
                        Id = i.Id,
                        FullName = i.FirstName + " " + i.LastName,
                        Phone = i.Phone,
                        Groups = i.Groups
                    });
                }
                return studentViewModels;

            }
        }

        public Task<StudentViewModel> GetByIdStudentAsync(Guid studentId)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateStudent(UpdateStudentDto updateStudentDto)
        {
            throw new NotImplementedException();
        }
    }
}
