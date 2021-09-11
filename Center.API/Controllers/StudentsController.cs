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

        public IMapper _mapper { get; }
        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudent(Guid id)
        {
            var student = await _studentRepository.GetbyIdStudentAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDto>(student));
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent(Guid id, UpdateStudentDto student)
        {
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

            return Ok(student);
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentDto>> PostStudent([FromBody] CreateStudentDto student)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }


            var studentdto = _mapper.Map < Student > (student);

            await _studentRepository.CreateStudentAsync(studentdto);
            //  await  _studentRepository.CreateStudentAsync(student.Ids, studentdto);

            var readstudent = _mapper.Map<StudentDto>(studentdto);

            return Created("", readstudent);
        }


        [HttpPut]
        public async Task<ActionResult> AddGroupsToStudent([FromBody] AddGroupsToStudent addGroupsToStudent)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _studentRepository.AddGroupsToStudent(addGroupsToStudent.GroupsId, addGroupsToStudent.StudentId);

            var readstudent = await _studentRepository.GetbyIdStudentAsync(addGroupsToStudent.StudentId);

            return Ok(readstudent);
        }
        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var student = await _studentRepository.GetbyIdStudentAsync(id);
            if (student == null)
            {
                return NotFound();
            }

           await _studentRepository.DeleteStudent(id);
           

            return Ok("true");
        }

       
    }
}
