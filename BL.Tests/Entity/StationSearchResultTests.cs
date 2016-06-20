using BL.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.Tests.Entity
{
    [TestClass]
    public class StationSearchResultTests
    {
        [TestMethod]
        public void EqualsSameObjTest()
        {
            var cur = new SearchResult(new[] { 'A' }, new[] { "ABC" }).Equals(new SearchResult(new[] { 'A' }, new[] { "ABC" }));
            Assert.AreEqual(true, cur);
        }

        [TestMethod]
        public void DiffObjTest()
        {
            var cur = new SearchResult(new[] { 'A' }, new[] { "ABC" }).Equals(new SearchResult(new[] { 'B' }, new[] { "ABC" }));
            Assert.AreEqual(false, cur);
        }

        [TestMethod]
        public void SameObjTest()
        {
            var obj = new SearchResult(new[] { 'A' }, new[] { "ABC" });
            var obj2 = obj;
            var cur = obj.Equals(obj2);
            Assert.AreEqual(true, cur);
        }
    }
}
