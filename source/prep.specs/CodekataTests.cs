using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prep.codekata.tuesday;

namespace codekata.tests
{
    [TestClass]
    public class CodeKataTests
    {
        [TestMethod]
        public void default_word_list_should_all_return_true()
        {
            BloomFilter sut = new BloomFilter();
            Assert.IsTrue(sut.IsInDictionary("rhinocerous"));
            Assert.IsTrue(sut.IsInDictionary("elephant"));
            Assert.IsTrue(sut.IsInDictionary("donkey"));
            Assert.IsTrue(sut.IsInDictionary("crocodile"));
            Assert.IsTrue(sut.IsInDictionary("shawn"));
            Assert.IsTrue(sut.IsInDictionary("erin"));
            Assert.IsTrue(sut.IsInDictionary("Erin"));
            Assert.IsTrue(sut.IsInDictionary("Brennan"));
        }

        [TestMethod]
        public void dictionary_should_return_equal_count_as_word_list_after_init()
        {
            BloomFilter sut = new BloomFilter();
            Assert.AreEqual(sut.WordList.Count,8);
        }
    }
}
