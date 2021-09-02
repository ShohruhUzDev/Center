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
        Task<IEnumerable<Group>> GetAllGroupsAsync();
        Task<Group> GetbyIdGroupAsync(Guid id);
        Task CreateGroupAsync(IList<Guid> ids,  Group group);
        Task UpdateGroupAsync(Group group);
        Task DeleteGroup(Guid id);
        bool ExistGroup(Guid id);
    //    Task<IEnumerable<Student>> GetAllStudentsByGroupId(int groupId);
        //Task<IEnumerable< Group>> GetGroupsByTeacherId(int teacherId);
        //Task<IEnumerable< Group>> GetGroupsBySubjectId(int subjectId);


    }
}
