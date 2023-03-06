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
using UP.Class;

namespace UP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Services.xaml
    /// </summary>
    public partial class Services : Page
    {
        public Frame frame1;
        string User;
        Navig sp = new Navig();
        List<Service> List_Service = new List<Service>();
        List<Users> historys = new List<Users>();
        int kolvo_zapice = 3;
        public Services(string user, Frame frame)
        { 
            InitializeComponent();
            frame1 = frame;
            User = user;
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new MENU(User, frame1));
        }
        private void Glavnaya_GoPage(object sender, MouseButtonEventArgs e)
        {
            TextBlock tb = (TextBlock)sender;

            switch (tb.Uid)  // определяем, куда конкретно было сделано нажатие
            {
                case "prev":
                    sp.CurrentPage--;
                    break;
                case "next":
                    sp.CurrentPage++;
                    break;
                case "prev1":
                    sp.CurrentPage = 1;
                    break;
                case "next1":
                    {
                        List<Service> fl = Entities1.GetContex().Service.ToList();
                        int a = fl.Count;
                        int b = Convert.ToInt32(kolvo_zapice);

                        if (a % b == 0)
                        {
                            sp.CurrentPage = a / b;
                        }
                        else
                        {
                            sp.CurrentPage = a / b + 1;
                        }
                    }
                    break;
                default:
                    sp.CurrentPage = Convert.ToInt32(tb.Text);
                    break;
            }
            LViewTours.ItemsSource = List_Service.Skip(sp.CurrentPage * sp.CountPageFlower - sp.CountPageFlower).Take(sp.CountPageFlower).ToList();
        }
    }
}
