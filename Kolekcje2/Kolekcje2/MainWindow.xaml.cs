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
using System.Collections.ObjectModel;

namespace Kolekcje2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> list { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            list = new ObservableCollection<Person>();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            AddContact window = new AddContact();

            if(window.ShowDialog() == true)
            {
                Person person = new Person();
                person.Name = window.textBoxName.Text;
                person.LastName = window.textBoxLastName.Text;
                person.PhoneNumber = long.Parse(window.textBoxPhoneNumber.Text);

                list.Add(person);

                dataGrid.ItemsSource = list;
            }
        }
    }
}
