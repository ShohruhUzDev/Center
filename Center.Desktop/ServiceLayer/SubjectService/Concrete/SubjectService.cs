using Center.API.Dtos;
using Center.Desktop.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.SubjectService.Concrete
{
    public class SubjectService : ISubjectService
    {
        public async Task<string> CreateSubject(SubjectForCreationDto subjectForCreationDto)
        {
          
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(SubjectAPI.Post_URL);


                string json = JsonConvert.SerializeObject(subjectForCreationDto);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync(client.BaseAddress, stringContent);

                if(res.StatusCode==System.Net.HttpStatusCode.Created)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
            }
        }

        public async Task<string> DeleteSubject(Guid id)
        {
                  using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(SubjectAPI.Delete_URL + $"/{id}");
                var res = await client.DeleteAsync(client.BaseAddress);

                if(res.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
            }
        }

        public async Task<IEnumerable<SubjectViewModel>> GetAllSubjects()
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(SubjectAPI.GetAll_URL);

                var res = await client.GetAsync(client.BaseAddress);

                string response = await res.Content.ReadAsStringAsync();

                IEnumerable<ReadSubject> readSubjects = JsonConvert.DeserializeObject<IEnumerable<ReadSubject>>(response);

                List<SubjectViewModel> subjectViewModels = new List<SubjectViewModel>();

                foreach(var i in readSubjects)
                {
                    subjectViewModels.Add(new SubjectViewModel()
                    {
                        Id=i.Id,
                        SubjectName=i.SubjectName,
                        Price=i.Price,
                        Groups=i.Groups
                    });

                }


                return subjectViewModels;
            }
        }

        public async Task<SubjectViewModel> GetByIdSubject(Guid id)
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(SubjectAPI.Get_URL +$"/{id}");

                var res = await client.GetAsync(client.BaseAddress);

                string response = await res.Content.ReadAsStringAsync();
                ReadSubject readSubject = JsonConvert.DeserializeObject<ReadSubject>(response);

                SubjectViewModel subjectViewModel = new SubjectViewModel();
                subjectViewModel.Id = readSubject.Id;
                subjectViewModel.SubjectName = readSubject.SubjectName;
                subjectViewModel.Price = readSubject.Price;
                subjectViewModel.Groups = readSubject.Groups;


                return subjectViewModel;


            }
        }

        public async Task<string> UpdateSubject(Guid id, ReadSubjectDto customSubjectDto)
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(SubjectAPI.Put_URL + $"/{id}");


                var json = JsonConvert.SerializeObject(customSubjectDto);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync(client.BaseAddress, stringContent);


                if(res.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    return await res.Content.ReadAsStringAsync();
                }

                return null;
            }
        }
    }
}
