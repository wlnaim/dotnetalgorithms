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
            Assert.IsTrue(res.Equals("odnum aloH"));
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
            string l = "jäger";
            var ban = stringAlg.IsIsomorphic(s, t);
            var banana = stringAlg.IsIsomorphic(s, l);
            Assert.IsTrue(ban);
            Assert.IsFalse(banana);
        }

        [TestMethod]
        public void FindLadders()
        {
            string[] ladderWords = new string[] { "hot", "dot", "dog", "lot", "log" };
            HashSet<String> dict = new HashSet<string>(ladderWords);

            var ladder = stringAlg.FindLAdders("hit", "cog", dict);
            Assert.IsTrue(true);

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
            Assert.IsTrue(merged[0].start == int1.start && merged[0].end == int2.end);
        }

        [TestMethod]
        public void TwoSum()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var twoSum = stringAlg.TwoSum(arr, 9);
            Assert.IsTrue(arr[twoSum[0]] + arr[twoSum[1]] == 9);
        }

        [TestMethod]
        public void ThreeSumClosest()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var threeSum = stringAlg.ThreeSumClosest(arr, 9);
            Assert.IsTrue(threeSum==9);
        }

        [TestMethod]
        public void Atoi()
        {
            string s = "1234";
            var Atoi = stringAlg.Atoi(s);
            Assert.IsTrue(Convert.ToInt32(s)==Atoi);
        }

        [TestMethod]
        public void Merge2()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            int[] arr2 = { 3, 4, 5, 6, 10 };
            var threeSum = stringAlg.Merge(arr, arr.Length, arr2, arr2.Length);
            Assert.IsTrue(threeSum.Length == arr.Length + arr2.Length && threeSum[0] == arr[0] && threeSum[threeSum.Length-1]== arr2[arr2.Length-1]);
        }

        [TestMethod]
        public void IsValidParenthesis()
        {
            string s = "{}{}{}{}{}{[]]]][";
            string t = "{}[]()";
            var isntValid = stringAlg.IsValidParenthesis(s);
            var isValid = stringAlg.IsValidParenthesis(t);
            Assert.IsTrue(isValid);
            Assert.IsFalse(isntValid);
        }

        [TestMethod]
        public void LongestValidParentheses()
        {
            string s = "()()()()()()()()()))";
            var threeSum = Implementation.LongestValidParentheses(s);
            Assert.IsTrue(threeSum == 18);
        }

        [TestMethod]
        public void StrStr()
        {
            string s = "12lksdñfasñfjsdlkdjalkfjsdfasddfsdf34";
            string t = "f34";
            var Atoi = stringAlg.StrStr(s, t);
            Assert.IsTrue(Atoi==34);
        }

        [TestMethod]
        public void MinSubArrayLen()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var threeSum = stringAlg.MinSubArrayLen(15,arr);
            Assert.IsTrue(threeSum==5);
        }

        [TestMethod]
        public void SearchInsert()
        {
            int[] arr = { 1, 2, 3, 4, 7 };
            var Atoi = stringAlg.SearchInsert(arr, 6);
            Assert.IsTrue(Atoi==4);
        }
        
        [TestMethod]
        public void LongestConsecutive()
        {
            
            int[] arr = { 100, 200, 3, 4, 5 };
            var lc = Implementation.LongestConsecutive(arr);
            Assert.IsTrue(lc==3);
        }

        [TestMethod]
        public void IsPalindrome()
        {
            string s = "4321234";
            var Atoi = stringAlg.IsPalindrome(s);
            Assert.IsTrue(Atoi);
        }

        [TestMethod]
        public void ZigZagConvert()
        {
            int[] arr = { 1, 2, 3, 4, 5 };
            var threeSum = stringAlg.ZigZagConvert("PAYPALISHIRING", 3);
            Assert.IsTrue(threeSum.Equals("PAHNAPLSIIGYIR"));
        }

        [TestMethod]
        public void AddBinary()
        {
            string s = "11010";
            var Atoi = stringAlg.AddBinary(s,"11000101");
            Assert.IsTrue(Atoi.Equals("11111011"));
        }

        [TestMethod]
        public void LengthOfLastWord()
        {
            string arr = "Bienvenidos sean a probar un poco de ácido desoxirribonucleico";
            var threeSum = stringAlg.LengthOfLastWord(arr);
            Assert.IsTrue("desoxirribonucleico".Length==threeSum);
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
            Assert.IsTrue(Atoi==14);
        }

        [TestMethod]
        public void ContainsDuplicate()
        {
            int[] arr = { 1, 2, 3, 4, 5,3 };
            var threeSum = stringAlg.ContainsDuplicate(arr);
            Assert.IsTrue(threeSum);
        }

        [TestMethod]
        public void ContainsNearbyDuplicate()
        {
            int[] arr = { 1, 2, 3, 4, 5,5 };
            var Atoi = stringAlg.ContainsNearbyDuplicate(arr,2);
            Assert.IsTrue(Atoi);
        }

        [TestMethod]
        public void ContainsNearbyAlmostDuplicate()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.ContainsNearbyAlmostDuplicate(arr, 2,1);
            Assert.IsTrue(Atoi);
        }

        [TestMethod]
        public void RemoveDuplicatesNaive()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.RemoveDuplicatesNaive(arr);
            Assert.IsTrue(Atoi==5);
        }

        [TestMethod]
        public void RemoveDuplicates()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.RemoveDuplicatesNaive(arr);
            Assert.IsTrue(Atoi==5);
        }

        [TestMethod]
        public void RemoveElement()
        {
            int[] arr = { 1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.RemoveElement(arr,2);
            Assert.IsTrue(Atoi==5);
        }

        [TestMethod]
        public void MoveZeroes()
        {
            int[] arr = { 1, 0, 0, 0,1, 2, 3, 4, 5, 5 };
            var Atoi = stringAlg.MoveZeroes(arr);
            Assert.IsTrue(Atoi[8]==0);
        }

        [TestMethod]
        public void LengthOfLongestSubstring()
        {
            string s = "11010 a";
            var Atoi = stringAlg.LengthOfLongestSubstring(s);
            Assert.IsTrue(Atoi==4);
        }

        [TestMethod]
        public void FindSubstring()
        {
            string s = "barfoothefoobarman";

            string[] ss = {
                "foo",
                "bar",
                
            };
            var Atoi = stringAlg.FindSubstring(s,ss);
            Assert.IsTrue(Atoi[1]==9);
        }

        [TestMethod]
        public void MinWindow()
        {
            string t = "ABC";
            string s = "ADOBECODEBANC";
            var Atoi = stringAlg.MinWindow(s,t);
            Assert.IsTrue(Atoi.Equals("BANC"));
        }

        [TestMethod]
        public void FindMin()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            int s = 4;
            int t = 6;
            var Atoi = stringAlg.FindMin(arr);
            var duplicatesAllowed = stringAlg.FindMin(arr,s,t);
            Assert.IsTrue(Atoi==1&&duplicatesAllowed==5);
        }



        [TestMethod]
        public void Search()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            int s = 4;
            var Atoi = stringAlg.Search(arr, s);
            Assert.IsTrue(Atoi==-1);
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
            Assert.IsTrue(Atoi);
        }

        [TestMethod]
        public void MajorityElement()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.MajorityElement(arr);
            Assert.IsTrue(Atoi==5);
        }

        [TestMethod]
        public void GetHint()
        {
            string secret = "1807";
            string guess = "7810";

            var Atoi = stringAlg.GetHint(secret,guess);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void LargestRectangleArea()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.LargestRectangleArea(arr);
            Assert.IsTrue(Atoi==25);
        }

        [TestMethod]
        public void LongestCommonPrefix()
        {

            string[] ss = {
                "me",
                "me",
                "meregaló",
                "mela vida"
            };
            var Atoi = stringAlg.LongestCommonPrefix(ss);
            Assert.IsTrue(Atoi.Equals("me"));
        }

        [TestMethod]
        public void GetLargest()
        {
            int[] arr = { 1, 2, 3, 0 };
            var Atoi = Implementation.GetLargest(arr);
            Assert.IsTrue(Atoi == 3210);
        }

        [TestMethod]
        public void CompareVersion()
        {
            string secret = "1.01";
            string guess = "2.00";

            var Atoi = stringAlg.CompareVersion(secret, guess);
            var Atoi2 = stringAlg.CompareVersion(guess, secret);
            var Atoi3 = stringAlg.CompareVersion(secret, secret);
            Assert.IsTrue(Atoi==-1&&Atoi2==-1&&Atoi3==0);
        }

        [TestMethod]
        public void Simplify()
        {
            string path = "/home//foo/";

            var Atoi = stringAlg.Simplify(path);
            Assert.IsTrue(Atoi.Equals("/home/foo"));
        }

        [TestMethod]
        public void SearchRange()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.SearchRange(arr,2);
            Assert.IsTrue(Atoi[0] == 1);
        }


        [TestMethod]
        public void CountAndSay()//pendiente
        {
            var Atoi = stringAlg.CountAndSay(15);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Trap()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.Trap(arr);
            Assert.IsTrue(Atoi==3);
        }

        [TestMethod]
        public void Candy()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.Candy(arr);
            Assert.IsTrue(Atoi==27);
        }

        [TestMethod]
        public void MaxWaterVolume()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.MaxWaterVolume(arr);
            Assert.IsTrue(Atoi==20);
        }

        [TestMethod]
        public void GeneratePascalTriangle()
        {
            var Atoi = stringAlg.GeneratePascalTriangle(15);
            Assert.IsTrue(Atoi.Count == 15);
        }

        [TestMethod]
        public void CanCompleteCircuit()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            int[] arr2 = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.CanCompleteCircuit(arr,arr2);
            Assert.IsTrue(Atoi==0);
        }
        
        [TestMethod]
        public void Calculate()
        {
            string path = "(1-(4-5))";

            var Atoi = stringAlg.Calculate(path);
            Assert.IsTrue(Atoi == 2);
        }

        [TestMethod]
        public void GroupAnagrams() // pendiente
        {

            string[] ss = {
                "Torchwood ",
                "Doctor Who"

            };
            var Atoi = stringAlg.GroupAnagrams(ss);
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void ShortestPalindrome()
        {
            string path = "aabab";

            var Atoi = stringAlg.ShortestPalindrome(path);
            Assert.IsTrue(Atoi.Equals("babaabab"));
        }

        [TestMethod]
        public void ComAddeArea()
        {
            var Atoi = stringAlg.ComAddeArea(1,2,3,4,5,6,7,8);
            Assert.IsTrue(Atoi==8);
        }

        [TestMethod]
        public void SummaryRanges()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.SummaryRanges(arr);
            Assert.IsTrue(Atoi.Count==6);
        }

        [TestMethod]
        public void IncreasingTriplet()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.IncreasingTriplet(arr);
            Assert.IsTrue(Atoi);
        }

        [TestMethod]
        public void IsReachable()
        {
            List<Int32> arr = new List<int>()
            {
                1,
                2,
                3,
                0,
                5,
                6,
                8,
                10,
                12
            };
            var Atoi = Implementation.IsReachable(arr,40);
            Assert.IsTrue(Atoi);
        }

        [TestMethod]
        public void ReverseVowels()
        {
            string path = "Murcielago";

            var Atoi = Implementation.ReverseVowels(path);
            Assert.IsTrue(true);
        }//Auxiliar de swap

        [TestMethod]
        public void Swap()
        {
            string path = "Murcielago";
            char[] charr = path.ToCharArray();

            var Atoi = Implementation.Swap(charr,0,path.Length-1);
            Assert.IsTrue(Atoi[9].Equals('M'));
        }

        [TestMethod]
        public void GeneratePossibleNextMoves()
        {
            string path = "+-";

            var Atoi = stringAlg.GeneratePossibleNextMoves(path);
            Assert.IsTrue(Atoi.Count==0);
        }

        [TestMethod]
        public void MissingMathNumber()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.MissingMathNumber(arr);
            Assert.IsTrue(Atoi==-2);
        }

        [TestMethod]
        public void MissingBitNumber()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.MissingBitNumber(arr);
            Assert.IsTrue(Atoi==12);
        }

        [TestMethod]
        public void MissingBinaryNumber()
        {
            int[] arr = { 1, 2, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.MissingBinaryNumber(arr);
            Assert.IsTrue(Atoi==4);
        }

        [TestMethod]
        public void IsAnagram()
        {
            string arr = "funeral";
            string ar = "real fun";

            var Atoi = stringAlg.IsAnagram(arr,ar);
            Assert.IsTrue(!Atoi);
        }

        [TestMethod]
        public void TopKFrequent()
        {
            int[] arr = { 1, 2, 3, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.TopKFrequent(arr,2);
            Assert.IsTrue(Atoi.Count==2);
        }

        [TestMethod]
        public void FindPeakElement()
        {
            int[] arr = { 1, 2, 3, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.FindPeakElement(arr);
            Assert.IsTrue(Atoi==9);
        }

        [TestMethod]
        public void WordPattern()
        {
            string arr = "funeral";
            string ar = "fun";

            var Atoi = stringAlg.WordPattern(ar, arr);
            Assert.IsTrue(!Atoi);
        }

        [TestMethod]
        public void HIndex()
        {
            int[] arr = { 1, 2, 3, 3, 0, 5, 6, 8, 10, 12 };
            var Atoi = stringAlg.HIndex(arr);
            Assert.IsTrue(Atoi==5);
        }

        [TestMethod]
        public void PalindromePairs()
        {
            string[] arr = {
                "bat",
                "tab",
                "cat"
            };
            var Atoi = stringAlg.PalindromePairs(arr);
            Assert.IsTrue(Atoi.Count==0);
        }

        [TestMethod]
        public void IsOneEditDistance()
        {
            string arr = "funeral";
            string ar = "fun";

            var Atoi = stringAlg.IsOneEditDistance(ar, arr);
            Assert.IsFalse(Atoi);
        }

        [TestMethod]
        public void IsScramble()
        {
            string arr = "funeral";
            string ar = "fun";

            var Atoi = stringAlg.IsScramble(ar, arr);
            Assert.IsFalse(Atoi);
        }

        [TestMethod]
        public void NumberToWords()
        {
            var Atoi = stringAlg.NumberToWords(99);
            var Atoi2 = stringAlg.Int2Str(99);
            Assert.IsTrue(Atoi.Equals("Ninety Nine"));
        }

        [TestMethod]
        public void FullJustify()
        {
            string[] arr = {
                "bat",
                "tab",
                "cat",
                "no",
                "era",
                "raro",
                "verla",
                "en",
                "el",
                "jardín",
                "corriendo tras de mí"
            };
            var Atoi = stringAlg.FullJustify(arr,15);
            Assert.IsTrue(Atoi.Count==4);
        }

        [TestMethod]
        public void RemoveInvalidParentheses()
        {
            string arr = "funeral)";
        

            var Atoi = stringAlg.RemoveInvalidParentheses(arr);
            Assert.IsTrue(Atoi[1].Equals("funeral"));
        }

        [TestMethod]
        public void Intersection()
        {
            int[] arr = { 1, 2, 3, 3, 0, 5, 6, 8, 10, 12 };
            int[] arr2 = { 1, 2, 3, 3, 0, 5, 6, 7, 11, 15, 8, 10, 12 };
            var Atoi = stringAlg.Intersection(arr,arr2);
            Assert.IsTrue(Atoi.Length==9);
        }

        [TestMethod]
        public void MaxSlidingWindow()
        {
            int[] arr2 = { 1, 2, 3, 3, 0, 5, 6, 7, 11, 15, 8, 10, 12 };
            var Atoi = stringAlg.MaxSlidingWindow(arr2,5);
            Assert.IsTrue(Atoi.Length==9);
        }

        [TestMethod]
        public void Next()
        {
            int[] arr2 = { 1, 2, 3, 3, 0, 5, 6, 7, 11, 15, 8, 10, 12 };
            LinkedList<Int32> ll = new LinkedList<Int32>();
            foreach (int a in arr2)
            {
                ll.AddLast(a);
            }
          
            var Atoi = stringAlg.Next(123, 5);
            Assert.IsTrue(Atoi==123);
        }

        [TestMethod]
        public void GuessNumber()// pendiente
        {
            var Atoi = stringAlg.GuessNumber( 5);
            Assert.IsTrue(true);

        }
    }
}
