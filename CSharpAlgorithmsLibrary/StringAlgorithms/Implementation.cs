using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringAlgorithms
{
    public class Implementation
    {


        public void Rotate(int[] array, int k)
        {
            if (k > array.Length)
            {
                k = k % array.Length;
            }

            int[] resultado = new int[array.Length];

            for (int i = 0; i < k; i++)
            {
                resultado[i] = array[array.Length - k + i];
            }

            int j = 0;

            for (int i = k; i < array.Length; i++)
            {
                resultado[i] = array[j];
                j++;
            }

            Array.Copy(resultado, 0, array, 0, array.Length);
        }

        public void Reverse(string s)
        {
            var output = string.Join(" ", s.Split(' ').Reverse());
        }

        public int Rpn(String[] tokens)
        {
            int returnValue = 0;

            String operators = "+-*/";

            Stack<String> stack = new Stack<string>();

            foreach (String t in tokens)
            {
                if (!operators.Contains(t))
                {
                    stack.Push(t);
                }
                else
                {
                    int a = Convert.ToInt32(stack.Pop());
                    int b = Convert.ToInt32(stack.Pop());
                    int index = operators.IndexOf(t);

                    switch (index)
                    {
                        case 0:
                            stack.Push((a + b).ToString());
                            break;
                        case 1:
                            stack.Push((b - a).ToString());
                            break;
                        case 2:
                            stack.Push((a * b).ToString());
                            break;
                        case 3:
                            stack.Push((b / a).ToString());
                            break;
                    }
                }
            }

            returnValue = Convert.ToInt32(stack.Pop());

            return returnValue;
        }

        public Boolean IsIsomorphic(String s, String t)
        {
            if (s == null || t == null)
            {
                return false;
            }

            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, char> dictionary = new Dictionary<char, char>

                for (int i = 0; i < s.Length; i++)
            {
                char c1 = s[i];
                char c2 = t[i];

                if (dictionary.ContainsKey(c1))
                {
                    if (dictionary[c1] != c2)
                    {
                        return false;
                    }
                }
                else
                {
                    if (dictionary.ContainsValue(c2))
                    {
                        return false;
                    }
                    dictionary.Add(c1, c2);
                }
            }



            return true;
        }

        public List<List<String>> FindLadders(String start, String end, HashSet<String> dict)
        {
            List<List<String>> result = new List<List<String>>();

            LinkedList<WordNode> queue = new LinkedList<WordNode>();
            queue.AddFirst(new WordNode(start, 1, null));

            dict.Add(end);
            int minStep = 0;

            HashSet<String> visited = new HashSet<String>();
            HashSet<String> unvisited = new HashSet<String>();
            unvisited.UnionWith(dict);

            int preNumSteps = 0;
            while (!queue.Any())
            {
                WordNode top = queue.First();
                queue.RemoveFirst();
                string word = top.word;
                int currNumSteps = top.numSteps;

                if (word.Equals(end))
                {
                    if (minStep == 0)
                    {
                        minStep = top.numSteps;
                    }

                    if (top.numSteps == minStep && minStep != 0)
                    {
                        //nothing
                        List<String> t = new List<String>();
                        t.Add(top.word);
                        while (top.pre != null)
                        {
                            t.Insert(0, top.pre.word);
                            top = top.pre;
                        }
                        result.Add(t);
                        continue;
                    }

                }

                if (preNumSteps < currNumSteps)
                {
                    unvisited.ExceptWith(visited);
                }
                preNumSteps = currNumSteps;

                char[] arr = word.ToCharArray();
                for (int i = 0; i < arr.Length; i++)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        char temp = arr[i];
                        if (arr[i] != c)
                        {
                            arr[i] = c;
                        }

                        String newWord = new String(arr);
                        if (unvisited.Contains(newWord))
                        {
                            queue.AddLast(new WordNode(newWord, top.numSteps + 1, top));
                            visited.Add(newWord);
                        }

                        arr[i] = temp;
                    }
                }
            }

            return result;
        }

        public class WordNode
        {
            public String word;
            public int numSteps;
            public WordNode pre;

            public WordNode(String word, int numSteps, WordNode pre)
            {
                this.word = word;
                this.numSteps = numSteps;
                this.pre = pre;
            }

            public WordNode(String word, int numSteps)
            {
                this.word = word;
                this.numSteps = numSteps;
            }

        }

        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int total = nums1.Length + nums2.Length;
            if (total % 2 == 0)
            {
                return (findKth(total / 2 + 1, nums1, nums2, 0, 0) + findKth(total / 2, nums1, nums2, 0, 0)) / 2.0;
            }
            else
            {
                return findKth(total / 2 + 1, nums1, nums2, 0, 0);
            }
        }

        public int FindKth(int k, int[] nums1, int[] nums2, int s1, int s2)
        {
            if (s1 >= nums1.Length)
                return nums2[s2 + k - 1];

            if (s2 >= nums2.Length)
                return nums1[s1 + k - 1];

            if (k == 1)
                return Math.Min(nums1[s1], nums2[s2]);

            int m1 = s1 + k / 2 - 1;
            int m2 = s2 + k / 2 - 1;

            int mid1 = m1 < nums1.Length ? nums1[m1] : Int32.MaxValue;
            int mid2 = m2 < nums2.Length ? nums2[m2] : Int32.MaxValue;

            if (mid1 < mid2)
            {
                return findKth(k - k / 2, nums1, nums2, m1 + 1, s2);
            }
            else
            {
                return findKth(k - k / 2, nums1, nums2, s1, m2 + 1);
            }

        }

        public int FindKthLargest(int[] nums, int k)
        {
            Array.Sort(nums);
            return nums[nums.Length - k];
        }

        public Boolean IsMatch(String s, String p)
        {
            int i = 0;
            int j = 0;
            int starIndex = -1;
            int iIndex = -1;

            while (i < s.Length)
            {
                if (j < p.Length && (p[j] == '?' || p[j] == s[i]))
                {
                    ++i;
                    ++j;
                }
                else if (j < p.Length && p[j] == '*')
                {
                    starIndex = j;
                    iIndex = i;
                    j++;
                }
                else if (starIndex != -1)
                {
                    j = starIndex + 1;
                    i = iIndex + 1;
                    iIndex++;
                }
                else
                {
                    return false;
                }
            }

            while (j < p.Length && p[j] == '*')
            {
                ++j;
            }

            return j == p.Length;
        }

    }
}
