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

namespace GUI1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string name;

        public MainWindow()
        {
            InitializeComponent();
            textBlock.Text = "Your name: ";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            name = textBox.Text;
            textBlock.Text = "Hello " + name + "!";
            button.Visibility = Visibility.Collapsed;
            textBox.Visibility = Visibility.Collapsed;
        }
    }
}
