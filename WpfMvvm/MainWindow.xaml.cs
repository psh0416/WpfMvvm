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

namespace WpfMvvm
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        Window1 window;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (window == null || !window.IsLoaded)
            {
                window = new Window1();
                //window.DataContext = new Window1ViewModel();
                window.Owner = this;
                window.Show();
            }
        }

        Window1 window2;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (window2 == null || !window2.IsLoaded)
            {
                window2 = new Window1();
                window2.DataContext = new Window1ViewModel();
                window2.Owner = this;
                window2.Show();
            }
        }
    }
}
