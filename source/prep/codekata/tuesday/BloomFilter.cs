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
        private IList<string> dictionary;

        public BloomFilter()
        {
            bitMap = new BitArray(100000);
            dictionary = new List<string> {"rhinocerous", "elephant", "donkey", "crocodile"};
        }

        public int GetBitmapIndexFromHash(string wordToHash, int startIndex)
        {
            MD5 md5 = MD5.Create();
            byte[] wordBytes = Encoding.ASCII.GetBytes(wordToHash);
            byte[] hash = md5.ComputeHash(wordBytes);
            byte[] indexBytes = new byte[5];
            Array.Copy(hash, startIndex, indexBytes, 0, 5);
            int bitMapIndex = BitConverter.ToInt32(indexBytes, 0);
            return bitMapIndex;
        }

        public void InitDictionaryBitMap()
        {
            foreach (var word in dictionary)
            {
                int hashIndex = GetBitmapIndexFromHash(word, 3);
                bitMap[hashIndex] = true;
            }
        }
    }
}
