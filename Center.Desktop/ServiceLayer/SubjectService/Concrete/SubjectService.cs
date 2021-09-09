using Center.API.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer.SubjectService.Concrete
{
    public class SubjectService : ISubjectService
    {
        public Task<string> CreateSubject(SubjectForCreationDto subjectForCreationDto)
        {
          
            using (var client=new HttpClient())
            {
                throw new NotImplementedException();
            }
        }

        public Task<string> DeleteSubject(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Subject>> GetAllSubjects()
        {
            throw new NotImplementedException();
        }

        public Task<Subject> GetByIdSubject(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<string> UpdateSubject(Guid id, CustomSubjectDto customSubjectDto)
        {
            throw new NotImplementedException();
        }
    }
}
