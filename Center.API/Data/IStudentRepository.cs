using Center.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
   public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<Student> GetbyIdStudentAsync(int id);
        Task CreateStudentAsync(Student group);
        Task UpdateStudentAsync(Student group);
        Task DeleteStudent(int id);
        bool ExistStudent(int id);

    }
}
