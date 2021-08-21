using Center.API.Dtos;
using Center.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public class GroupRepository : IGroupRepository
    {
        private readonly CenterContext _centercontext;

        public GroupRepository(CenterContext centerContext)
        {
            _centercontext = centerContext;
        }

       

        public async Task CreateGroupAsync(Group group)
        {
            await  _centercontext.Groups.AddAsync(group);
            await _centercontext.SaveChangesAsync();
        }

        public async Task DeleteGroup(int id)
        {
           

            if (ExistGroup(id))
            {
                var deletegroup = _centercontext.Groups.FirstOrDefaultAsync(i => i.Id == id);
                if(deletegroup!=null)
                {
                    _centercontext.Groups.Remove(await deletegroup);
                    _centercontext.SaveChanges();
                }
              

            }

        }

        public  bool ExistGroup(int id)
        {
            return  _centercontext.Groups.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Group>> GetAllGroupsAsync()
        {
            return await _centercontext.Groups.ToListAsync();
        }


        //ishlamayapdi hali
        //public  async Task<IEnumerable<Student>> GetAllStudentsByGroupId(int groupId)
        //{
        //     var result1=await _centercontext.Groups.Include(u => u.Students).FirstOrDefaultAsync(i=>i.Id==groupId);
           
        //    return result1.Students;
        //}

        public async Task<Group> GetbyIdGroupAsync(int id)
        {
           
           return await _centercontext.Groups.FirstOrDefaultAsync(i => i.Id == id);
      
        }



     

        public async Task<IEnumerable<Group>> GetGroupsBySubjectId(int subjectId)
        {
            return await _centercontext.Groups.Where(i => i.Subject.Id == subjectId).ToListAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupsByTeacherId(int teacherId)
        {
            return await _centercontext.Groups.Where(i => i.Teacher.Id == teacherId).ToListAsync();
        }

        public async Task UpdateGroupAsync(Group group)
        {

            _centercontext.Entry(group).State = EntityState.Modified;
           await _centercontext.SaveChangesAsync();
        }
    }
}
