using Center.API.Dtos;
using Center.Desktop.ExternalModels;
using Center.Desktop.ServiceLayer.GroupService;
using Center.Desktop.ServiceLayer.GroupService.Concrete;
using Center.Desktop.ServiceLayer.SubjectService;
using Center.Desktop.ServiceLayer.SubjectService.Concrete;
using Center.Desktop.ServiceLayer.TeacherServie;
using Center.Desktop.ServiceLayer.TeacherServie.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Center.Desktop.View
{
    /// <summary>
    /// Interaction logic for CreateGroupView.xaml
    /// </summary>
    public partial class CreateGroupView : Window
    {
        IGroupService groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        public CreateGroupView()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           List< TeacherForCBX> teacherForCBX = new List<TeacherForCBX>() ;
            var teacher = await teacherRepository.GetAllTeachersAsync();
            

            foreach(var i in teacher)
            {
                teacherForCBX.Add(new TeacherForCBX()
                {
                    Id = i.Id,
                    FullName = i.Name
                });
               
            }

            List<SubjectForCBX> subjectForCBXes = new List<SubjectForCBX>();

            var subjects = await subjectService.GetAllSubjects();

            foreach (var u in subjects)
            {
                subjectForCBXes.Add(new SubjectForCBX()
                {
                    Id = u.Id,
                    Name = u.SubjectName
                });
            }


            Teacher_cbx.ItemsSource = teacherForCBX;
            Teacher_cbx.DisplayMemberPath = "FullName";
            Teacher_cbx.SelectedValuePath = "Id";

            Subject_cbx.ItemsSource = subjectForCBXes;
            Subject_cbx.DisplayMemberPath = "Name";
            Subject_cbx.SelectedValuePath = "Id";
           

        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateGroupDto createGroupDto = new CreateGroupDto();


            
             
            if(Teacher_cbx.SelectedIndex!=-1&&Subject_cbx.SelectedIndex!=-1&& GroupName_txt.Text!="")
            {
                Guid teacherid = new Guid();

                bool b = Guid.TryParse(Teacher_cbx.SelectedValue.ToString(), out teacherid);



                Guid subjectid = new Guid();

                bool c = Guid.TryParse(Subject_cbx.SelectedValue.ToString(), out subjectid);

                createGroupDto.GroupName = GroupName_txt.Text;
                createGroupDto.TeacherId = teacherid;
                createGroupDto.SubjectId = subjectid;

            }
            else
            {
                MessageBox.Show("Elementlari tuliq tanlanmadi");
                GroupName_txt.Clear();
            }
            string res= await groupService.CreateGroup(createGroupDto);

            if (res is not null)

            {
                MessageBox.Show("Guruh yaratildi"); 
                this.Hide();
            }

            else
            {
                MessageBox.Show("Xatolik yuz berdi");
            }
          
        }
    }
}
