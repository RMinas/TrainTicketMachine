using System.Collections.Generic;
using BL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BL.Tests.Repository
{
    [TestClass]
    public class TrieStationRepositoryTests
    {
        [TestMethod]
        public void GetAllWithPartialStationNameTest()
        {
            var ds = new List<string> { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };
            var expressions = new List<string> { "DARTFORD", "DARTMOUTH" };
            var result = new StationRepository(ds).GetAllThatStartWith("DART");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAllWithFullStationNameTest()
        {
            var ds = new List<string> { "DARTFORD", "LIVERPOOL", "PADDINGTON" };
            var expressions = new List<string>{ "LIVERPOOL" };
            var result = new StationRepository(ds).GetAllThatStartWith("LIVERPOOL");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAllWithPartialStationNameAndBlackSpaceTest()
        {
            var ds = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };
            var expressions = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET" };
            var result = new StationRepository(ds).GetAllThatStartWith("LIVERPOOL");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAllWithMissingStationNameTest()
        {
            var ds = new List<string> { "EUSTON", "LONDON BRIDGE", "VICTORIA" };
            var expressions = new List<string>(0);
            var result = new StationRepository(ds).GetAllThatStartWith("KINGS CROSS");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }
    }
}
