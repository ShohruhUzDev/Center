using Center.Desktop.Pages;
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

namespace Center.Desktop
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        ITeacherRepository teacherRepository = new TeacherRepository();
        public Login()
        {
            InitializeComponent();
        }

        private async void Kirish_btn_Click(object sender, RoutedEventArgs e)
        {
            Guid login;
            Guid.TryParse(Login_txt.Text, out login);

            string teachaer = await teacherRepository.DeleteTeacher(login);
            if(teachaer is not null)
            MessageBox.Show("uchhirildi");
            else
                MessageBox.Show("uchirishda xatolik");


            // MessageBox.Show(teachaer.FirstName + "\n" + teachaer.LastName + "\n" + teachaer.Id + "\n" + teachaer.Phone);

            // MainPage mainPage = new MainPage();
            //mainPage.Show();
            //this.Hide();
        }

        private  void Window_Loaded(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
