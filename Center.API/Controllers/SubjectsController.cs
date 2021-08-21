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
using Center.API.Dtos.SubjectDtos;

namespace Center.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
       
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadSubjectDto>>> GetSubjects()
        {
            return Ok(_mapper.Map<IEnumerable< ReadSubjectDto>>( await _subjectRepository.GetAllSubjectsAsync()));
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadSubjectDto>> GetSubject(int id)
        {
            if(id<0)
            {
                return BadRequest();
            }
            var subject = await _subjectRepository.GetbyIdSubjectAsync(id);

            if (subject == null)
            {
                return NotFound();
            }
            var readsubject = _mapper.Map<ReadSubjectDto>(subject);
            return Created("", readsubject);
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, [FromBody] UpdateSubjectDto subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

           

            try
            {
              await  _subjectRepository.UpdateSubjectAsync(_mapper.Map<Subject>(subject));
              
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
        public async Task<ActionResult<Subject>> PostSubject([FromBody] CreateSubjectDto subject)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            var createsubject = _mapper.Map<Subject>(subject);
           await _subjectRepository.CreateSubjectAsync(createsubject);
            var readsubject = _mapper.Map<ReadSubjectDto>(createsubject);

            return Created("",  readsubject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _subjectRepository.GetbyIdSubjectAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

          await  _subjectRepository.DeleteSubject(id);

            return Ok("true");
        }

       
    }
}
