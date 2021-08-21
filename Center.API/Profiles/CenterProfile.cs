using AutoMapper;
using Center.API.Dtos;
using Center.API.Dtos.SubjectDtos;
using Center.API.Dtos.TeacherDtos;
using Center.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace Center.API.Profiles
{
    public class CenterProfile:Profile
    {
        public CenterProfile()
        {
            CreateMap<CreatedGroupDto, Group>();
            CreateMap< Group, ReadGroupDto>();
            CreateMap<UpdateGroupDto, Group>();


            CreateMap<CreateStudentDto, Student>();
            CreateMap<Student, ReadStudentDto>();
            CreateMap<UpdateStudentDto, Student>();


            CreateMap<Subject, ReadSubjectDto>();
            CreateMap<CreateSubjectDto, Subject>();
            CreateMap<UpdateSubjectDto, Subject>();


            CreateMap<Teacher, ReadTeacherDto>();
            CreateMap<CreateTeacherDto, Teacher>();
            CreateMap<UpdateTeacherDto, Teacher>();

        }
    }
}
