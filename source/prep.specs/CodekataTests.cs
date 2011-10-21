using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prep.codekata;

namespace codekata.tests
{
    [TestClass]
    public class WeatherSpreadTests
    {
        private string filePath = @"C:\Users\squillman\Downloads\weather.dat";

        [TestMethod]
        public void can_read_file()
        {
            WeatherSpread ws = new WeatherSpread(filePath);
            Assert.AreEqual(ws.lines.Count,40);
        }

        [TestMethod]
        public void can_get_headers()
        {
            WeatherSpread ws = new WeatherSpread(filePath);
            Assert.AreEqual(ws.ColumnHeaders.Count,17);
            Assert.AreEqual(ws.ColumnHeaders["MxT"],1);
            Assert.AreEqual(ws.ColumnHeaders["PDir"],9);
        }
    }

    [TestClass]
    public class BloomFilterTests
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
