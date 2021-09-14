using Center.Desktop.ServiceLayer.GroupService;
using Center.Desktop.ServiceLayer.GroupService.Concrete;
using Center.Desktop.ServiceLayer.StudentService;
using Center.Desktop.ServiceLayer.StudentService.Concrete;
using Center.Desktop.ServiceLayer.SubjectService;
using Center.Desktop.ServiceLayer.SubjectService.Concrete;
using Center.Desktop.ServiceLayer.TeacherServie;
using Center.Desktop.ServiceLayer.TeacherServie.Concrete;
using Center.Desktop.View;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Center.Desktop.UserControls
{
    /// <summary>
    /// Interaction logic for Students.xaml
    /// </summary>
    public partial class Students : UserControl
    {
        IGroupService _groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        IStudentService studentService = new StudentService();
        IEnumerable<StudentViewModel> groupViewModel = new List<StudentViewModel>();

        public Students()
        {
            InitializeComponent();
        }

        private void CreateStuden_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateStudentView createStudentView = new CreateStudentView();
            createStudentView.ShowDialog();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            groupViewModel = await studentService.GetAllStudentsAsync();


            Student_datagrid.ItemsSource = groupViewModel;

        }

        private async void SearchStudent_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchstudent = SearchStudent_txt.Text;

            groupViewModel = await studentService.GetAllStudentsAsync();

            var res = groupViewModel.Where(i => i.FullName.ToUpper().StartsWith(searchstudent.ToUpper()));

            Student_datagrid.ItemsSource = res;
        }
    }
}
