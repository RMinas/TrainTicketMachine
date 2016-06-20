using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Collection
{
    public class TrieCol
    {
        static readonly StringBuilder sb = new StringBuilder();

        class TrieNode
        {
            private readonly Dictionary<char, TrieNode> trieNodes;

            public TrieNode()
            {
                trieNodes = new Dictionary<char, TrieNode>();
            }

            public TrieNode(char c) : this()
            {
                Char = c;
            }

            private bool tl { get { return trieNodes.Count == 0; } }

            private char Char { get; set; }

            public TrieNode GetChild(char c)
            {
                TrieNode node;
                trieNodes.TryGetValue(c, out node);
                return node;
            }

            public void AddChild(TrieNode node)
            {
                trieNodes.Add(node.Char, node);
            }

            public IEnumerable<string> GetChildsTerms(string term)
            {
                if (tl)
                    return new List<string> { term };

                var terms = new List<string>();

                foreach (var pair in trieNodes)
                {
                    sb.Clear();
                    sb.Append(term);

                    terms.AddRange(pair.Value.GetChildTermsInternal(sb));
                }

                return terms;
            }

            private IEnumerable<string> GetChildTermsInternal(StringBuilder sb)
            {
                if (new char() != Char)
                    sb.Append(Char);
                
                if (tl)
                    return new[] { sb.ToString() };

                var terms = new List<string>();
                foreach (var trieNode in trieNodes)
                {
                    terms.AddRange(trieNode.Value.GetChildTermsInternal(new StringBuilder(sb.ToString())));

                }

                return terms;
            }
        }

        private readonly TrieNode head;

        public TrieCol()
        {
            head = new TrieNode();
        }

        public TrieCol(IEnumerable<string> terms)
            : this()
        {
            foreach (var term in terms)
            {
                Add(term);
            }
        }

        public IEnumerable<string> Find(string prefix)
        {
            if (prefix == null)
                throw new ArgumentNullException("prefix");

            sb.Clear();

            TrieNode node = head;
            foreach (char prefixChar in prefix)
            {
                var child = node.GetChild(prefixChar);
                node = child;

                if (child == null)
                    return new string[0];

                sb.Append(prefixChar);
            }

            return node.GetChildsTerms(sb.ToString());
        }

        public IEnumerable<string> GetAllSearchTerms()
        {
            return head.GetChildsTerms(string.Empty);
        }

        public void Add(string term)
        {
            if (term == null)
                throw new ArgumentNullException("term");


            TrieNode node = head;

            var prefixChars = new List<char>(term){ new char() };
            foreach (char prefixChar in prefixChars)
            {
                var child = node.GetChild(prefixChar);

                if (child == null)
                {
                    child = new TrieNode(prefixChar);
                    node.AddChild(child);
                }

                node = child;
            }
        }

        public void Add(IEnumerable<string> terms)
        {
            foreach (var term in terms)
            {
                Add(term);
            }
        }
    }
}
