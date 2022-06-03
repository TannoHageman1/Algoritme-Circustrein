using AlgoritmeCircusTreinLibrary;
using AlgoritmeCircusTreinLibrary.Entities;
using AlgoritmeCircusTreinLibrary.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace AlgoritmeCircusTreinUnitTests
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
            try
            {
                //Arrange
                Dier dierTeGroot = new Dier(false, 0);

                //Assert
                Assert.Fail("DierSizeException not thrown");
            }
            catch (DierSizeException) { }
        }

        [TestMethod]
        public void TestLongListSort()
        {
            //Arrange
            List<Dier> dieren = new List<Dier>
            {
                new Dier(true, 1),
                new Dier(true, 5),
                new Dier(true, 1),
                new Dier(true, 3),
                new Dier(false, 5),
                new Dier(false, 3),
                new Dier(false, 1),
                new Dier(false, 1),
                new Dier(false, 1),
                new Dier(false, 3),
                new Dier(false, 5),
                new Dier(true, 1),
            };
            TreinLogica logica = new TreinLogica();
            Trein trein = new Trein();

            //Assert
            logica.VulTrein(trein, dieren);

            //Act
            foreach(Wagon wagon in trein.WagonList)
            {
                Assert.IsTrue(IsWagonCorrectGevuld(wagon));
            }
        }

        private bool IsWagonCorrectGevuld(Wagon wagon)
        {
            if (wagon.GetBezetheid() < 0 || wagon.GetBezetheid() > 10) return false;
            
            foreach(Dier dier in wagon.GetDieren())
            {
                if (dier.IsCarnivoor)
                {
                    if (wagon.CarnivoorCheck(dier)) return false;
                }
            }

            return true;
        }
    }
}