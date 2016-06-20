using System.Collections.Generic;
using System.Linq;
using BL.Entity;
using BL.Repository;
using BL.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BL.Tests.Service
{
    [TestClass]
    public class StationServiceTests
    {
        [TestMethod]
        public void StartingWithPartialNameTest()
        {
            var ds = new List<string> { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };
            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllThatStartWith("DART")) .Returns((string name) => ds.Where(s => s.StartsWith(name)).ToList());
            var expressions = new SearchResult(new[] { 'F', 'M' }, new[] { "DARTFORD", "DARTMOUTH" });
            var result = new BL.Service.Service(mock.Object).StartingWith("DART");
            Assert.AreEqual(expressions, result);
        }

        [TestMethod]
        public void StartingWithFullNameTest()
        {
            var ds = new List<string> { "DARTFORD", "LIVERPOOL", "PADDINGTON" };
            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllThatStartWith("LIVERPOOL")).Returns((string name) => ds.Where(s => s.StartsWith(name)).ToList());
            var expressions = new SearchResult(new char[0], new[] { "LIVERPOOL" });
            var result = new BL.Service.Service(mock.Object).StartingWith("LIVERPOOL");
            Assert.AreEqual(expressions, result);
        }

        [TestMethod]
        public void StartingWithPartialNameAndBlankSpaceTest()
        {
            var ds = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };
            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllThatStartWith("LIVERPOOL")).Returns((string name) => ds.Where(s => s.StartsWith(name)).ToList());
            var expressions = new SearchResult(new[] { ' ' }, new[] { "LIVERPOOL", "LIVERPOOL LIME STREET" });
            var result = new BL.Service.Service(mock.Object).StartingWith("LIVERPOOL");
            Assert.AreEqual(expressions, result);
        }

        [TestMethod]
        public void StartingWithMissingNameTest()
        {
            var ds = new List<string> { "EUSTON", "LONDON BRIDGE", "VICTORIA" };
            var mock = new Mock<IStationRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAllThatStartWith("KINGS CROSS")).Returns((string name) => ds.Where(s => s.StartsWith(name)).ToList());
            var expressions = new SearchResult(new char[0], new string[0]);
            var result = new BL.Service.Service(mock.Object).StartingWith("KINGS CROSS");
            Assert.AreEqual(expressions, result);
        }
    }
}
