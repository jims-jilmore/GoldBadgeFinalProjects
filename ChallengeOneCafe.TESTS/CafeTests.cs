using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ChallengeOneCafe.REPO;
using ChallengeOneCafe.POCO;

namespace ChallengeOneCafe.TESTS
{
   

    [TestClass]
    public class CafeRepoTests
    {
        CafeREPO _cafeREPO = new CafeREPO();
        MenuItem _menuItem = new MenuItem();

        [TestMethod]
        public void CreateMenuItem_ShouldEqualTrue()
        {
            bool expected = true;
            bool actual = _cafeRepo.CreateMenuItem(_menuItem);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ViewMenuList_ShouldReturnList()
        {
            
        }

    }
}
