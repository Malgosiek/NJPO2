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
using Baza1;
using System.Data.Common;

namespace Baza2
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

            if (window.ShowDialog() == true)
            {
                Person person = new Person();
                person.Name = window.textBoxName.Text;
                person.LastName = window.textBoxLastName.Text;
                person.PhoneNumber = long.Parse(window.textBoxPhoneNumber.Text);

                int newPersonId;

                list.Add(person);
                InsertPerson(person, out newPersonId);
                person.Id = newPersonId;

                dataGrid.ItemsSource = list;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string query = "SELECT * FROM Contacts";

            DataBaseConnector connector = DataBaseConnector.Instance;
            DbDataReader reader = connector.Query(query);

            while (reader.Read())
            {
                Person p = new Person
                {
                    Id = int.Parse(reader["Id"].ToString()),
                    Name = reader["Name"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = long.Parse(reader["PhoneNumber"].ToString())
                };

                list.Add(p);
            }

            reader.Close();

            dataGrid.ItemsSource = list;
        }

        private bool InsertPerson(Person p, out int personId)
        {
            Person lastPerson = list.OrderBy(x => x.Id).LastOrDefault();
            int id = 1;

            if (lastPerson != null)
            {
                id = lastPerson.Id;
                id++;
            }

            personId = id;

            string query = $"INSERT INTO Contacts VALUES ({id}, '{p.Name}', '{p.LastName}', {p.PhoneNumber})";

            DataBaseConnector connector = DataBaseConnector.Instance;

            int result = connector.NonQuery(query);

            return result > 0;
        }
    }
}
