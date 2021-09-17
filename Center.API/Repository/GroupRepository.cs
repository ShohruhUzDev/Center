using AutoMapper;
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
        private readonly IMapper _mapper;

        public GroupRepository(CenterContext centerContext , IMapper mapper)
        {
            _centercontext = centerContext;
            _mapper = mapper;
        }

        public async Task AddStudentsToGroup(IList<Guid> studentsid, Guid groupid)
        {
            Group grp = new Group();
            if (ExistGroup(groupid))
            {
              grp = await _centercontext.Groups.FirstOrDefaultAsync(jj=>jj.Id== groupid);
          
            }
           
            foreach (var id in studentsid)
            {
                var student = await _centercontext.Students.FirstOrDefaultAsync(stu => stu.Id == id);
                if (student is not null)
                {
                    grp.Students.Add(student);                }
            }
            _centercontext.Entry(grp).State = EntityState.Modified;
            await _centercontext.SaveChangesAsync();
        }

      

        public async Task CreateGroupAsync(Group group)
        {
            await _centercontext.Groups.AddAsync(group);
            await _centercontext.SaveChangesAsync();
        }

        public async Task DeleteGroup(Guid id)
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

       

        public  bool ExistGroup(Guid id)
        {
            return  _centercontext.Groups.Any(e => e.Id == id);
        }



        public async Task<IEnumerable<GroupDto>> GetAllGroupsAsync()
        {
           
          var grp= _mapper.Map<IEnumerable<GroupDto>>( await _centercontext.Groups.Include(stu => stu.Students).ToListAsync());
            //List< GroupDto> groupDto = new List<GroupDto>();

            foreach (var i in grp)
            {
                var teacher = await _centercontext.Teachers.FirstOrDefaultAsync(j => j.Id == i.TeacherId);
                var subject = await _centercontext.Subjects.FirstOrDefaultAsync(l => l.Id == i.SubjectId);

                i.Teacher = _mapper.Map<ReadTeacherDto>( teacher);
                i.Subject = _mapper.Map<ReadSubjectDto>( subject);
                  
            }


            return grp;

        }


        public async Task<GroupDto> GetbyIdGroupAsync(Guid id)
        {
            GroupDto grp= _mapper.Map<GroupDto>( await _centercontext.Groups.Include(stu => stu.Students).FirstOrDefaultAsync(i => i.Id == id));


            var teacher = await _centercontext.Teachers.FirstOrDefaultAsync(j => j.Id == grp.TeacherId);
            var subject = await _centercontext.Subjects.FirstOrDefaultAsync(l => l.Id == grp.SubjectId);

            grp.Teacher = _mapper.Map<ReadTeacherDto>(teacher);
            grp.Subject = _mapper.Map<ReadSubjectDto>(subject);
            
            return _mapper.Map<GroupDto>(grp);
        }
       

        //public async Task<IEnumerable<Group>> GetGroupsBySubjectId(int subjectId)
        //{
        //    return await _centercontext.Groups.Where(i => i.Subject.Id == subjectId).ToListAsync();
        //}

        //public async Task<IEnumerable<Group>> GetGroupsByTeacherId(int teacherId)
        //{
        //    return await _centercontext.Groups.Where(i => i.Teacher.Id == teacherId).ToListAsync();
        //}

        public async Task UpdateGroupAsync(Group group)
        {

            _centercontext.Entry(group).State = EntityState.Modified;
           await _centercontext.SaveChangesAsync();
        }
    }
}
