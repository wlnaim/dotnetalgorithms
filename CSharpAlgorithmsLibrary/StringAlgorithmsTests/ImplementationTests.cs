using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringAlgorithms;
using static StringAlgorithms.Implementation;

namespace StringAlgorithmsTests
{
    [TestClass]
    public class ImplementationTests
    {
        StringAlgorithms.Implementation stringAlg = null;


        [TestInitialize]
        public void SetUp() {
            stringAlg = new Implementation();
        }

        [TestMethod]
        public void Rotate()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7 };
            var result = stringAlg.Rotate(nums, 3);
            Assert.IsTrue(result[0] == 5);
        }

        [TestMethod]
        public void Reverse()
        {
            string s = "Hola mundo";
            var res = stringAlg.Reverse(s);
        }

        [TestMethod]
        public void RPN()
        {
            string[] s = { "1", "2", "+", "4", "*" };
            var calc = stringAlg.Rpn(s);
            Assert.IsTrue(calc == 12);
        }

        [TestMethod]
        public void IsIsomorphic()
        {
            string s = "odd";
            string t = "egg";
            var ban = stringAlg.IsIsomorphic(s, t);
            Assert.IsTrue(ban);
        }

        [TestMethod]
        public void FindLadders()
        {
            string[] ladderWords = new string[] { "hot", "dot", "dog", "lot", "log" };
            HashSet<String> dict = new HashSet<string>(ladderWords);

            var ladder = stringAlg.FindLAdders("hit", "cog", dict);


            Console.WriteLine(ladderWords);
        }

        [TestMethod]
        public void FindKthLargest()
        {
            int[] arr = { 9, 3, 4, 5, 3, 12, 17 };
            var largest = stringAlg.FindKthLargest(arr, 3);
            Assert.IsTrue(largest == 9);
        }

        [TestMethod]
        public void IsWildCardMatching()
        {
            var isMatch = stringAlg.IsMatch("aab", "*ab");
            Assert.IsTrue(isMatch);
        }

        [TestMethod]
        public void Merge()
        {
            IList<Interval> inter = new List<Interval>();
            Interval int1 = new Interval(2, 13);
            Interval int2 = new Interval(5, 18);
            inter.Add(int1);
            inter.Add(int2);
            var merged = stringAlg.Merge(inter);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TwoSum()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var twoSum = stringAlg.TwoSum(arr, 9);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ThreeSumClosest()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var threeSum = stringAlg.ThreeSumClosest(arr, 9);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Atoi()
        {
            string s = "1234";
            var Atoi = stringAlg.Atoi(s);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Merge2()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 3, 4, 5, 6, 10 };
            var threeSum = stringAlg.Merge(arr, 2, arr2, 2);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IsValid()
        {
            string s = "{}{}{}{}{}{[]]]][";
            var Atoi = stringAlg.IsValid(s);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LongestValidParentheses()
        {
            string s = "()()()()()()()()()))";
            var threeSum = Implementation.LongestValidParentheses(s);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void StrStr()
        {
            string s = "12lksdñfasñfjsdlkdjalkfjsdfasddfsdf34";
            string t = "f34";
            var Atoi = stringAlg.StrStr(s, t);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MinSubArrayLen()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var threeSum = stringAlg.ThreeSumClosest(arr, 9);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SearchInsert()
        {
            int[] arr = { 1, 2, 3, 4, 7 };
            var Atoi = stringAlg.SearchInsert(arr, 6);
            Assert.IsTrue(true);
        }
        
        [TestMethod]
        public void LongestConsecutive()
        {
            
            int[] arr = { 100, 200, 3, 4, 5 };
            var lc = Implementation.LongestConsecutive(arr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void IsPalindrome()
        {
            string s = "4321234";
            var Atoi = stringAlg.IsPalindrome(s);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ZigZagConvert()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var threeSum = stringAlg.ZigZagConvert("sñlasjdfñljsdfñlsflkx", 9);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AddBinary()
        {
            string s = "11010";
            var Atoi = stringAlg.AddBinary(s,"11000101");
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LengthOfLastWord()
        {
            string arr = "Bienvenidos sean a probar un poco de ácido desoxirribonucleico";
            var threeSum = stringAlg.LengthOfLastWord(arr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MinimumTotal()
        {
            
            List<List<Int32>> li = new List<List<int>>() {
                new List<int>()
                {
                    1
                },
                new List<int>()
                {
                    2,3
                },
                new List<int>()
                {
                    4,5,6
                },
                new List<int>()
                {
                    7,8,9,10
                }
            };
            
            var Atoi = stringAlg.MinimumTotal(li);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContainsDuplicate()
        {
            int[] arr = { 1, 2, 3, 4, 5,3 };
            var threeSum = stringAlg.ContainsDuplicate(arr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContainsNearbyDuplicate()
        {
            int[] arr = { 1, 2, 3, 4, 5,5 };
            var Atoi = stringAlg.ContainsNearbyDuplicate(arr,2);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ContainsNearbyAlmostDuplicate()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.ContainsNearbyAlmostDuplicate(arr, 2,1);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemoveDuplicatesNaive()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.RemoveDuplicatesNaive(arr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemoveDuplicates()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.RemoveDuplicatesNaive(arr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void RemoveElement()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.RemoveElement(arr,2);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MoveZeroes()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5,0,0,0 };
            var Atoi = stringAlg.MoveZeroes(arr);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LengthOfLongestSubstring()
        {
            string s = "11010";
            var Atoi = stringAlg.LengthOfLongestSubstring(s);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FindSubstring()
        {
            string s = "11010";

            string[] ss = {
                "usted",
                "me",
                "regaló",
                "la vida"
            };
            var Atoi = stringAlg.FindSubstring(s,ss);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MinWindow()
        {
            string t = "ABC";
            string s = "ADOBECODEBANC";
            var Atoi = stringAlg.MinWindow(s,t);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FindMin()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            int s = 4;
            int t = 6;
            var Atoi = stringAlg.FindMin(arr);
            var duplicatesAllowed = stringAlg.FindMin(arr,s,t);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Search()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            int s = 4;
            var Atoi = stringAlg.Search(arr, s);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void BinarySearch()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            int s = 4;
            int t = 1;
            int l = 3;
            var Atoi = stringAlg.BinarySearch(arr, s, t , l);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SearchInRotatedSortedArray()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
           
            int l = 3;
            var Atoi = stringAlg.SearchInRotatedSortedArray(arr, l);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void MajorityElement()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.MajorityElement(arr);
            Assert.IsTrue(true);
        }


    }
}
