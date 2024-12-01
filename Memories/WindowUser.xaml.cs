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

namespace Memories
{
    /// <summary>
    /// Логика взаимодействия для WindowUser.xaml
    /// </summary>
    public partial class WindowUser : Window
    {
        coursesnewEntities CoursesnewEntities = new coursesnewEntities();
        public WindowUser()
        {
            InitializeComponent();
            foreach (var course in CoursesnewEntities.Courses)
            cmbCourseForUser.Items.Add(course);
        }

        private void btnCloss_Click(object sender, RoutedEventArgs e)
        {
            var viewinginfo = new viewinginfo();
            this.Close();
            viewinginfo.ShowDialog();
        }

        private void btnSaveUser_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtNameUser.Text == "" || txtSurnameUser.Text == ""|| txtNumberGroupUser.Text == "")
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                var student = new Students();
                student.Name = txtNameUser.Text;
                student.Surname = txtSurnameUser.Text;
                student.NumberGroup = txtNumberGroupUser.Text;
                student.Id_courses = (cmbCourseForUser.SelectedItem as Courses).Id;

                CoursesnewEntities.Students.Add(student);
                CoursesnewEntities.SaveChanges();
                MessageBox.Show("Вы записались на курс!", "Успех!", MessageBoxButton.OK, MessageBoxImage.Information);
                
                
            }
        }
    }
}
