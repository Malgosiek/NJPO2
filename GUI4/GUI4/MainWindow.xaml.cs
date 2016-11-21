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

namespace GUI4
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string pesel = textBox.Text;
            int[] weight = { 1, 3, 7, 9, 1, 3, 7, 9, 1, 3 };
            int sum = 0;
            
            if(pesel.Length == 11)
            {
                for (int i = 0; i < 10; i++)
                    sum += int.Parse(pesel[i].ToString()) * weight[i];
                sum %= 10;
                sum = 10 - sum;
                sum %= 10;
                if (sum == int.Parse(pesel[10].ToString()))
                {
                    textBlock2.Text = "PESEL poprawny!";
                    System.IO.StreamWriter file = new System.IO.StreamWriter(@"PESEL.txt", true);
                    file.WriteLine(pesel);
                    file.Dispose();
                }
                else
                    textBlock2.Text = "PESEL niepoprawny!";
            }
            else
                textBlock2.Text = "PESEL niepoprawny - zła długość!";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"PESEL.txt");
        }
    }
}
