using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Baza1;
using System.Data.Common;

namespace Test
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void ZwrocInstancje()
        {
            // Given
            DataBaseConnector connector;

            // When
            connector = DataBaseConnector.Instance;

            // Then
            Assert.IsNotNull(connector);
            Assert.IsInstanceOfType(connector, typeof(DataBaseConnector));
        }

        [TestMethod]
        public void ZwrocZapytanie()
        {
            // Given
            DataBaseConnector connector = DataBaseConnector.Instance;

            // When
            DbDataReader reader = connector.Query("SELECT * FROM Contacts");
            reader.Close();

            // Then
            Assert.IsNotNull(reader);
            Assert.IsInstanceOfType(reader, typeof(DbDataReader));
            Assert.IsTrue(reader.IsClosed);
        }

        [TestMethod]
        public void DodajDoBazy()
        {
            // Given
            DataBaseConnector connector = DataBaseConnector.Instance;

            // When
            int result = connector.NonQuery("INSERT INTO Contacts VALUES (4, 'Jan', 'Nowak', 123456789)");

            // Then
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void NiePowinienDodacDoBazy()
        {
            // Given
            DataBaseConnector connector = DataBaseConnector.Instance;
            Exception ex = null;

            // When
            try
            {
                int result = connector.NonQuery("INSERT INTO Contacts VALUES (4, 'Jan', 'Nowak', 123456789)");
            }
            catch (Exception e)
            {
                ex = e;
            }

            // Then
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(System.Data.SqlClient.SqlException));
        }
    }
}
