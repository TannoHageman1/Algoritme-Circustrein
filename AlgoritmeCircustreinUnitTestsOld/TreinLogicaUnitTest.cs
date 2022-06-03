using AlgoritmeCircusTreinLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace AlgoritmeCircustreinUnitTests
{
    [TestClass]
    public class TreinLogicaUnitTest
    {
        [TestMethod]
        public void TestCarnivoorHerbivoorCombinatieCorrect()
        {
            //Arrange
            Dier dierKlein = new Dier(false, 1);
            Dier dierGroot = new Dier(true, 5);
            List<Dier> dieren = new List<Dier>();
            dieren.Add(dierKlein);
            dieren.Add(dierGroot);
            TreinLogica logica = new TreinLogica();
            Trein trein = new Trein();


            //Act
            logica.VulTrein(trein, dieren);

            //Assert
            Assert.AreEqual(trein.WagonList[0].GetDieren()[0], dierKlein);
            Assert.AreEqual(trein.WagonList[1].GetDieren()[0], dierGroot);
        }

        [TestMethod]
        public void TestCarnivoorHerbivoorCombinatieIncorrect()
        {
            //Arrange
            Dier dierKlein = new Dier(false, 5);
            Dier dierGroot = new Dier(true, 1);
            List<Dier> dieren = new List<Dier>();
            dieren.Add(dierKlein);
            dieren.Add(dierGroot);
            TreinLogica logica = new TreinLogica();
            Trein trein = new Trein();


            //Act
            logica.VulTrein(trein, dieren);

            //Assert
            Assert.AreEqual(trein.WagonList[0].GetDieren()[0], dierKlein);
            Assert.AreEqual(trein.WagonList[0].GetDieren()[1], dierGroot);
        }

        [TestMethod]
        public void TestCarnivooorCarnivooorCombinatieCorrect()
        {
            //Arrange
            Dier dierKlein = new Dier(true, 1);
            Dier dierGroot = new Dier(true, 5);
            List<Dier> dieren = new List<Dier>();
            dieren.Add(dierKlein);
            dieren.Add(dierGroot);
            TreinLogica logica = new TreinLogica();
            Trein trein = new Trein();


            //Act
            logica.VulTrein(trein, dieren);

            //Assert

            Assert.AreEqual(trein.WagonList[0].GetDieren()[0], dierKlein);
            Assert.AreEqual(trein.WagonList[1].GetDieren()[0], dierGroot);
        }

        [TestMethod]
        public void TestTreinIsNotNull()
        {
            //Arrange
            Dier dierKlein = new Dier(true, 1);
            Dier dierGroot = new Dier(true, 5);
            List<Dier> dieren = new List<Dier>();
            dieren.Add(dierKlein);
            dieren.Add(dierGroot);
            TreinLogica logica = new TreinLogica();
            Trein trein = new Trein();


            //Act
            logica.VulTrein(trein, dieren);

            //Assert
            Assert.IsNotNull(trein);
        }

        [TestMethod]
        public void TestDierTooLargeException()
        {
            try
            {
                //Arrange
                Dier dierTeGroot = new Dier(false, 6);

                //Assert
                Assert.Fail("DierSizeException not thrown");
            }
            catch (DierSizeException) { }
        }

        [TestMethod]
        public void TestDierTooSmallException()
        {
            try {
                //Arrange
                Dier dierTeGroot = new Dier(false, 0);

                //Assert
                Assert.Fail("DierSizeException not thrown");
            }
            catch (DierSizeException) { }
        }
    }
}
