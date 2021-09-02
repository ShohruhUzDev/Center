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
        Task<Student> GetbyIdStudentAsync(Guid id);
        Task CreateStudentAsync(IList<Guid> ids, Student student);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudent(Guid id);
        bool ExistStudent(Guid id);

    }
}
