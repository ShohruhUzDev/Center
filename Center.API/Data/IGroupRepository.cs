using Center.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Center.API.Data
{
  public   interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetbyIdGroupAsync(int id);
        Task CreateGroupAsync(Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int id);
        Task<bool> ExistGroup(int id);


    }
}
