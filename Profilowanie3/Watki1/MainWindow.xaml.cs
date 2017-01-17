using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Numerics;
using System.IO;

namespace Watki1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static int fileNumber = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bum_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Run(() => CreateFile());
                Thread.Sleep(100);
            }
            // pokaz folder zawierajacy pliki
            Process.Start(AppDomain.CurrentDomain.BaseDirectory);
        }

        public async Task CreateFile()
        {
            var data = new byte[(new Random()).Next(99999, 9999999)];

            // Powoduje zamknięcie zasobu po jego użyciu
            using (var bw = new BinaryWriter(File.OpenWrite($"binary_{++fileNumber}.bin")))
            {
                bw.Write(data);
            }
        }
    }
}
