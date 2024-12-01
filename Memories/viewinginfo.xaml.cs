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
using System.Windows.Media.Animation;
using System.IO;

namespace Memories
{
    /// <summary>
    /// Логика взаимодействия для viewinginfo.xaml
    /// </summary>
    public partial class viewinginfo : Window
    {
        coursesnewEntities CoursesnewEntities = new coursesnewEntities();
      
        public viewinginfo()
        {
            
            InitializeComponent();

        }

        



        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            var MainWindow = new MainWindow();
            this.Close();
            MainWindow.ShowDialog();
        }

        private void obnov_Click(object sender, RoutedEventArgs e)
        {
            var query_2 = from x in CoursesnewEntities.Courses
                          join type in CoursesnewEntities.Courses on x.Id equals type.Id
                          select new
                          {
                              Name = x.Name,
                              Date = x.Date,
                              Professor = x.Professor,
                              Aud = x.Aud,
                              Image = x.Image,
                              
                              
                              
                          };
            foreach (var item in query_2)
            {
                DGCourses.Items.Add(item);
            }
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text.Trim()) == false)
            {
                using (coursesnewEntities CoursesnewEntities = new coursesnewEntities())
                    DGCourses.Items.Clear();
                foreach (var item in CoursesnewEntities.Courses)
                {
                    if (item.Name.ToLower().StartsWith(txtSearch.Text.Trim().ToLower()))
                        DGCourses.Items.Add(item);
                }
            }
            else if (txtSearch.Text.Trim() == "")
            {
                using (coursesnewEntities CoursesnewEntities = new coursesnewEntities()) ;
                {
                    DGCourses.Items.Clear();
                    foreach (var item in CoursesnewEntities.Courses)
                        DGCourses.Items.Add(item);
                }
            }
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {
            var WindowUser = new WindowUser();
            this.Close();
            WindowUser.ShowDialog();
        }
    }
}
