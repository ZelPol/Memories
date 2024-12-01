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

namespace Memories
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //LabelDate.Content = DateTime.Today;
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.IsEnabled = true;
            timer.Tick += (o, e) => { LabelDate.Content = DateTime.Now.ToString(); };
            timer.Start();

        }

        

        private void BtnLogIn_Click(object sender, RoutedEventArgs e)
        {

            if (txtLogin.Text != "" && pbPassword.Password == "")
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            else if (txtLogin.Text == "Admin" && pbPassword.Password == "1234")
            {
                var Admin = new Admin();
                Admin.txtHello.Text = "Привет, " + txtLogin.Text + " " + "!";
                this.Close();
                Admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Ошибка! Проверьте правильность данных!", "Аутентификация", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnOpenSchedule_Click_1(object sender, RoutedEventArgs e)
        {
            var viewinginfo = new viewinginfo();
            this.Close();
            viewinginfo.ShowDialog();
        }

        private void СBOpenPassword_Checked(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox.IsChecked.Value)
            {
                txtOpenPass.Text = pbPassword.Password; // скопируем в TextBox из PasswordBox
                txtOpenPass.Visibility = Visibility.Visible; // TextBox - отобразить 
            }
        }

        private void СBOpenPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            txtOpenPass.Text = "";
        }
    }
}
