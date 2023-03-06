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
    /// Логика взаимодействия для ServicesWorkers.xaml
    /// </summary>
    public partial class ServicesWorkers : Page
    {
        public Frame frame1;
        string Worker;
        public ServicesWorkers(string workers, Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            Worker = workers;
        }
        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new MENUW(Worker, frame1));
        }

        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
