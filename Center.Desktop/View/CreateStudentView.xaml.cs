using Center.API.Dtos;
using Center.Desktop.ServiceLayer.StudentService;
using Center.Desktop.ServiceLayer.StudentService.Concrete;
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

namespace Center.Desktop.View
{
    /// <summary>
    /// Interaction logic for CreateStudentView.xaml
    /// </summary>
    public partial class CreateStudentView : Window
    {
        IStudentService studentService = new StudentService();
        public CreateStudentView()
        {
            InitializeComponent();
        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if (FirstName_txt.Text != "" && LastName_txt.Text != "" && Phone_txt.Text != "")
            {
                CreateStudentDto createStudentDto = new CreateStudentDto()
                {
                    FirstName = FirstName_txt.Text,
                    LastName = LastName_txt.Text,
                    Phone = Phone_txt.Text

                };


                StudentViewModel studentViewModel = new StudentViewModel()
                {
                    FullName = FirstName_txt.Text + " " + LastName_txt.Text,
                    Phone = Phone_txt.Text,

                };




                IEnumerable<StudentViewModel> studentViewModels = new List<StudentViewModel>();
                studentViewModels = await studentService.GetAllStudentsAsync();


                // uqituvchi borligini tekshirish
                if (studentViewModels.Contains(studentViewModel))
                {
                    MessageBox.Show("Bu Uquvchi mavjud");
                }

                else
                {

                    string res = await studentService.CreateStudent(createStudentDto);

                    if (res is not null)
                    {
                        MessageBox.Show("Yangi uquvchi yaratildi");
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Xatolik yuz berdi");
                    }
                }

            }
            else

            {
                MessageBox.Show("Malumotlar tuliq kiritilmadi");
                FirstName_txt.Clear();
                LastName_txt.Clear();
                Phone_txt.Clear();
                FirstName_txt.Focus();
            }


        }
    }
}
