﻿using System;
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
    public class TeachersController : ControllerBase
    {
       
        private readonly ITeacherRepository _teacherRepository;

        public IMapper _mapper { get; }

        public TeachersController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult> GetTeachers()
        {
            var teacher= await _teacherRepository.GetAllTeachersAsync();
            //var teacherdto = new TeacherDto();

            //teacherdto.Guruhlar.Add(_mapper.Map < IEnumerable<CustomGroupDto>>(teacher.Groups));
            
            return Ok(_mapper.Map<IEnumerable< TeacherDto>>(teacher));
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTeacher(Guid id)
        {
            var teacher = await _teacherRepository.GetbyIdTeacherAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TeacherDto>(teacher));
        }

        // PUT: api/Teachers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTeacher(Guid id, Teacher teacher)
        //{
        //    if (id != teacher.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(teacher).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TeacherExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Teachers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTeacher([FromBody] TeacherForCreationDto teacher)
        {
            if (ModelState.IsValid)
            {
                return BadRequest();
            }
            await   _teacherRepository.CreateTeacherAsync(_mapper.Map<Teacher>(teacher));
            
            return Created("", teacher);
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            var teacher = await _teacherRepository.GetbyIdTeacherAsync(id);
            if (teacher == null)
            {
                return NotFound();
            }

          await  _teacherRepository.DeleteTeacher(id);
           

            return Ok("True");
        }

       
    }
}
