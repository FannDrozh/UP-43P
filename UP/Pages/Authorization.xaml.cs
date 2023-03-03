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
        public bool vx = false;
        public Authorization(Frame frame)
        {
            frame1 = frame;
            InitializeComponent();
        }
        public Authorization()
        {
            InitializeComponent();

        }
        List<UP.Users> users = new List<UP.Users>();

        private void Gues_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new MENU("Guest", frame1));
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            //frame1.Navigate(new Registration(frame1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log = login.Text;
            string pas = password.Password;
            int count = Entities1.GetContex().Users.Count();
            users = Entities1.GetContex().Users.ToList();
            for (int i = 0; i < count; i++)
            {
                if (users[i].login == log)
                {
                    if (users[i].password == pas)
                    {
                        frame1.Navigate(new MENU(users[i].login, frame1));
                        vx = true;
                        break;
                    }
                }
            }
            if (vx == false)
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
