﻿using Center.API.Dtos;
using Center.Desktop.ExternalModels;
using Center.Desktop.ServiceLayer;
using Center.Desktop.ServiceLayer.GroupService;
using Center.Desktop.ServiceLayer.GroupService.Concrete;
using Center.Desktop.ServiceLayer.SubjectService;
using Center.Desktop.ServiceLayer.SubjectService.Concrete;
using Center.Desktop.ServiceLayer.TeacherServie;
using Center.Desktop.ServiceLayer.TeacherServie.Concrete;
using Center.Desktop.View;
using Center.Desktop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace Center.Desktop.Pages.UserControls
{
    /// <summary>
    /// Interaction logic for Teachers.xaml
    /// </summary>
    public partial class Guruhlar : UserControl
    {
        IGroupService _groupService = new GroupService();
        ITeacherRepository teacherRepository = new TeacherRepository();
        ISubjectService subjectService = new SubjectService();
        IEnumerable<GroupViewModel> groupViewModel = new List<GroupViewModel>();

        public Guruhlar()
        {
            InitializeComponent();
        }

        private void Guruhlar_btn_Click(object sender, RoutedEventArgs e)
        {
            CreateGroupView createGroupView = new CreateGroupView();
            createGroupView.ShowDialog();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

           
            groupViewModel = await _groupService.GetAllGroups();

            Guruh_datagrid.ItemsSource = groupViewModel;




            List<TeacherForCBX> teacherForCBX = new List<TeacherForCBX>();

            var teacher = await teacherRepository.GetAllTeachersAsync();
            foreach (var i in teacher)
            {
                teacherForCBX.Add(new TeacherForCBX()
                {
                    Id = i.Id,
                    FullName = i.Name

                });
            }


            List<SubjectForCBX> subjectForCBXes = new List<SubjectForCBX>();
            var subject = await subjectService.GetAllSubjects();

            foreach (var i in subject)
            {
                subjectForCBXes.Add(new SubjectForCBX()
                {
                    Id = i.Id,
                    Name = i.SubjectName
                });
            }


            Teacherlar_Cbx.ItemsSource = teacherForCBX;
            Teacherlar_Cbx.DisplayMemberPath = "FullName";
            Teacherlar_Cbx.SelectedValuePath = "Id";

            Subjectlar_Cbx.ItemsSource = subjectForCBXes;
            Subjectlar_Cbx.DisplayMemberPath = "Name";
            Subjectlar_Cbx.SelectedValuePath = "Id";

        


        }

        private async void Subjectlar_Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            groupViewModel = await _groupService.GetAllGroups();

            var subjectForCBX = (SubjectForCBX) Subjectlar_Cbx.SelectedItem;

           // MessageBox.Show(subjectForCBX.Name);
             var newgroup=   groupViewModel.Where(i => i.Fan == subjectForCBX.Name);

            Guruh_datagrid.ItemsSource = newgroup;

        }

        private async  void Teacherlar_Cbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            groupViewModel = await _groupService.GetAllGroups();
            
            var teacherCBX = (TeacherForCBX)Teacherlar_Cbx.SelectedItem;

            var newteacher = groupViewModel.Where(i => i.Uqituvchi == teacherCBX.FullName);

            Guruh_datagrid.ItemsSource = newteacher;
        }

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            string groupname = SearchGroup_txt.Text;

            groupViewModel = await _groupService.GetAllGroups();

           // var resultgroup = groupViewModel.Where(i =>EF.Functions.Like(i.GuruhNomi, "%"+ groupname+"%"));
            var resultgroup = groupViewModel.Where(i =>i.GuruhNomi.ToUpper().StartsWith( groupname.ToUpper()));

            Guruh_datagrid.ItemsSource = resultgroup;



        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            
            //DataGridRow dataGridRow = sender as DataGridRow ;
            //var fff= dataGridRow.Item[0]
            //MessageBox.Show()
        }
    }
}
