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
using Center.API.Dtos.TeacherDtos;

namespace Center.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
       
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeachersController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teacher>>> GetTeachers()
        {
            var readteacher = await _teacherRepository.GetAllTeachersAsync();
            return Ok(_mapper.Map<IEnumerable<ReadTeacherDto>>(readteacher));
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> GetTeacher(int id)
        {
            var teacher = await _teacherRepository.GetbyIdTeacherAsync(id) ;

            if (teacher == null)
            {
                return NotFound();
            }
            var readteacher = _mapper.Map<ReadTeacherDto>(teacher);
            return Created("", readteacher);
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, [FromBody] UpdateTeacherDto teacher)
        {
            if (id != teacher.Id)
            {
                return BadRequest();
            }

          

            try
            {
                var teacherupdate = _mapper.Map<Teacher>(teacher);
               await _teacherRepository.UpdateTeacherAsync(teacherupdate);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_teacherRepository.ExistTeacher(id))
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

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Teacher>> PostTeacher( [FromBody] CreateTeacherDto teacher)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var createteacher = _mapper.Map<Teacher>(teacher);
           await _teacherRepository.CreateTeacherAsync(createteacher);

            var readteacher = _mapper.Map<ReadTeacherDto>(createteacher);

            return Created("",  readteacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            if(!_teacherRepository.ExistTeacher(id))
            {
                return NotFound();
               
            }

            await _teacherRepository.DeleteTeacher(id);
          

            return Ok("true");



        }

       
    }
}
