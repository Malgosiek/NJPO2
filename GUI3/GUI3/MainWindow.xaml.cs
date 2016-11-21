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

namespace GUI3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_MouseMove(object sender, MouseEventArgs e)
        {
            Random r = new Random();
            int tmp1, tmp2, tmp3, tmp4;
            tmp1 = r.Next(200);
            tmp2 = r.Next(200);
            tmp3 = r.Next(200-tmp1);
            tmp4 = r.Next(200-tmp2);
            button.Margin = new Thickness(tmp1, tmp2, tmp3, tmp4);
        }
    }
}
