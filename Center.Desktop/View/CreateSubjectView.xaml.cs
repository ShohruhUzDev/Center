using Center.API.Dtos;
using Center.Desktop.ServiceLayer.SubjectService;
using Center.Desktop.ServiceLayer.SubjectService.Concrete;
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
    /// Interaction logic for CreateSubjectView.xaml
    /// </summary>
    public partial class CreateSubjectView : Window
    {
        ISubjectService subjectService = new SubjectService(); 
        public CreateSubjectView()
        {
            InitializeComponent();
        }

        private async void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            if(SubjectName_txt.Text!=""&&Price_txt.Text!="")
            {
                SubjectForCreationDto subjectForCreationDto = new SubjectForCreationDto();
                subjectForCreationDto.SubjectName = SubjectName_txt.Text;
                subjectForCreationDto.Price = Convert.ToInt32(Price_txt.Text);

               string res= await subjectService.CreateSubject(subjectForCreationDto);

                if(res is not null)
                {
                    MessageBox.Show("Fan yaratildi");
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("Yaratishda xatolik yuzaga keldi");
                }
            }
            else
            {
                MessageBox.Show("Tuliq malumot kiritilmadi");
                SubjectName_txt.Clear();
                Price_txt.Clear();
                SubjectName_txt.Focus();
            }
        }
    }
}
