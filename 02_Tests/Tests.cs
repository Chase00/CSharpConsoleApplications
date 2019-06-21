using System;
using _02_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Tests
{
    [TestClass]
    public class Tests
    {
        private Repository _repo;
        private Claims _claims;
        private Claims _lateClaims;

        [TestInitialize]
        public void Initialize()
        {
            _repo = new Repository();
            _claims = new Claims(1, TypeOfClaim.Car, "Broken windshield", 250, DateTime.Parse("06/01/2019"), DateTime.Parse("06/04/2019"), true);
            _lateClaims = new Claims(1, TypeOfClaim.Theft, "Stolen purse", 125, DateTime.Parse("06/01/2019"), DateTime.Parse("08/04/2019"), false);
        }

        [TestMethod]
        public void POCOsTest()
        {
            Claims newClaim = new Claims(2, TypeOfClaim.Home, "Hail damage", 650, DateTime.Parse("02/21/2019"), DateTime.Parse("02/27/2019"), true);

            Assert.AreEqual(2, newClaim.ClaimID);
            Assert.AreEqual(TypeOfClaim.Home, newClaim.ClaimType);
            Assert.AreEqual("Hail damage", newClaim.Description);
            Assert.AreEqual(DateTime.Parse("02/21/2019"), newClaim.DateOfIncident);
            Assert.AreEqual(DateTime.Parse("02/27/2019"), newClaim.DateOfClaim);
            Assert.AreEqual(true, newClaim.IsValid);
        }

        [TestMethod]
        public void AddClaimTest()
        {
            _repo.AddClaim(_claims);

            int expected = 1;
            int actual = _repo.GetList().Count;

            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void RemoveClaimTest()
        {
            Repository content = new Repository();

        }

        [TestMethod]
        public void ValidTestTrue()
        {
            _repo.AddClaim(_claims);

            bool expected = true;
            bool actual = _claims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidTestFalse()
        {
            _repo.AddClaim(_lateClaims);

            bool expected = false;
            bool actual = _lateClaims.IsValid;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetListTest()
        {
            _repo.GetList();
            Assert.IsNotNull(_repo);
            
        }
    }
}
