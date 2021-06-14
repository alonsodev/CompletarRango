using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using CompletarRango;
namespace UnitTestCompletarRango
{
    [TestClass]
    public class RangoTests
    {
        [TestMethod]
        public void CompletarRango_Caso1() {
            List<int> numeros = new List<int>() { 2, 1, 4, 5 };
            List<int> esperado = new List<int>() { 1,2,3,4,5 };

            var rangos = new Rangos();
            var actual = rangos.CompletarRango(numeros);
            CollectionAssert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CompletarRango_Caso2()
        {
            List<int> numeros = new List<int>() { 100, 96, 101, 102, 105 };
            List<int> esperado = new List<int>() { 96, 97, 98, 99, 100, 101, 102, 103, 104, 105};

            var rangos = new Rangos();
            var actual = rangos.CompletarRango(numeros);
            CollectionAssert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void CompletarRango_Caso3()
        {
            List<int> numeros = new List<int>() { 22, 25 };
            List<int> esperado = new List<int>() { 22, 23, 24, 25 };

            var rangos = new Rangos();
            var actual = rangos.CompletarRango(numeros);
            CollectionAssert.AreEqual(esperado, actual);
        }
    }
}
