using Center.Desktop.ServiceLayer.GroupService;
using Center.Desktop.ServiceLayer.GroupService.Concrete;
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

namespace Center.Desktop.EditViews
{
    /// <summary>
    /// Interaction logic for GroupEditView.xaml
    /// </summary>
    public partial class GroupEditView : Window
    {
        IStudentService studentService = new StudentService();
        IGroupService groupService = new GroupService();
        IEnumerable<GroupViewModel> groupViewModels = new List<GroupViewModel>();
        IEnumerable<StudentViewModel> studentViewModels = new List<StudentViewModel>();
        string idGroup;
        public GroupEditView(string id)
        {
            InitializeComponent();
            idGroup = id;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

           




            MessageBox.Show(idGroup);
        }
    }
}
