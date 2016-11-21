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

namespace GUI2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double tmp1, tmp2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            tmp1 = double.Parse(textBox1.Text);
            tmp2 = double.Parse(textBox2.Text);

            if (radioButton1.IsChecked == true)
                Addition(tmp1, tmp2);
            if (radioButton2.IsChecked == true)
                Substraction(tmp1, tmp2);
            if (radioButton3.IsChecked == true)
                Multiplication(tmp1, tmp2);
            if (radioButton4.IsChecked == true)
                Division(tmp1, tmp2);
        }

        private void Addition(double tmp1, double tmp2)
        {
            textBox.Text = "" + (tmp1 + tmp2).ToString();
        }
        private void Substraction(double tmp1, double tmp2)
        {
            textBox.Text = "" + (tmp1 - tmp2).ToString();
        }
        private void Multiplication(double tmp1, double tmp2)
        {
            textBox.Text = "" + (tmp1 * tmp2).ToString();
        }
        private void Division(double tmp1, double tmp2)
        {
            if(tmp2 != 0)
                textBox.Text = "" + (tmp1 / tmp2).ToString();
            else
                textBox.Text = "You can not divide by 0!";
        }
    }
}
