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
        public async Task<string> CreateStudent(CreateStudentDto createStudentDto)
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(StudentAPI.Post_URL);

                var json = JsonConvert.SerializeObject(createStudentDto);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync(client.BaseAddress, stringContent);
                if(res.StatusCode==System.Net.HttpStatusCode.Created)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
            }
        }

        public async Task<string> DeleteStudent(Guid id)
        {
          using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(StudentAPI.Delete_URL + $"/{id}");
                var res = await client.DeleteAsync(client.BaseAddress);

                if(res.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
            }
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

        public async Task<StudentViewModel> GetByIdStudentAsync(Guid studentId)
        {
           using (var client =new HttpClient())
            {
                client.BaseAddress = new Uri(StudentAPI.Get_URL + $"/{studentId}");

                var res = await client.GetAsync(client.BaseAddress);
                string responce = await res.Content.ReadAsStringAsync();

                ReadStudent readStudent = JsonConvert.DeserializeObject<ReadStudent>(responce);

                StudentViewModel studentViewModel = new StudentViewModel();
                studentViewModel.Id = readStudent.Id;
                studentViewModel.FullName = readStudent.FirstName + " " + readStudent.LastName;
                studentViewModel.Phone = readStudent.Phone;
                studentViewModel.Groups = readStudent.Groups;

                return studentViewModel;


            }

        }

        public async Task<string> UpdateStudent(Guid id, UpdateStudentDto updateStudentDto)
        {
            using (var clien=new HttpClient())
            {
                clien.BaseAddress = new Uri(StudentAPI.Put_URL + $"/{id}");

                var json = JsonConvert.SerializeObject(updateStudentDto);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");


                var res = await clien.PutAsync(clien.BaseAddress, stringContent);

                if(res.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
            }
        }
    }
}
