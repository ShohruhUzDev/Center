using Center.API.Dtos;
using Center.Desktop.ExternalModels;
using Center.Desktop.Pages;
using Center.Desktop.ServiceLayer.GroupService;
using Center.Desktop.ServiceLayer.GroupService.Concrete;
using Center.Desktop.ServiceLayer.StudentService;
using Center.Desktop.ServiceLayer.StudentService.Concrete;
using Center.Desktop.ServiceLayer.SubjectService;
using Center.Desktop.ServiceLayer.SubjectService.Concrete;
using Center.Desktop.ServiceLayer.TeacherServie;
using Center.Desktop.ServiceLayer.TeacherServie.Concrete;
using Center.Desktop.ViewModels;
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

namespace Center.Desktop.EditViews
{
    /// <summary>
    /// Interaction logic for GroupEditView.xaml
    /// </summary>
    public partial class GroupEditView : Window
    {
        IStudentService studentService = new StudentService();
        IGroupService groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        GroupViewModel groupViewModels = new GroupViewModel();
        ICollection<StudentViewModel> studentViewModels = new List<StudentViewModel>();
        string idGroup;
        Guid ids;
        public GroupEditView(string id)
        {
            InitializeComponent();
            idGroup = id;
            bool b = Guid.TryParse(idGroup, out ids);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
          

            groupViewModels = await groupService.GetByIdGroup(ids);


            GroupName_txt.Text = groupViewModels.GuruhNomi;

            foreach( var i in groupViewModels.Students)
            {
                studentViewModels.Add(new StudentViewModel()
                {
                    FullName = i.FirstName + " " + i.LastName,
                    Phone = i.Phone
                });
            }
           

            Students_datagrid.ItemsSource = studentViewModels;



            List<TeacherForCBX> teacherForCBX = new List<TeacherForCBX>();

            var teacher = await teacherRepository.GetAllTeachersAsync();
            foreach (var i in teacher)
            {
                teacherForCBX.Add(new TeacherForCBX()
                {
                    Id = i.Id,
                    FullName = i.Name

                });
            }


            List<SubjectForCBX> subjectForCBXes = new List<SubjectForCBX>();
            var subject = await subjectService.GetAllSubjects();

            foreach (var i in subject)
            {
                subjectForCBXes.Add(new SubjectForCBX()
                {
                    Id = i.Id,
                    Name = i.SubjectName
                });
            }


            Teachers_cbx.ItemsSource = teacherForCBX;
            Teachers_cbx.DisplayMemberPath = "FullName";
            Teachers_cbx.SelectedValuePath = "Id";

            Subjectlar_Cbx.ItemsSource = subjectForCBXes;
            Subjectlar_Cbx.DisplayMemberPath = "Name";
            Subjectlar_Cbx.SelectedValuePath = "Id";





            // MessageBox.Show(idGroup);
        }

       

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {

          
            groupViewModels = await groupService.GetByIdGroup(ids);

            var teacher = await teacherRepository.GetAllTeachersAsync();
  

          
            var subject = await subjectService.GetAllSubjects();

          


            var findteacher = teacher.FirstOrDefault(u => u.Name == groupViewModels.Uqituvchi);
            var findsubject = subject.FirstOrDefault(u => u.SubjectName == groupViewModels.Fan);
           

            if (GroupName_txt.Text!="")
            {
               
                var subjectid = (SubjectForCBX)Subjectlar_Cbx.SelectedItem;
                var teacherid = (TeacherForCBX)Teachers_cbx.SelectedItem;

                UpdateGroupDto updateGroupDto = new UpdateGroupDto();
                updateGroupDto.Id = ids;
                updateGroupDto.GroupName = GroupName_txt.Text;


                //comboboxni tekshirib fanga id junatish
                if(Subjectlar_Cbx.SelectedIndex==-1)
                {
                    if(findsubject is null)
                    {
                        updateGroupDto.SubjectId = Guid.Empty;
                    }
                    else
                    {
                        updateGroupDto.SubjectId = findsubject.Id;
                    }
                   
                }
                else
                {
                    
                    updateGroupDto.SubjectId = subjectid.Id;
                }


                //comboboxni tekshrib teacherid ga id junatish
                if (Teachers_cbx.SelectedIndex == -1)
                {
                    if(findteacher is null)
                    {
                        updateGroupDto.TeacherId = Guid.Empty;
                    }
                    else
                    {
                        updateGroupDto.TeacherId = findteacher.Id;
                    }
                   
                }
                else
                {
                    updateGroupDto.TeacherId = teacherid.Id;
                }

               

                //update qilish
                var res =await groupService.UpdateGroup(ids, updateGroupDto);

                if( res is not null)
                {
                    this.Hide();
                    MainPage mainPage = new MainPage();
                    mainPage.Show();
                }
                else
                {
                    MessageBox.Show("Tizimda xatolik");
                }
            }
            else
            {
                MessageBox.Show("Malumotlar tuliq kiritilmadi!!!");
            }

        }
    }
}
