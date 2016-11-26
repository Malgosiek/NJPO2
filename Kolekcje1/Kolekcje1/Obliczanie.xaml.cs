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
using System.Windows.Shapes;

namespace Kolekcje1
{
    /// <summary>
    /// Interaction logic for Obliczanie.xaml
    /// </summary>
    public partial class Obliczanie : Window
    {

        public Obliczanie(string text)
        {
            InitializeComponent();

            HashSet<char> hs = new HashSet<char>(text.ToCharArray());

            foreach (char sign in hs)
            {
                if (sign == '\n')
                    textBox.Text += $"Znak: enter\tLiczba: {text.Where(x => x == sign).Count()}\n";
                else if (sign == '\t')
                    textBox.Text += $"Znak: tabulator\tLiczba: {text.Where(x => x == sign).Count()}\n";
                else if (sign == ' ')
                    textBox.Text += $"Znak: spacja\tLiczba: {text.Where(x => x == sign).Count()}\n";
                else if (sign == '\r')
                    textBox.Text += $"Znak: karetka\tLiczba: {text.Where(x => x == sign).Count()}\n";
                else
                    textBox.Text += $"Znak: {sign}\t\tLiczba: {text.Where(x => x == sign).Count()}\n";
            }

            textBlock.Text = "Zakończono obliczanie.";
        }
    }
}
