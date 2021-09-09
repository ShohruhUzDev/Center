﻿using Center.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Center.API.Dtos
{
    public class CustomGroupDto
    {
        [Required(ErrorMessage = "GroupName is Required")]
        [MaxLength(20, ErrorMessage = "GroupName length is very long")]
        public string GroupName { get; set; }


        public Guid TeacherId { get; set; }


        public Guid SubjectId { get; set; }

    }
    public class GroupDto
    { 
        public Guid Id { get; set; }

        [Required(ErrorMessage = "GroupName is Required")]
        [MaxLength(20, ErrorMessage = "GroupName length is very long")]
        public string GroupName { get; set; }


        public Guid TeacherId { get; set; }


        public Guid SubjectId { get; set; }
        public ICollection<UpdateStudentDto> Studentlar { get; set; }
    
    }
    public class GroupFroCreationDto: CustomGroupDto
    {
        public IList<Guid> Ids { get; set; }
    }
    public class UpdateGroupDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "GroupName is Required")]
        [MaxLength(20, ErrorMessage = "GroupName length is very long")]
        public string GroupName { get; set; }


        public Guid TeacherId { get; set; }


        public Guid SubjectId { get; set; }

    }
    public class GroupForAddStudents    {

        public Guid GroupId { get; set; }
        public IList<Guid> StudentIds { get; set; }
    }
}
