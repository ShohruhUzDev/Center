﻿using AutoMapper;
using Center.API.Dtos;
using Center.API.Profiles;
using Center.Desktop.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.GroupService.Concrete
{
    public class GroupService : IGroupService
    {
        IMapper mapper;
        public GroupService()
        {
           
        }
        public Task<string> AddStudentsToGroup(List<Guid> studentsId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public async Task<string> CreateGroup(CreateGroupDto createGroupDto)
        {
           using(var client=new HttpClient())
            {
                client.BaseAddress = new Uri(GroupAPI.Post_URL);

                var json = JsonConvert.SerializeObject(createGroupDto);
                StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var res = await client.PostAsync(client.BaseAddress, stringContent);

                if(res.StatusCode==System.Net.HttpStatusCode.Created)
                {
                    return await res.Content.ReadAsStringAsync();
                }
                return null;

            }
        }

        public Task<string> DeleteGroup(Guid groupid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupViewModel>> GetAllGroups()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GroupAPI.GetAll_URL);
                var res = await client.GetAsync(client.BaseAddress);
                string response = await res.Content.ReadAsStringAsync();

                IEnumerable<ReadGroup> groupDtos =JsonConvert.DeserializeObject<IEnumerable<ReadGroup>>(response);

                List<GroupViewModel> groupViewModels = new List<GroupViewModel>();
                foreach (var i in groupDtos)
                {
                    var students = i.Students;
                    List<string> stulist = new List<string>();
                    foreach (var u in students)
                    {
                        stulist.Add(u.FirstName + u.LastName);
                    }
                    if(stulist is not null)
                    {
                        groupViewModels.Add(new GroupViewModel()
                        {
                            Id = i.Id,
                            GuruhNomi = i.GroupName,
                            Fan = i.Subject?.SubjectName,
                            Uqituvchi =(i.Teacher is not null)? i.Teacher.FirstName + i.Teacher?.LastName:"Yuq",
                            Students = stulist
                        });
                    }
                   
                    


                }
                return groupViewModels;
                //  return groupDtos;
            }

        }



            public Task<GroupViewModel> GetByIdGroup(Guid groupid)
            {
                throw new NotImplementedException();
                //using (var client=new HttpClient())
                // {
                //     client.BaseAddress = new Uri(GroupAPI.Get_URL + $"{groupid}");
                //     var res = await client.GetAsync(client.BaseAddress);
                //     string response = await res.Content.ReadAsStringAsync();
                //     GroupDto groupDto = mapper.Map<GroupDto>( JsonConvert.DeserializeObject<Group>(response));
                //     return groupDto;
                // }
            }

            public async Task<string> UpdateGroup(Guid id, UpdateGroupDto updateGroupDto)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(GroupAPI.Put_URL + $"{id}");

                    var sendjson = JsonConvert.SerializeObject(updateGroupDto);
                    StringContent stringContent = new StringContent(sendjson, Encoding.UTF8, "application/json");

                    var res = await client.PutAsync(client.BaseAddress, stringContent);

                    if (res.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return await res.Content.ReadAsStringAsync();
                    }
                    return null;
                }
            }


        }
    }
