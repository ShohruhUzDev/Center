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
    /// Interaction logic for Subjects.xaml
    /// </summary>
    public partial class Subjects : UserControl
    {
        IGroupService _groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        IEnumerable<SubjectViewModel> subjectViewModel = new List<SubjectViewModel>();
        public Subjects()
        {
            InitializeComponent();
        }

        private void CreateSubject_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateSubjectView createSubjectView = new CreateSubjectView();
            createSubjectView.ShowDialog();




        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
           
            subjectViewModel = await subjectService.GetAllSubjects();

            Subject_datagrid.ItemsSource = subjectViewModel;

        }

        private async void SearchSubject_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            string subjectname = SearchSubject_txt.Text;

            subjectViewModel = await subjectService.GetAllSubjects();

            // var resultgroup = groupViewModel.Where(i =>EF.Functions.Like(i.GuruhNomi, "%"+ groupname+"%"));
            var resultgroup = subjectViewModel.Where(i => i.SubjectName.ToUpper().StartsWith(subjectname.ToUpper()));

            Subject_datagrid.ItemsSource = resultgroup;

        }

        private void Edit_btn_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = Subject_datagrid;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            string CellValue = ((TextBlock)RowAndColumn.Content).Text;


            SubjectEditView teacherEditView = new SubjectEditView(CellValue);
            teacherEditView.Show();
            MainPage mainPage = new MainPage();
            mainPage.Hide();
        }

        private async void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            DataGrid dataGrid = Subject_datagrid;
            DataGridRow Row = (DataGridRow)dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex);
            DataGridCell RowAndColumn = (DataGridCell)dataGrid.Columns[0].GetCellContent(Row).Parent;
            string CellValue = ((TextBlock)RowAndColumn.Content).Text;

            Guid id;
            bool b = Guid.TryParse(CellValue, out id);

            MessageBoxResult res = MessageBox.Show("Uchirishni hoxlaysizmi?", "Information", MessageBoxButton.YesNo, MessageBoxImage.Question);


            if (res == MessageBoxResult.Yes)
            {
                string result = await subjectService.DeleteSubject(id);
                if (result is not null)
                {
                    MessageBox.Show("Uchirildi");
                }
                else
                {
                    MessageBox.Show("uchirishda xatolik");
                }

            }






            subjectViewModel = await subjectService.GetAllSubjects();
            Subject_datagrid.ItemsSource = subjectViewModel;
        }
    }
}
