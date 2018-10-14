using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace BionicAntCodeTest.UnitTests
{
    [TestFixture]
    public class BionicAntExperimentTests
    {
        //Sample data test
        [Test]
        public void BionicAntExperiment_InputOne_ReturnString()
        {
            BionicAntExperiment experiment = new BionicAntExperiment(5, 5, "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM");
            var resultList = experiment.GenerateResult();
            List<string> expectedList = new List<string>();
            expectedList.Add("1 3 N");
            expectedList.Add("5 1 E");
            Assert.AreEqual(resultList, expectedList);
        }

        //Dynamic input test(add more data set)
        [Test]
        public void BionicAntExperiment_InputTwo_ReturnString()
        {
            BionicAntExperiment experiment = new BionicAntExperiment(5, 5, "1 2 N", "LMLMLMLMM", "3 3 E", "MMRMMRMRRM", "1 1 W", "MMRRMLMRMLM","3 3 E","MLLMRMMRMRLM");
            var resultList = experiment.GenerateResult();
            List<string> expectedList = new List<string>(); 
            expectedList.Add("1 3 N");
            expectedList.Add("5 1 E");
            expectedList.Add("2 3 N");
            expectedList.Add("5 5 E");
            Assert.AreEqual(resultList, expectedList);
        }

        //Boundary test(ant should not leave stamp)
        [Test]
        public void BionicAntExperiment_InputThree_ReturnString()
        {
            BionicAntExperiment experiment = new BionicAntExperiment(5, 5, "1 2 N", "LMLMLMLMMMMMMMMMM", "3 3 E", "MMRMMRMRRMMMMMMMM");
            var expectedList = experiment.GenerateResult();
            List<string> resList = new List<string>();
            resList.Add("1 5 N");
            resList.Add("5 1 E");
            Assert.AreEqual(expectedList, resList);
        }

    }
}
