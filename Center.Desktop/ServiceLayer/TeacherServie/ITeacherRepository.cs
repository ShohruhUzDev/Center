using Center.API.Dtos;
using Center.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.TeacherServie
{
   public  interface ITeacherRepository
    {
        Task<IEnumerable<TeacherViewModel>> GetAllTeachersAsync();
        Task<TeacherViewModel> GetbyIdTeacherAsync(Guid id);
        Task<string> CreateTeacherAsync(TeacherForCreationDto teacher);
        Task<string> UpdateTeacher(Guid id, ReadTeacherDto teacher);
        Task<string> DeleteTeacher(Guid id);
       // bool ExistTeacher(Guid id);
    }
}
