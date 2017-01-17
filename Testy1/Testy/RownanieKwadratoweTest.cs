using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testy1;
using System.Collections.Generic;
using System.Linq;

namespace Testy
{
    [TestClass]
    public class RownanieKwadratoweTest
    {
        [TestMethod]
        public void ZwrocDodatniaDelte()
        {
            // Given
            RownanieKwadratowe rownanie = new RownanieKwadratowe(1, 10, 2);

            // When
            double delta = rownanie.Delta();

            // Then
            Assert.IsTrue(delta > 0);
        }

        [TestMethod]
        public void ZwrocZerowaDelte()
        {
            // Given
            RownanieKwadratowe rownanie = new RownanieKwadratowe(1, 2, 1);

            // When
            double delta = rownanie.Delta();

            // Then
            Assert.AreEqual(0, delta);
        }

        [TestMethod]
        public void ZwrocUjemnaDelte()
        {
            // Given
            RownanieKwadratowe rownanie = new RownanieKwadratowe(4, 1, 10);

            // When
            double delta = rownanie.Delta();

            // Then
            Assert.IsTrue(delta < 0);
        }

        [TestMethod]
        public void ZwrocDwaMiejscaZerowe()
        {
            // Given
            RownanieKwadratowe rownanie = new RownanieKwadratowe(1, 10, 2);

            // When
            List<double> miejsca = rownanie.MiejscaZerowe();

            // Then
            Assert.AreEqual(2, miejsca.Count);
        }

        [TestMethod]
        public void ZwrocJednoMiejsceZerowe()
        {
            // Given
            RownanieKwadratowe rownanie = new RownanieKwadratowe(1, 2, 1);

            // When
            List<double> miejsca = rownanie.MiejscaZerowe();

            // Then
            Assert.AreEqual(1, miejsca.Count);
        }

        [TestMethod]
        public void BrakMiejscZerowych()
        {
            // Given
            RownanieKwadratowe rownanie = new RownanieKwadratowe(4, 1, 10);

            // When
            List<double> miejsca = rownanie.MiejscaZerowe();

            // Then
            Assert.IsNull(miejsca);
        }
    }
}
