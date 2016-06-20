using System.Collections.Generic;
using BL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BL.Tests.Repository
{
    [TestClass]
    public class DictionaryStationRepositoryTests
    {
        [TestMethod]
        public void GetAllWithPartialNameTest()
        {
            var ds = new List<string> { "DARTFORD", "DARTMOUTH", "TOWER HILL", "DERBY" };
            var expressions = new List<string> { "DARTFORD", "DARTMOUTH" };
            var result = new DictionaryStationRepository(ds).GetAllThatStartWith("DART");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAllWithFullNameTest()
        {
            var ds = new List<string> { "DARTFORD", "LIVERPOOL", "PADDINGTON" };
            var expressions = new List<string>{ "LIVERPOOL" };
            var result = new DictionaryStationRepository(ds).GetAllThatStartWith("LIVERPOOL");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAllWithPartialNameAndBlankSpaceTest()
        {
            var ds = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET", "PADDINGTON" };
            var expressions = new List<string> { "LIVERPOOL", "LIVERPOOL LIME STREET" };
            var result = new DictionaryStationRepository(ds).GetAllThatStartWith("LIVERPOOL");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }

        [TestMethod]
        public void GetAllWithMissingNameTest()
        {
            var ds = new List<string> { "EUSTON", "LONDON BRIDGE", "VICTORIA" };
            var expressions = new List<string>(0);
            var result = new DictionaryStationRepository(ds).GetAllThatStartWith("KINGS CROSS");
            Assert.IsTrue(expressions.SequenceEqual(result));
        }
    }
}
