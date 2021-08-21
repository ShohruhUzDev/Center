using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Center.API.Data;
using Center.API.Models;
using Center.API.Dtos;
using AutoMapper;

namespace Center.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupsController(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        // GET: api/Groups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroups()
        {
            var allgroups = await _groupRepository.GetAllGroupsAsync();

            return Ok( _mapper.Map<IEnumerable<ReadGroupDto>>(allgroups));
        }


        [HttpGet("{subjectId}")]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroupBySubjectId(int subjectId)
        {

            if (subjectId < 0)
            {
                return BadRequest();
            }
            var groupresult = await _groupRepository.GetGroupsBySubjectId(subjectId);


            return Ok(_mapper.Map<IEnumerable< ReadGroupDto>>(groupresult));
        }


        //[HttpGet("{groupId}")]
        //public async Task<ActionResult> GetAllStudentsGroupId(int groupId)
        //{
        //    var studentresult = await _groupRepository.GetAllStudentsByGroupId(groupId);

        //    return Ok(studentresult);
        //    //return Ok(_mapper.Map<IEnumerable<ReadGroupDto>>(groupresult));
        //}


        [HttpGet("{teacherId}")]
        public async Task<ActionResult<IEnumerable<Group>>> GetGroupByTeacherId(int teacherId)
        {
            if(teacherId<0)
            {
                return BadRequest();
            }
            var groupresult = await _groupRepository.GetGroupsByTeacherId(teacherId);


            return Ok(_mapper.Map<IEnumerable<ReadGroupDto>>(groupresult));
        }

        //GET: api/Groups/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGroup(int id)
        {
            var groupreadmodel = new ReadGroupDto();
            if (id<0)
            {
                return BadRequest();
            }
            if(_groupRepository.ExistGroup(id))
            {
                var group1 = await _groupRepository.GetbyIdGroupAsync(id);
                 groupreadmodel = _mapper.Map<ReadGroupDto>(group1);
            }
           
            else
            {
                return NotFound();
            }
           

            return Ok(groupreadmodel);
        }

        // PUT: api/Groups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup(int id, [FromBody] UpdateGroupDto group1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != group1.Id)
            {
                return BadRequest();
            }
   
            try
            {
               
                await _groupRepository.UpdateGroupAsync(_mapper.Map<Group>(group1));
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

        // POST: api/Groups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostGroup( [FromBody] CreatedGroupDto group1)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var groupmodel = _mapper.Map<Group>(group1);
           await _groupRepository.CreateGroupAsync(groupmodel);

            var groumodelread = _mapper.Map<ReadGroupDto>(groupmodel);
            return Created("",  groumodelread);
        }

        //DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(int id)
        {
            if(id<0)
            {
                return BadRequest();
            }
            if(!_groupRepository.ExistGroup(id))
            {
                return BadRequest();
            }
            var deletegroup = await _groupRepository.GetbyIdGroupAsync(id);
            if (deletegroup == null)
            {
                return NotFound();
            }

           await _groupRepository.DeleteGroup(id);
          

            return Ok("True");
        }

      
    }
}
