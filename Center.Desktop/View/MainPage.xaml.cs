using Center.Desktop.Pages.UserControls;
using Center.Desktop.UserControls;
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

namespace Center.Desktop.Pages
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Window
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void maximize_btn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {

                this.WindowState = WindowState.Maximized;
                maximize_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
            }
            else

            {
                maximize_icon.Kind = MaterialDesignThemes.Wpf.PackIconKind.WindowMaximize;
                this.WindowState = WindowState.Normal;
            }

        }
        private void minimize_btn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;

        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

       
        private void Guruhlar_btn_Click(object sender, RoutedEventArgs e)
        {
            Guruhlar guruhlar = new Guruhlar();
            asosiy_oyna_grid.Children.Add(guruhlar);
        }

        private void Oqituvchilar_btn_Click(object sender, RoutedEventArgs e)
        {
            Teachers teachers = new Teachers();
            asosiy_oyna_grid.Children.Add(teachers);
        }

        private void Oquvchilar_btn_Click(object sender, RoutedEventArgs e)
        {
            Students students = new Students();
            asosiy_oyna_grid.Children.Add(students);
        }

        private void Fanlar_btn_Click(object sender, RoutedEventArgs e)
        {
            Subjects fanlar = new Subjects();
            asosiy_oyna_grid.Children.Add(fanlar);

        }
    }
}
