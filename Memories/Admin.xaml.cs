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
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.IO;

namespace Memories
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        coursesnewEntities CoursesnewEntities = new coursesnewEntities();
        public Admin()
        {
            InitializeComponent();
            foreach (var course in CoursesnewEntities.Courses)
                listboxAdmin.Items.Add(course);
            
        }
        public string photoCopy = "";
        string FinishFolder = @"C:\Users\User\source\repos\Memories\Memories\Resources\"; //"C:\\Resources\\Photo\\"; 

        private void btnBackStart_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            this.Close();
            MainWindow.ShowDialog();
        }

        private void btnImage_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog open = new System.Windows.Forms.OpenFileDialog();
            open.Title = "Выберите изображение";
            open.Filter = "Image files (*.png; *.jpeg; *.jpg)|*.png; *.jpeg; *.jpg|All files (*.*)|*.*";
            open.InitialDirectory = @"C:\";
            if (open.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                photoCopy = open.FileName;
            }
            txtImage.Text = "c:/Resources/Photo" + "/" + System.IO.Path.GetFileName(photoCopy);
            
        }

        private void btnSaveAdmin_Click(object sender, RoutedEventArgs e)
        {
            var course = listboxAdmin.SelectedItem as Courses;
            if (txtName_Course.Text == "" || txtName_Professor.Text == "" || txtAud.Text == "" || DP.Text == "" /*||txtImage.Text == ""*/)
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (course == null)
                {
                    course = new Courses();
                    CoursesnewEntities.Courses.Add(course);
                    listboxAdmin.Items.Add(course);
                }

                course.Image = txtImage.Text.Trim();
                course.Name = txtName_Course.Text;
                course.Professor = txtName_Professor.Text;
                course.Aud = txtAud.Text;
                course.Date = DP.SelectedDate.Value;
                
                CoursesnewEntities.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                listboxAdmin.Items.Refresh();
            }
        }

        private void listboxAdmin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected_course = listboxAdmin.SelectedItem as Courses;
            if (selected_course != null)
            {
                txtName_Course.Text = selected_course.Name;
                txtName_Professor.Text = selected_course.Professor;
                txtImage.Text = selected_course.Image;
                txtAud.Text = selected_course.Aud;
                DP.Text = selected_course.Date.ToString();
            }
            else
            {
                txtName_Course.Text = "";
                txtName_Professor.Text = "";
                txtImage.Text = "";
                txtAud.Text = "";
                DP.Text = "";
                
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var del = MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (del == MessageBoxResult.No)
                return;
            var delete_courses = listboxAdmin.SelectedItem as Courses;
            if (delete_courses != null)
            {
                CoursesnewEntities.Courses.Remove(delete_courses);
                listboxAdmin.Items.Remove(delete_courses);
                CoursesnewEntities.SaveChanges();

                txtName_Course.Clear();
                txtName_Professor.Clear();
                txtAud.Clear();
                txtImage.Clear();
            }
            else
            {
                MessageBox.Show("Нет удаляемых объектов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            try
            {
                var exists_ud = (from structure in CoursesnewEntities.Courses
                                 where structure.Id == delete_courses.Id
                                 select structure).First<Courses>();
            }
            catch
            {

            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtName_Course.Text = "";
            txtName_Professor.Text = "";
            txtAud.Text = "";
            txtImage.Text = "";
        }
    }
}
