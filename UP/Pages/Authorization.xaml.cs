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

namespace UP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Page
    {
        public Frame frame1;
        public int vx = 0;
        public Authorization(Frame frame)
        {
            frame1 = frame;
            InitializeComponent();
        }
        public Authorization()
        {
            InitializeComponent();

        }
        private void reg_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Registration(frame1));
        }
        List<UP.User> users = new List<UP.User>();
        private void Entre_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string klients = login.Text;
            string pas = password.Password;
            int count = Entities.GetContext().Users.Count();
            users = Entities.GetContext().Users.ToList();
            for (int i = 0; i < count; i++)
            {
                if (users[i].login == klients)
                {
                    if (users[i].password == pas)
                    {
                        frame1.Navigate(new Glavnaya(users[i].login, frame1));
                        vx = 1;
                        break;
                    }
                }
            }
            if (vx == 0)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

        private void Reg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Registration(frame1));
        }

        private void Gues_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new Glavnaya("Guest", frame1));
        }
    }
}
