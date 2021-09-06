using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Center.Desktop.ServiceLayer
{
    public class TeacherAPI
    {
        public static string BASE_URL = "https://localhost:44314/api/";
        public static string GetAll_URL = BASE_URL + "Teachers/GetTeachers";
        public static string Get_URL = BASE_URL + "Teachers/GetTeacher";
        public static string Post_URL = BASE_URL + "Teachers/PostTeacher";
        public static string Delete_URL = BASE_URL + "Teachers/DeleteTeacher";
        public static string Put_URL = BASE_URL + "Teachers/PutTeacher";

    }
     
    public class StudentAPI
        {
            public static string BASE_URL = "https://localhost:44314/api/";
            public static string GetAll_URL = BASE_URL + "Students/GetStudents";
            public static string Get_URL = BASE_URL + "Students/GetStudent";
            public static string Post_URL = BASE_URL + "Students/PostStudent";
            public static string Delete_URL = BASE_URL + "Students/DeleteStudent";
            public static string Put_URL = BASE_URL + "Students/PutStudent";


        }
     
    public class SubjectAPI
        {
            public static string BASE_URL = "https://localhost:44314/api/";
            public static string GetAll_URL = BASE_URL + "Subjects/GetSubjects";
            public static string Get_URL = BASE_URL + "Subjects/GetSubject";
            public static string Post_URL = BASE_URL + "Subjects/PostSubject";
            public static string Delete_URL = BASE_URL + "Subjects/DeleteSubject";
            public static string Put_URL = BASE_URL + "Subjects/PutSubject";


        }
      
    public class GroupAPI
     
        {
            public static string BASE_URL = "https://localhost:44314/api/";
            public static string GetAll_URL = BASE_URL + "Groups1/GetGroups";
            public static string Get_URL = BASE_URL + "Groups1/GetGroup";
            public static string Post_URL = BASE_URL + "Groups1/PostGroup";
            public static string Delete_URL = BASE_URL + "Groups1/DeleteGroup";
            public static string Put_URL = BASE_URL + "Groups1/PutGroup";


        }
    
}
