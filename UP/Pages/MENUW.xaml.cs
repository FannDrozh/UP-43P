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
    /// Логика взаимодействия для MENUW.xaml
    /// </summary>
    public partial class MENUW : Page
    {
        public Frame frame1;
        string worker;
        public MENUW(string workers, Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            worker = workers;
        }
        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new ServicesWorkers(worker, frame1));
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new TricksW(worker, frame1));
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Authorization(frame1));
        }
    }
}
