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
    /// Interaction logic for SubjectEditView.xaml
    /// </summary>
    public partial class SubjectEditView : Window
    {

        IStudentService studentService = new StudentService();
        IGroupService groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        SubjectViewModel subjectViewModel = new SubjectViewModel();
        ICollection<GroupViewModel> groupViewModels = new List<GroupViewModel>();
        string idSubject;
        Guid ids;
        public SubjectEditView(string id)
        {
            InitializeComponent();
            idSubject = id;
            bool b = Guid.TryParse(idSubject, out ids);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {


            //teacherni serverdan yuklab olamiz

            subjectViewModel = await subjectService.GetByIdSubject(ids);

            //textboxlarga qiymatlarni joylaymiz


          


            SubjectName_txt.Text = subjectViewModel.SubjectName;
            SubjectPrice_txt.Text = subjectViewModel.Price.ToString();
            



            //guruhlarni serverdan yuklab olayapmiz
            foreach (var i in subjectViewModel.Groups)
            {
                var grp = await groupService.GetByIdGroup(i.Id);
                groupViewModels.Add(new GroupViewModel()
                {
                    Id = grp.Id,
                    GuruhNomi = grp.GuruhNomi,
                    Uqituvchi = grp.Uqituvchi
                });

            }


            //datagridga joylayapmiz
            Groups_datagrid.ItemsSource = groupViewModels;
        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            subjectViewModel = await subjectService.GetByIdSubject(ids);

            if (SubjectName_txt.Text != "" && SubjectPrice_txt.Text != "")
            {

                ReadSubjectDto readSubjectDto = new ReadSubjectDto();
                readSubjectDto.Id = subjectViewModel.Id;
                readSubjectDto.SubjectName = SubjectName_txt.Text;
                readSubjectDto.Price = Convert.ToInt32( SubjectPrice_txt.Text);
              

                string res = await subjectService.UpdateSubject(ids, readSubjectDto);

              
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
    }
}
