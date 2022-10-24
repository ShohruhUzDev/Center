using Center.API.Dtos;
using Center.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Center.API.Data
{
  public   interface IGroupRepository
    {
        Task<IEnumerable<GroupDto>> GetAllGroupsAsync();
        Task<GroupDto> GetbyIdGroupAsync(Guid id);
        Task CreateGroupAsync( Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroup(Guid id);
        bool ExistGroup(Guid id);
        Task AddStudentsToGroup(IList<Guid> studentsid, Guid groupid);
   

    }
}
