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
        public async Task CreateStudentAsync(Student group)
        {
            await _studentContext.Students.AddAsync(group);
            await _studentContext.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
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

        public bool ExistStudent(int id)
        {
            return _studentContext.Students.Any(e => e.Id == id);
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
           return await _studentContext.Students.ToListAsync();
        }

        public async Task<Student> GetbyIdStudentAsync(int id)
        {
           return await _studentContext.Students.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task UpdateStudentAsync(Student group1)
        {
            _studentContext.Entry(group1).State = EntityState.Modified;
            await _studentContext.SaveChangesAsync();
        }
    }
}
