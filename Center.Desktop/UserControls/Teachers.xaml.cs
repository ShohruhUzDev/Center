using Center.Desktop.EditViews;
using Center.Desktop.Pages;
using Center.Desktop.ServiceLayer.GroupService;
using Center.Desktop.ServiceLayer.GroupService.Concrete;
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
    /// Interaction logic for Guruhlar.xaml
    /// </summary>
    public partial class Teachers : UserControl
    {
        IGroupService _groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        IEnumerable<TeacherViewModel> teacherViewModels = new List<TeacherViewModel>();
        public Teachers()
        {
            InitializeComponent();
        }

        private void CreateTeacher_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateTeacherView createTeacherView = new CreateTeacherView();
            createTeacherView.ShowDialog();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<TeacherViewModel> teacherViewModels = new List<TeacherViewModel>();
            teacherViewModels = await teacherRepository.GetAllTeachersAsync();

            Teacher_datagrid.ItemsSource = teacherViewModels;
        }

        private async void SearchTeacher_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string teacher = SearchTeacher_txt.Text;

            teacherViewModels = await teacherRepository.GetAllTeachersAsync();

            // var resultgroup = groupViewModel.Where(i =>EF.Functions.Like(i.GuruhNomi, "%"+ groupname+"%"));
            var resultteacher = teacherViewModels.Where(i => i.Name.ToUpper().StartsWith(teacher.ToUpper()));

            Teacher_datagrid.ItemsSource = resultteacher;
        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = Teacher_datagrid;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            string CellValue = ((TextBlock)RowAndColumn.Content).Text;


            TeacherEditView teacherEditView = new TeacherEditView(CellValue);
            teacherEditView.Show();
            MainPage mainPage = new MainPage();
            mainPage.Hide();
        }
    }
}
