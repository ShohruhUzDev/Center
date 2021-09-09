using AutoMapper;
using Center.API.Dtos;
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
            CreateMap< Group, GroupDto>().ReverseMap();
            CreateMap< Group, GroupFroCreationDto>().ReverseMap();
            CreateMap< Group, UpdateGroupDto>().ReverseMap();
            CreateMap< Group, CustomGroupDto>().ReverseMap();


            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentForCreationDto>().ReverseMap();
            CreateMap<Student, UpdateStudentDto>().ReverseMap();

            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<Subject, SubjectForCreationDto>().ReverseMap();
            CreateMap<Subject, CustomSubjectDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Teacher, TeacherForCreationDto>().ReverseMap();
            CreateMap<Teacher, CustomTeacherDto>().ReverseMap();







        }
    }
}
