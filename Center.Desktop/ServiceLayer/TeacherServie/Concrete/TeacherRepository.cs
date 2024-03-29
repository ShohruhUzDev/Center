﻿using Center.API.Dtos;
using Center.Desktop.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.TeacherServie.Concrete
{
    public class TeacherRepository : ITeacherRepository
    {
        public async Task<string> CreateTeacherAsync(TeacherForCreationDto teacher)
        {
            using(var client=new HttpClient() )
            {
                client.BaseAddress = new Uri(TeacherAPI.Post_URL);


                string json = JsonConvert.SerializeObject(teacher);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync(client.BaseAddress, stringContent);

                if (res.StatusCode == HttpStatusCode.Created)
                {
                    return await res.Content.ReadAsStringAsync();
                }


                else
                    return null;

            }


        }
        public async Task<string> DeleteTeacher(Guid id)
        {
            using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(TeacherAPI.Delete_URL);
                var res = await client.DeleteAsync(client.BaseAddress + $"/{id}");
                if(res.StatusCode==HttpStatusCode.OK)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
               
            }
        }
           
           

        public async Task<IEnumerable<TeacherViewModel>> GetAllTeachersAsync()
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(TeacherAPI.GetAll_URL);
                var res = await client.GetAsync(client.BaseAddress);
                string response = await res.Content.ReadAsStringAsync();
                IEnumerable<Teacher> teachers = JsonConvert.DeserializeObject<IEnumerable<Teacher>>(response);

                List<TeacherViewModel> teacherViewModels = new List<TeacherViewModel>();
                foreach(var i in teachers)
                {
                    teacherViewModels.Add(new TeacherViewModel()
                    {
                        Id = i.Id,
                        Name = i.FirstName + " " + i.LastName,
                        Phone = i.Phone,
                        Groups=i.Groups
                    });

                }

                return teacherViewModels;
            }
          
           
        }

        public async Task<TeacherViewModel> GetbyIdTeacherAsync(Guid id)
        {
            using(var client=new HttpClient())
            {

                client.BaseAddress = new Uri(TeacherAPI.Get_URL);
                var res = await client.GetAsync(client.BaseAddress + $"/{id}");
                string response = await res.Content.ReadAsStringAsync();
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(response);

                TeacherViewModel teacherViewModel = new TeacherViewModel();
                teacherViewModel.Id = teacher.Id;
                teacherViewModel.Name = teacher.FirstName + " " + teacher.LastName;
                teacherViewModel.Phone = teacher.Phone;
                teacherViewModel.Groups = teacher.Groups;





                return teacherViewModel;
            }
            
          
        }

        public async Task<string> UpdateTeacher(Guid id, ReadTeacherDto teacher)
        {

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(TeacherAPI.Put_URL + $"/{id}");

                var json = JsonConvert.SerializeObject(teacher);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PutAsync(client.BaseAddress, stringContent);
                if (res.StatusCode == HttpStatusCode.OK)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;
            }
            
        }
    }
}
