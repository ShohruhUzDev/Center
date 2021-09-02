using Center.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetbyIdTeacherAsync(int id);
        Task CreateTeacherAsync(Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacher(int id);
        bool ExistTeacher(int id);
     //   Task<IEnumerable<Student>> GetAllStudentsByTeacherId(int teacherId);
        Task<IEnumerable<Group>> GetAsllGroupsByTeacherId(int teacherId);
    }
}
