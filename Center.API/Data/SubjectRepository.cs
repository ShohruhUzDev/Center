using AutoMapper;
using Center.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Data
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly CenterContext _centerContext;

        public SubjectRepository(CenterContext centerContext)
        {
            _centerContext = centerContext;
        }
        public async Task CreateSubjectAsync(Subject subject)
        {
            await _centerContext.Subjects.AddAsync(subject);
            await _centerContext.SaveChangesAsync();
              
        }

        public async Task DeleteSubject(int id)
        {
            if(ExistSubject(id))
            {
                var deletesubject = _centerContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);
                _centerContext.Subjects.Remove( await deletesubject);
                await   _centerContext.SaveChangesAsync();
            }
            

        }

        public  bool ExistSubject(int id)
        {
            return  _centerContext.Subjects.Any(i => i.Id == id);
        }

        public async Task<IEnumerable<Subject>> GetAllSubjectsAsync()
        {
            return await _centerContext.Subjects.ToListAsync();
        }

        public async Task<Subject> GetbyIdSubjectAsync(int id)
        {
          
            return await _centerContext.Subjects.FirstOrDefaultAsync(i => i.Id == id);
       
        }

        public async Task UpdateSubjectAsync(Subject subject)
        {
            _centerContext.Entry(subject).State = EntityState.Modified;
           await _centerContext.SaveChangesAsync();
        }
    }
}
