using Center.API.Dtos;
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
    /// Interaction logic for StudentEditView.xaml
    /// </summary>
    public partial class StudentEditView : Window
    {
        IStudentService studentService = new StudentService();
        IGroupService groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        StudentViewModel studentViewModel = new StudentViewModel();
        ICollection<GroupViewModel> groupViewModels = new List<GroupViewModel>();
        string idstudent;
        Guid ids;
        string newfirstname, newlastname;

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //teacherni serverdan yuklab olamiz

            studentViewModel = await studentService.GetByIdStudentAsync(ids);

            //textboxlarga qiymatlarni joylaymiz


            int index = studentViewModel.FullName.IndexOf(" ");

            newfirstname = studentViewModel.FullName.Substring(0, index);
            newlastname = studentViewModel.FullName.Substring(index + 1);


            FirstName_txt.Text = newfirstname;
            LastName_txt.Text = newlastname;
            Phone_txt.Text = studentViewModel.Phone;



            //guruhlarni serverdan yuklab olayapmiz
            foreach (var i in studentViewModel.Groups)
            {
                var grp = await groupService.GetByIdGroup(i.Id);
                groupViewModels.Add(new GroupViewModel()
                {
                    Id = grp.Id,
                    GuruhNomi = grp.GuruhNomi,
                    Fan = grp.Fan
                });

            }


            //datagridga joylayapmiz
            Groups_datagrid.ItemsSource = groupViewModels;


        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            studentViewModel = await studentService.GetByIdStudentAsync(ids);

            if (FirstName_txt.Text != "" && LastName_txt.Text != "" && Phone_txt.Text != "")
            {

                UpdateStudentDto updateStudentDto = new UpdateStudentDto();
                updateStudentDto.Id = studentViewModel.Id;
                updateStudentDto.FirstName = FirstName_txt.Text;
                updateStudentDto.LastName = LastName_txt.Text;
                updateStudentDto.Phone = Phone_txt.Text;

                string res = await studentService.UpdateStudent(ids, updateStudentDto);



                if (res is not null)
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

                MessageBox.Show("Malumotlar tuliq kiritilmadi");

            }
        }

        public StudentEditView(string id)
        {
            InitializeComponent();
            idstudent = id;
            bool b = Guid.TryParse(idstudent, out ids);
        }
    }
}
