using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Center.API.Data;
using Center.API.Models;
using AutoMapper;
using Center.API.Dtos;

namespace Center.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectRepository _subjectRepository;

        public readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult> GetSubjects()
        {
            var subjects = await _subjectRepository.GetAllSubjectsAsync();
            return Ok(_mapper.Map<IEnumerable<SubjectDto>>(subjects));
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetSubject(Guid id)
        {
            var subject = await _subjectRepository.GetbyIdSubjectAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<SubjectDto>( subject));
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(Guid id, CustomSubjectDto subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

          

            try
            {
                await _subjectRepository.UpdateSubjectAsync(_mapper.Map<Subject>(subject);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_subjectRepository.ExistSubject(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject([FromBody]  SubjectForCreationDto subject)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createsubject = _mapper.Map<Subject>(subject);
            await _subjectRepository.CreateSubjectAsync(createsubject);

            return Created("",  createsubject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Guid id)
        {
            var subject = await _subjectRepository.GetbyIdSubjectAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            await _subjectRepository.DeleteSubject(id);

            return NoContent();
        }

     
    }
}
