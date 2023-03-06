﻿using System;
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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Frame frame1;
        public Registration(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Authorization(frame1));
        }

        private void registration_Click(object sender, RoutedEventArgs e)
        {
            string log = login.Text;
            string pas = password.Text;
            string pas1 = password_Copy.Text;
            if (log != "")
            {
                if(pas != "")
                {
                    if(pas == pas1)
                    {
                        List<UP.Users> user = new List<UP.Users>() { new Users()};
                        int count = Entities1.GetContex().Users.Count();
                        user[0].id = count+ 1;
                        user[0].login = log;
                        user[0].password = pas1;
                        Entities1.GetContex().Users.Add(user[0]);
                        Entities1.GetContex().SaveChanges();
                        frame1.Navigate(new Authorization(frame1));
                    }
                    else
                    {
                        MessageBox.Show("Пароли не совпадают");
                    }
                }
                else
                {
                    MessageBox.Show("Введите пароль");
                }
            }
            else
            {
                MessageBox.Show("Введите логин");
            }
        }
    }
}
