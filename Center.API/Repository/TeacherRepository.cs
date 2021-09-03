using Center.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly CenterContext _centerContext;

        public TeacherRepository(CenterContext centerContext)
        {
            _centerContext = centerContext;
        }
        public async Task CreateTeacherAsync( Teacher teacher)
        {
           await _centerContext.Teachers.AddAsync(teacher);
           await _centerContext.SaveChangesAsync();
        }

        public async Task DeleteTeacher(Guid id)
        {
            if(ExistTeacher(id))
            {
                var deleteteacher = _centerContext.Teachers.FirstOrDefaultAsync(i => i.Id == id);
                _centerContext.Teachers.Remove(await deleteteacher);
              await  _centerContext.SaveChangesAsync();
            }
        }

        public bool ExistTeacher(Guid id)
        {
            return _centerContext.Teachers.Any(i => i.Id == id);
        }

       

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            return await _centerContext.Teachers.Include(grp=>grp.Groups).ToListAsync();
           
        }

      

        public async Task<Teacher> GetbyIdTeacherAsync(Guid id)
        {
            return await _centerContext.Teachers.Include(grp=>grp.Groups).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateTeacherAsync(Teacher teacher)
        {
            _centerContext.Entry(teacher).State = EntityState.Modified;
            await _centerContext.SaveChangesAsync();
        }
    }
}
