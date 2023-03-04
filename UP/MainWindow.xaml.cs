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
using System.Windows.Threading;
using UP.Pages;

namespace UP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _timer;
        public static readonly DependencyProperty TickCounterProperty = DependencyProperty.Register(
            "TickCounter", typeof(int), typeof(MainWindow), new PropertyMetadata(default(int)));
  
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Authorization(MainFrame));
            int count_hh = Entities1.GetContex().Users.Count();
            historys = Entities1.GetContext().history.ToList();
            int time = 0;
            for (int j = count_hh - 1; j >= 0; j--)
            {
                if (historys[j].login == user)
                {
                    DateTime b = (DateTime)historys[j].block;
                    DateTime d = (DateTime)historys[j].date;
                    int h = b.Hour - d.Hour;
                    int m = b.Minute - d.Minute;
                    time = 60 * h + m;
                    break;
                }
            }
            DateTime dateTime = DateTime.Now;
            TickCounter = time;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMinutes(1d);
            _timer.Tick += new EventHandler(Timer_Tick);
            _timer.Start();
        }
    }
}
