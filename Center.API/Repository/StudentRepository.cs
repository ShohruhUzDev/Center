using Center.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CenterContext _studentContext;

        public StudentRepository(CenterContext studentContext)
        {
            _studentContext = studentContext;
        }
        public async Task CreateStudentAsync(IList<Guid> ids, Student student)
        {
            foreach(var id in ids)
            {
                var grp = await _studentContext.Groups.FirstOrDefaultAsync(i => i.Id == id);

                if(grp is not null)
                {
                    student.Groups.Add(grp);
                }
            }
            await _studentContext.Students.AddAsync(student);
            await _studentContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(Guid id)
        {
            if (ExistStudent(id))
            {
                var deletestudent = await _studentContext.Students.FirstOrDefaultAsync(i => i.Id == id);
                if (deletestudent != null)
                {
                    _studentContext.Students.Remove( deletestudent);
                    _studentContext.SaveChanges();
                }


            }
        }

        public bool ExistStudent(Guid id)
        {
            return _studentContext.Students.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
           return await _studentContext.Students.Include(grp=>grp.Groups).ToListAsync();
        }

        public async Task<Student> GetbyIdStudentAsync(Guid id)
        {
           return await _studentContext.Students.Include(grp=>grp.Groups). FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _studentContext.Entry(student).State = EntityState.Modified;
            await _studentContext.SaveChangesAsync();
        }
    }
}
