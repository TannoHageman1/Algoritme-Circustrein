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
            Trein trein = new Trein();


            //Act
            trein.VulTrein(dieren);

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
            Trein trein = new Trein();

            //Act
            trein.VulTrein(dieren);

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
            Trein trein = new Trein();

            //Act
            trein.VulTrein(dieren);

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
            Trein trein = new Trein();

            //Act
            trein.VulTrein(dieren);

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
            Trein trein = new Trein();

            //Act
            trein.VulTrein(dieren);

            //Act
            foreach (Wagon wagon in trein.WagonList)
            {
                Assert.IsFalse(GetBezetheid(wagon) < 0 || GetBezetheid(wagon) > 10);
                foreach(Dier dier in wagon.GetDieren())
                {
                    if (dier.IsCarnivoor)
                    {
                        Assert.IsFalse(wagon.CarnivoorCheck(dier));
                    }
                }
            }
        }



        public int GetBezetheid(Wagon wagon)
        {
            int bezetheid = 0;
            foreach (Dier dier in wagon.GetDieren())
            {
                bezetheid += dier.Grootte;
            }
            return bezetheid;
        }

        public bool CarnivoorCheck(Dier dier)
        {
            foreach (Dier wagonDier in GetDieren())
            {
                if (!dier.IsGroterDan(wagonDier))
                {
                    if (wagonDier.IsCarnivoor)
                    {
                        return false;
                    }
                }
                else if (dier.IsCarnivoor)
                {
                    return false;
                }
            }

            return true;
        }

        public List<Dier> GetDieren()
        {
            return dieren;
        }
        private List<Dier> dieren;
    }
}