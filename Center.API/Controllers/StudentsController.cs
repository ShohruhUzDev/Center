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
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var allstudents = await _studentRepository.GetAllStudentsAsync();
            return Ok(_mapper.Map<IEnumerable<ReadStudentDto>>(allstudents));
        }



        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var studentreadmodel = new ReadStudentDto();
            if (id < 0)
            {
                return BadRequest();
            }
            if (_studentRepository.ExistStudent(id))
            {
                var student1 = await _studentRepository.GetbyIdStudentAsync(id);
                studentreadmodel = _mapper.Map<ReadStudentDto>(student1);
            }

            else
            {
                return NotFound();
            }


            return Ok(studentreadmodel);
            
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(int id, UpdateStudentDto student)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != student.Id)
            {
                return BadRequest();
            }

          

            try
            {
               await _studentRepository.UpdateStudentAsync(_mapper.Map<Student>(student));
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_studentRepository.ExistStudent(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostStudent([FromBody] CreateStudentDto student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var createstudent = _mapper.Map<Student>(student);
          await  _studentRepository.CreateStudentAsync(createstudent);

            var readstudent = _mapper.Map<ReadStudentDto>(createstudent);
            return CreatedAtAction("", readstudent);
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            if(id<0)
            {
                return BadRequest();
            }
           
            if (!_studentRepository.ExistStudent(id))
            {
                return NotFound();
            }
            await _studentRepository.DeleteStudent(id);

            return NoContent();
        }

      

    }
}
