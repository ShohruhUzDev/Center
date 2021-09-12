using Center.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.GroupService
{
   public  interface IGroupService
    {
        Task<IEnumerable<GroupDto>> GetAllGroups();
        Task<GroupDto> GetByIdGroup(Guid groupid);
        Task<string> CreateGroup(CreateGroupDto createGroupDto);
        Task<string> UpdateGroup(Guid id,  UpdateGroupDto updateGroupDto);
        Task<string> DeleteGroup(Guid groupid);
        Task<string> AddStudentsToGroup(List<Guid> studentsId, Guid groupId);

    }
}
