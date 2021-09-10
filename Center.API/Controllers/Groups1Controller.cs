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
    public class Groups1Controller : ControllerBase
    {
       
        private readonly IGroupRepository _groupRepository;

        public IMapper _mapper { get; }

        public Groups1Controller(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        // GET: api/Groups1
        [HttpGet]
        public async Task<ActionResult> GetGroups()
        {
            var studentlist = new List< UpdateStudentDto>();
            var group= await _groupRepository.GetAllGroupsAsync();
            //foreach (var grp in group)
            //{
            //    foreach(var j in grp.Studentlar)
            //    {
            //        studentlist.Add(_mapper.Map<UpdateStudentDto>(j));
            //        grp.Studentlar.Remove(j);
                    
            //    }
            //    grp.Studentlar = studentlist;
            //}
            
            return Ok(_mapper.Map<IEnumerable<GroupDto>>(group));
            //return Ok(group);
        }

        // GET: api/Groups1/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGroup(Guid id)
        {
            var group1 = await _groupRepository.GetbyIdGroupAsync(id);

            if (group1 == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GroupDto>(group1));
        }

        // PUT: api/Groups1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(Guid id, [FromBody] UpdateGroupDto group1)
        {
            if (id != group1.Id)
            {
                return BadRequest();
            }

           

            try
            {
                await _groupRepository.UpdateGroupAsync(_mapper.Map<Group>( group1));
               
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_groupRepository.ExistGroup(id))
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

        // POST: api/Groups1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Group>> PostGroup([FromBody]  CreateGroupDto group1)
        {
         if(!ModelState.IsValid)
            {
                return BadRequest();
            }
         
            var grp = _mapper.Map<Group>(group1);

            await _groupRepository.CreateGroupAsync(grp);

         


            return Created("", group1);
        }

        [HttpPut]
        public async Task<ActionResult> AddStudentsToGroup([FromBody] GroupForAddStudents group1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            // var grp = _mapper.Map<Group>(group1);

            await _groupRepository.AddStudentsToGroup(group1.StudentIds, group1.GroupId);

            GroupDto newgrp = await _groupRepository.GetbyIdGroupAsync(group1.GroupId);




            return Created("", newgrp);
        }

        // DELETE: api/Groups1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            var @group = await _groupRepository.GetbyIdGroupAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

           await _groupRepository.DeleteGroup(id);
         
            return NoContent();
        }

        //private bool GroupExists(Guid id)
        //{
        //    return _context.Groups.Any(e => e.Id == id);
        //}
    }
}
