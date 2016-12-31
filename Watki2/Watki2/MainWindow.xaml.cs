using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
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

namespace Watki2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CancellationTokenSource token;
        private DateTime iterativeTime, recursiveTime;

        public MainWindow()
        {
            InitializeComponent();
        }

        // try catch żeby obsłużyć przerwanie
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            BigInteger factorial = 0;

            if (BigInteger.TryParse(number.Text, out factorial))
            {
                token = new CancellationTokenSource();

                Task.Run(() =>
                {
                    DateTime start = DateTime.Now;

                    BigInteger? result = null;
                    for (int i = 0; i < 100000; i++)
                    {
                        result = IterationFactorial(factorial, token.Token);

                        if (result == null)
                        {
                            break;
                        }
                    }

                    DateTime end = DateTime.Now;
                    TimeSpan difference = end.Subtract(start);

                    if (result != null)
                    {
                        iterative.Dispatcher.InvokeAsync(() => iterative.Content = String.Format("{0:E}", result));
                        timeIter.Dispatcher.InvokeAsync(() => timeIter.Content = $"{difference.Minutes}:{difference.Seconds}:{difference.Milliseconds}");
                    }
                    else
                    {
                        iterative.Dispatcher.InvokeAsync(() => iterative.Content = string.Empty);
                        timeIter.Dispatcher.InvokeAsync(() => timeIter.Content = string.Empty);
                    }

                    return result;
                }, token.Token);


                Task.Run(() =>
                {
                    var start = DateTime.Now;

                    BigInteger? result = null;
                    for (int i = 0; i < 100000; i++)
                    {
                        result = RecursiveFactorial(factorial, token.Token);

                        if (result == null)
                        {
                            break;
                        }
                    }

                    var end = DateTime.Now;
                    var time = end.Subtract(start);

                    if (result != null)
                    {
                        recursive.Dispatcher.InvokeAsync(() => recursive.Content = String.Format("{0:E}", result));
                        timeRec.Dispatcher.InvokeAsync(() => timeRec.Content = $"{time.Minutes}:{time.Seconds}:{time.Milliseconds}");
                    }
                    else
                    {
                        recursive.Dispatcher.InvokeAsync(() => recursive.Content = string.Empty);
                        timeRec.Dispatcher.InvokeAsync(() => timeRec.Content = string.Empty);
                        StopButton.Dispatcher.InvokeAsync(() => StopButton.IsEnabled = false);
                        StartButton.Dispatcher.InvokeAsync(() => StartButton.IsEnabled = true);
                    }

                    return result;
                }).ContinueWith((t) =>
                    {
                        StopButton.Dispatcher.InvokeAsync(() => StopButton.IsEnabled = false);
                        StartButton.Dispatcher.InvokeAsync(() => StartButton.IsEnabled = true);
                    }, token.Token);

                StopButton.IsEnabled = true;
                StartButton.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Zła wartość!");
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            token.Cancel();
        }

        private BigInteger? IterationFactorial(BigInteger number, CancellationToken token)
        {
            try
            {
                BigInteger result = 1;
                for (BigInteger i = 2; i <= number; i++)
                {
                    token.ThrowIfCancellationRequested();
                    result *= i;
                }
                return result;
            }
            catch
            {
                return null;
            }
        }

        private BigInteger? RecursiveFactorial(BigInteger number, CancellationToken token)
        {
            try
            {
                token.ThrowIfCancellationRequested();
                return number == 0 ? 1 : number * RecursiveFactorial(--number, token);
            }
            catch
            {
                return null;
            }
        }
    }
}
