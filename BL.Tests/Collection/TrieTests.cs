using System.Linq;
using BL.Collection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BL.Tests.Collection
{
    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void SingleCharTest()
        {
            var searchTerms = new[] { "D" };
            var trie = new TrieCol();
            var output = searchTerms;

            trie.Add(searchTerms);
            var result = trie.GetAllSearchTerms();

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void SingleTermTest()
        {
            var searchTerms = new[] { "DA" };
            var trie = new TrieCol();
            var output = searchTerms;

            trie.Add(searchTerms);
            var result = trie.GetAllSearchTerms();

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void MultipleTermsByPrefixTest()
        {
            var searchTerms = new[] { "DAR", "TOW" };
            var trie = new TrieCol();
            var output = searchTerms;

            trie.Add(searchTerms);
            var result = trie.GetAllSearchTerms();

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());

        }

        [TestMethod]
        public void GetTermsWithSingleCharTest()
        {
            var searchTerms = new[] { "D" };
            var trie = new TrieCol(searchTerms);

            var output = searchTerms;

            var result = trie.Find("D");

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void GetTermsWithMultipleBranchesTest()
        {
            var searchTerms = new[] { "LIVERPOOL", "LIVERPOOL LIME STREET" };
            var trie = new TrieCol(searchTerms);

            var output = searchTerms;

            var result = trie.Find("L");

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void GetFullTermTest()
        {
            var searchTerms = new[] { "EU" };
            var trie = new TrieCol(searchTerms);

            var output = searchTerms;

            var result = trie.Find("EU");

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void GetFullTermsWithBranchTest()
        {
            var searchTerms = new[] { "DARTFORD", "DARTMOUTH" };
            var trie = new TrieCol(searchTerms);

            var output = searchTerms;

            var result = trie.Find("DAR");

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void GetPartialTermTest()
        {
            var searchTerms = new[] { "DAR" };
            var trie = new TrieCol(searchTerms);

            var output = searchTerms;

            var result = trie.Find("DA");

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }

        [TestMethod]
        public void GetPartialTermWithMultipleBranchesTest()
        {
            var searchTerms = new[] { "DARTFORD", "DARTMOUTH" };
            var trie = new TrieCol(searchTerms);

            var output = searchTerms;

            var result = trie.Find("DAR");

            Assert.IsNotNull(result);
            Assert.AreEqual(output.Count(), output.Where(result.Contains).Count());
        }
    }
}
