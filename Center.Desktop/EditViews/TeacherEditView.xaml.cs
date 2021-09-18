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
    /// Interaction logic for TeacherEditView.xaml
    /// </summary>
    public partial class TeacherEditView : Window
    {
        IStudentService studentService = new StudentService();
        IGroupService groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        TeacherViewModel teacherViewModel = new TeacherViewModel();
        ICollection<GroupViewModel> groupViewModels = new List<GroupViewModel>();
        string idteacher;
        Guid ids;
        string newfirstname, newlastname;

        public TeacherEditView(string id)
        {
            InitializeComponent();
            idteacher = id;
            bool b = Guid.TryParse(idteacher, out ids);
        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {

            teacherViewModel = await teacherRepository.GetbyIdTeacherAsync(ids);

            if(FirstName_txt.Text!=""&& LastName_txt.Text!="" &&Phone_txt.Text!="")
            {

                ReadTeacherDto updateTeacherDto = new ReadTeacherDto();
                updateTeacherDto.Id = teacherViewModel.Id;
                updateTeacherDto.FirstName = FirstName_txt.Text;
                updateTeacherDto.LastName = LastName_txt.Text;
                updateTeacherDto.Phone = Phone_txt.Text;

                string res = await teacherRepository.UpdateTeacher(ids, updateTeacherDto);



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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {

            //teacherni serverdan yuklab olamiz

            teacherViewModel = await teacherRepository.GetbyIdTeacherAsync(ids);

            //textboxlarga qiymatlarni joylaymiz

           
            int index = teacherViewModel.Name.IndexOf(" ");

            newfirstname = teacherViewModel.Name.Substring(0, index);
            newlastname = teacherViewModel.Name.Substring(index + 1);


            FirstName_txt.Text = newfirstname;
            LastName_txt.Text = newlastname;
            Phone_txt.Text = teacherViewModel.Phone;


          
            //guruhlarni serverdan yuklab olayapmiz
          foreach(var i in teacherViewModel.Groups)
            {
                var grp = await groupService.GetByIdGroup(i.Id);
                groupViewModels.Add(new GroupViewModel()
                {
                 Id=grp.Id,
                 GuruhNomi=grp.GuruhNomi,
                 Fan=grp.Fan
                });

            }


            //datagridga joylayapmiz
            Groups_datagrid.ItemsSource = groupViewModels;





        }
    }
}
