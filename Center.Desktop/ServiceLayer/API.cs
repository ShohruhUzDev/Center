using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer
{
   public  class TeacherAPI
    {
        public static string BASE_URL = "https://localhost:44314/api/";
        public static string GetAll_URL =  BASE_URL+"Teachers/GetTeachers";
        public static string Get_URL =BASE_URL+ "Teacher/Get/";
        public static string Post_URL =BASE_URL+ "Teacher/PostTeacher";
        public static string Delete_URL =BASE_URL+ "Teacher/DeleteTeacher/";
        public static string Put_URL =BASE_URL+ "Teacher/PutTeacher/";


    }
}
