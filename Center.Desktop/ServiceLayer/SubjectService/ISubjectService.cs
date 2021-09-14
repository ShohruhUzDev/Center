using Center.API.Dtos;
using Center.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.SubjectService
{
    interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetAllSubjects();
        Task<SubjectViewModel> GetByIdSubject(Guid id);
        Task<string> CreateSubject(SubjectForCreationDto subjectForCreationDto);
        Task<string> DeleteSubject(Guid id);
        Task<string> UpdateSubject(Guid id, ReadSubjectDto customSubjectDto);
    }
}
