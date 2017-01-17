using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Testy2;

namespace Test
{
    [TestClass]
    public class SortowanieTest
    {
        [TestMethod]
        public void SortowanieSzybszeNizMinuta()
        {
            // Given
            DateTime start, end;
            TimeSpan difference;
            Sortowanie sortowanie = new Sortowanie();

            // When
            start = DateTime.Now;

            sortowanie.Sortuj();

            end = DateTime.Now;

            difference = end.Subtract(start);

            // Then
            Assert.IsTrue(difference.TotalMinutes < 1);
        }

        [TestMethod]
        public void SortowanieWolniejszeNiz10Sekund()
        {
            // Given
            DateTime start, end;
            TimeSpan difference;
            Sortowanie sortowanie = new Sortowanie();

            // When
            start = DateTime.Now;

            for (int i = 0; i < 5; i++)
            {
                sortowanie.Sortuj();
            }

            end = DateTime.Now;

            difference = end.Subtract(start);

            // Then
            Assert.IsTrue(difference.TotalSeconds > 10);
        }

        [TestMethod]
        public void PoprawnaIloscDanych()
        {
            // Given
            Sortowanie sortowanie = new Sortowanie();

            // When
            List<int> posortowane = sortowanie.Sortuj();

            // Then
            Assert.AreEqual(sortowanie.Numbers.Count, posortowane.Count);
        }
    }
}
