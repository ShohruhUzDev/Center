
using Center.API.Dtos;
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
    /// Interaction logic for CreateTeacherView.xaml
    /// </summary>
    public partial class CreateTeacherView : Window
    {
        ITeacherRepository teacherRepository = new TeacherRepository();
        public CreateTeacherView()
        {
            InitializeComponent();
        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if(FirstName_txt.Text!=""&&LastName_txt.Text!=""&&Phone_txt.Text!="")
            {
                TeacherForCreationDto teacherForCreationDto = new TeacherForCreationDto()
                {
                    FirstName = FirstName_txt.Text,
                    LastName = LastName_txt.Text,
                    Phone = Phone_txt.Text

                };


                string res = await teacherRepository.CreateTeacherAsync(teacherForCreationDto);

                if (res is not null)
                {
                    MessageBox.Show("Yangi uqituvchi yaratildi");
                }
                else
                {
                    MessageBox.Show("Xatolik yuz berdi");
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
