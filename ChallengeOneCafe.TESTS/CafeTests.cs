using Microsoft.VisualStudio.TestTools.UnitTesting;
using ChallengeOneCafe.REPO;
using ChallengeOneCafe.POCO;
using System.Collections.Generic;

namespace ChallengeOneCafe.TESTS
{


    [TestClass]
    public class CafeRepoTests
    {
        CafeREPO _cafeRepo = new CafeREPO();
        MenuItem _menuItem = new MenuItem();

        [TestMethod]
        public void CreateMenuItem_ShouldReturnTrue()
        {
            Assert.IsTrue(_cafeRepo.CreateMenuItem(_menuItem));
        }

        [TestMethod]
        public void ListAllSides_ShouldReturnListString()
        {
            _cafeRepo.CreateMenuItem(_menuItem);
            List<string> sides = new List<string>();
            _menuItem.SideIngredients = sides;
            List<string> expected = new List<string>();

            CollectionAssert.Equals(expected, sides);
        }

        [TestMethod]
        public void ViewMenuList_ShouldReturnListMenuItems()
        {
            List<MenuItem> menu = new List<MenuItem>();
            List<MenuItem> expected = new List<MenuItem>();

            menu = _cafeRepo.ViewMenuList();

            CollectionAssert.Equals(expected, menu);
        }

        [TestMethod]
        public void ViewMenuItem_ShouldReturnMenuItemObject()
        {
            _cafeRepo.CreateMenuItem(_menuItem);

            MenuItem expectedItem = new MenuItem();
            MenuItem itemToPull = _cafeRepo.ViewMenuItem(_menuItem.MealNumber);

            CollectionAssert.Equals(expectedItem, itemToPull);


        }

        [TestMethod]
        public void DeleteMenuItem_ShouldReturnDeletedMenuItem()
        {
            _cafeRepo.CreateMenuItem(_menuItem);
            MenuItem expected = new MenuItem();
            MenuItem itemToDelete = _cafeRepo.DeleteMenuItem(_menuItem.MealNumber);

            CollectionAssert.Equals(expected, itemToDelete);
        }
        [TestMethod]
        public void Remove()
        {
            _cafeRepo.CreateMenuItem(_menuItem);
            bool value =_cafeRepo.Remove(_menuItem.MealNumber);
            Assert.IsTrue(value);
        }
    }
}
