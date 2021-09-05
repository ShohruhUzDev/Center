using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.TeacherServie
{
   public  interface ITeacherRepository
    {
        Task<IEnumerable<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetbyIdTeacherAsync(Guid id);
        Task<bool> CreateTeacherAsync(Teacher teacher);
        Task<bool> UpdateTeacherAsync(Teacher teacher);
        Task<bool> DeleteTeacher(Guid id);
       // bool ExistTeacher(Guid id);
    }
}
