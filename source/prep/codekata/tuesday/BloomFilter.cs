using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace prep.codekata.tuesday
{
    public class BloomFilter
    {
        private BitArray bitMap;

        public IList<string> WordList { get; set; }

        public BloomFilter()
        {
            bitMap = new BitArray(100000);
            WordList = new List<string>();
            InitDictionaryBitMap();
        }

        private int GetBitmapIndexFromHash(string wordToHash, int startIndex)
        {
            MD5 md5 = MD5.Create();
            byte[] wordBytes = Encoding.ASCII.GetBytes(wordToHash);
            byte[] hash = md5.ComputeHash(wordBytes);
            byte[] indexBytes = new byte[5];
            Array.Copy(hash, startIndex, indexBytes, 0, 1);
            int bitMapIndex = BitConverter.ToInt32(indexBytes, 0);
            return Math.Abs(bitMapIndex);
        }

        public void InitDictionaryBitMap()
        {
            if (WordList.Count == 0)
            {
                WordList = new List<string> {"rhinocerous", "elephant", "donkey", "crocodile","shawn","erin","Erin","Brennan"};
            }

            foreach (var word in WordList)
            {
                int hashIndex = GetBitmapIndexFromHash(word, 3);
                bitMap[hashIndex] = true;
            }
        }

        public bool IsInDictionary(string itemToCheck)
        {
            return bitMap[GetBitmapIndexFromHash(itemToCheck, 3)];
        }
    }
}
