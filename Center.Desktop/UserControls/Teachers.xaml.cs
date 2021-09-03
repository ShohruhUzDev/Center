using Center.Desktop.View;
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
    /// Interaction logic for Guruhlar.xaml
    /// </summary>
    public partial class Teachers : UserControl
    {
        public Teachers()
        {
            InitializeComponent();
        }

        private void CreateTeacher_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateTeacherView createTeacherView = new CreateTeacherView();
            createTeacherView.ShowDialog();
        }
    }
}
