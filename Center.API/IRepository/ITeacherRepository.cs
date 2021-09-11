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
        Task<Teacher> GetbyIdTeacherAsync(Guid id);
        Task CreateTeacherAsync( Teacher teacher);
        Task UpdateTeacherAsync(Teacher teacher);
        Task DeleteTeacher(Guid id);
        bool ExistTeacher(Guid id);
       
    }
}
