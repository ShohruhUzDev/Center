using Center.API.Dtos;
using Center.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.StudentService
{
    public  interface IStudentService
    {
        Task<IEnumerable<StudentViewModel>> GetAllStudentsAsync();
        Task<StudentViewModel> GetByIdStudentAsync(Guid studentId);
        Task<string> CreateStudent(CreateStudentDto createStudentDto);
        Task<string> DeleteStudent(Guid id);
        Task<string> UpdateStudent(Guid id, UpdateStudentDto updateStudentDto);
    }
}
