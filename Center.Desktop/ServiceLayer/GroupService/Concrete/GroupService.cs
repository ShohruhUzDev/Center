using AutoMapper;
using Center.API.Dtos;
using Center.API.Profiles;
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
        IMapper _mapper;
        public GroupService(IMapper mapper)
        {
            _mapper = mapper;
        }
        public Task<string> AddStudentsToGroup(List<Guid> studentsId, Guid groupId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateGroup(CreateGroupDto createGroupDto)
        {
            throw new NotImplementedException();
        }

        public Task<string> DeleteGroup(Guid groupid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupDto>> GetAllGroups()
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(GroupAPI.GetAll_URL);
                var res = await client.GetAsync(client.BaseAddress);
                string response = await res.Content.ReadAsStringAsync();

                IEnumerable<GroupDto> groupDtos = _mapper.Map<IEnumerable< GroupDto>>( JsonConvert.DeserializeObject<IEnumerable< Group>>(response));

                return groupDtos;
            }
        }

        public async Task<GroupDto> GetByIdGroup(Guid groupid)
        {
           using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(GroupAPI.Get_URL + $"{groupid}");
                var res = await client.GetAsync(client.BaseAddress);
                string response = await res.Content.ReadAsStringAsync();
                GroupDto groupDto = _mapper.Map<GroupDto>( JsonConvert.DeserializeObject<Group>(response));
                return groupDto;
            }
        }

        public async Task<string> UpdateGroup(Guid id, UpdateGroupDto updateGroupDto)
        {
           using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri(GroupAPI.Put_URL + $"{id}");

                var sendjson = JsonConvert.SerializeObject(updateGroupDto);
                StringContent stringContent = new StringContent(sendjson, Encoding.UTF8, "application/json");

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
