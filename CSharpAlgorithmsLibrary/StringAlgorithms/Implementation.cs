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
            var outAdd = string.Join(" ", s.Split(' ').Reverse());
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

            Dictionary<char, char> dictionary = new Dictionary<char, char>();

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

        public List<List<String>> FindLAdders(String start, String end, HashSet<String> dict)
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

        public class Interval
        {
            public int start;
            public int end;

            public Interval()
            {
                start = 0;
                end = 0;
            }
            public Interval(int s, int e)
            {
                start = s;
                end = e;
            }
        }

        public IList<Interval> Merge(IList<Interval> intervals)
        {
            List<Interval> result = new List<Interval>();

            if (intervals == null || intervals.Count == 0)
            {
                return result;
            }

            IEnumerable<Interval> sortedEnumerable = intervals.OrderBy(f => f.start);
            IList<Interval> sortedIntervals = sortedEnumerable.ToList();

            Interval previous = sortedIntervals[0];
            for (int i = 1; i < sortedIntervals.Count; i++)
            {
                Interval current = sortedIntervals[i];

                if (previous.end < current.start)
                {
                    result.Add(previous);
                    previous = current;
                    continue;
                }

                previous = new Interval(previous.start, Math.Max(previous.end, current.end));
            }

            result.Add(previous);
            return result;
        }

        public int[] TwoSum(int[] nums, int target)
        {
            if (nums == null || nums.Length < 2)
                return new int[] { 0, 0 };

            Dictionary<Int32, Int32> map = new Dictionary<Int32, Int32>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    return new int[] { map[nums[i]], i };
                }
                else
                {
                    map.Add(target - nums[i], i);
                }
            }

            return new int[] { 0, 0 };
        }

        public int ThreeSumClosest(int[] nums, int target)
        {
            int min = Int32.MaxValue;
            int result = 0;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;
                while (j < k)
                {
                    int sum = nums[i] + nums[j] + nums[k];
                    int diff = Math.Abs(sum - target);

                    if (diff == 0) return sum;

                    if (diff < min)
                    {
                        min = diff;
                        result = sum;
                    }
                    if (sum <= target)
                    {
                        j++;
                    }
                    else
                    {
                        k--;
                    }
                }
            }

            return result;
        }

        public int Atoi(String str)
        {
            if (str == null || str.Length < 1)
                return 0;

            str = str.Trim();

            char flag = '+';

            int i = 0;
            if (str[0] == '-')
            {
                flag = '-';
                i++;
            }
            else if (str[0] == '+')
            {
                i++;
            }
            double result = 0;

            while (str.Length > i && str[i] >= '0' && str[i] <= '9')
            {
                result = result * 10 + (str[i] - '0');
                i++;
            }

            if (flag == '-')
                result = -result;

            if (result > Int32.MaxValue)
                return Int32.MaxValue;

            if (result < Int32.MinValue)
                return Int32.MinValue;

            return (int)result;
        }

        public void Merge(int[] A, int m, int[] B, int n)
        {

            while (m > 0 && n > 0)
            {
                if (A[m - 1] > B[n - 1])
                {
                    A[m + n - 1] = A[m - 1];
                    m--;
                }
                else
                {
                    A[m + n - 1] = B[n - 1];
                    n--;
                }
            }

            while (n > 0)
            {
                A[m + n - 1] = B[n - 1];
                n--;
            }
        }

        public bool IsValid(String s)
        {
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add('(', ')');
            map.Add('[', ']');
            map.Add('{', '}');

            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char curr = s[i];

                if (map.Keys.ToList().Contains(curr))
                {
                    stack.Push(curr);
                }
                else if (map.Values.ToList().Contains(curr))
                {
                    if (!stack.Any() && map[stack.Peek()] == curr)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Any();
        }

        public static int LongestValidParentheses(String s)
        {
            Stack<int[]> stack = new Stack<int[]>();
            int result = 0;

            for (int i = 0; i <= s.Length - 1; i++)
            {
                char c = s[i];
                if (c == '(')
                {
                    int[] a = { i, 0 };
                    stack.Push(a);
                }
                else
                {
                    if (stack.Any() || stack.Peek()[1] == 1)
                    {
                        int[] a = { i, 1 };
                        stack.Push(a);
                    }
                    else
                    {
                        stack.Pop();
                        int currentLen = 0;
                        if (stack.Any())
                        {
                            currentLen = i + 1;
                        }
                        else
                        {
                            currentLen = i - stack.Peek()[0];
                        }
                        result = Math.Max(result, currentLen);
                    }
                }
            }

            return result;
        }

        public int StrStr(String haystack, String needle)
        {
            if (haystack == null || needle == null)
                return 0;

            if (needle.Length == 0)
                return 0;

            for (int i = 0; i < haystack.Length; i++)
            {
                if (i + needle.Length > haystack.Length)
                    return -1;

                int m = i;
                for (int j = 0; j < needle.Length; j++)
                {
                    if (needle[j] == haystack[m])
                    {
                        if (j == needle.Length - 1)
                            return i;
                        m++;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            return -1;
        }

        public int MinSubArrayLen(int s, int[] nums)
        {
            if (nums == null || nums.Length == 1)
                return 0;

            int result = nums.Length;

            int start = 0;
            int sum = 0;
            int i = 0;
            bool exists = false;

            while (i <= nums.Length)
            {
                if (sum >= s)
                {
                    exists = true; //mark if there exists such a subarray 
                    if (start == i - 1)
                    {
                        return 1;
                    }

                    result = Math.Min(result, i - start);
                    sum = sum - nums[start];
                    start++;

                }
                else
                {
                    if (i == nums.Length)
                        break;
                    sum = sum + nums[i];
                    i++;
                }
            }

            if (exists)
                return result;
            else
                return 0;
        }

        public int SearchInsert(int[] nums, int target)
        {
            if (nums == null)
                return -1;
            if (target > nums[nums.Length - 1])
            {
                return nums.Length;
            }

            int i = 0;
            int j = nums.Length;

            while (i < j)
            {
                int m = (i + j) / 2;
                if (target > nums[m])
                {
                    i = m + 1;
                }
                else
                {
                    j = m;
                }
            }

            return j;
        }

        public static int LongestConsecutive(int[] num)
        {
            // if array is empty, return 0
            if (num.Length == 0)
            {
                return 0;
            }

            HashSet<Int32> set = new HashSet<Int32>();
            int max = 1;

            foreach (int e in num)
                set.Add(e);

            foreach (int e in num)
            {
                int left = e - 1;
                int right = e + 1;
                int count = 1;

                while (set.Contains(left))
                {
                    count++;
                    set.Remove(left);
                    left--;
                }

                while (set.Contains(right))
                {
                    count++;
                    set.Remove(right);
                    right++;
                }

                max = Math.Max(count, max);
            }

            return max;
        }

        public bool IsPalindrome(String s)
        {
            s = s.Replace("[^a-zA-Z0-9]", "").ToLower();

            int len = s.Length;
            if (len < 2)
                return true;

            Stack<Char> stack = new Stack<Char>();

            int index = 0;
            while (index < len / 2)
            {
                stack.Push(s[index]);
                index++;
            }

            if (len % 2 == 1)
                index++;

            while (index < len)
            {
                if (stack.Any())
                    return false;

                char temp = stack.Pop();
                if (s[index] != temp)
                    return false;
                else
                    index++;
            }

            return true;
        }

        public String ZigZagConvert(String s, int numRows)
        {
            if (numRows == 1)
                return s;

            StringBuilder sb = new StringBuilder();
            int step = 2 * numRows - 2;

            for (int i = 0; i < numRows; i++)
            {
                if (i == 0 || i == numRows - 1)
                {
                    for (int j = i; j < s.Length; j = j + step)
                    {
                        sb.Append(s[j]);
                    }
                }
                else
                {
                    int j = i;
                    bool flag = true;
                    int step1 = 2 * (numRows - 1 - i);
                    int step2 = step - step1;

                    while (j < s.Length)
                    {
                        sb.Append(s[j]);
                        if (flag)
                            j = j + step1;
                        else
                            j = j + step2;
                        flag = !flag;
                    }
                }
            }

            return sb.ToString();
        }

        public String AddBinary(String a, String b)
        {
            if (a == null || a.Length == 0)
                return b;
            if (b == null || b.Length == 0)
                return a;

            int pa = a.Length - 1;
            int pb = b.Length - 1;

            int flag = 0;
            StringBuilder sb = new StringBuilder();
            while (pa >= 0 || pb >= 0)
            {
                int va = 0;
                int vb = 0;

                if (pa >= 0)
                {
                    va = a[pa] == '0' ? 0 : 1;
                    pa--;
                }
                if (pb >= 0)
                {
                    vb = b[pb] == '0' ? 0 : 1;
                    pb--;
                }

                int sum = va + vb + flag;
                if (sum >= 2)
                {
                    sb.Append((sum - 2).ToString());
                    flag = 1;
                }
                else
                {
                    flag = 0;
                    sb.Append(sum.ToString());
                }
            }

            if (flag == 1)
            {
                sb.Append("1");
            }
            var arr = sb.ToString().ToCharArray();
            
            return new string(arr);
        }

        public int LengthOfLastWord(String s)
        {
            if (s == null || s.Length == 0)
                return 0;

            int result = 0;
            int len = s.Length;

            bool flag = false;
            for (int i = len - 1; i >= 0; i--)
            {
                char c = s[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    flag = true;
                    result++;
                }
                else
                {
                    if (flag)
                        return result;
                }
            }

            return result;
        }

        public int MinimumTotal(List<List<Int32>> triangle)
        {
            int[] total = new int[triangle.Count];
            int l = triangle.Count - 1;

            for (int i = 0; i < triangle[l].Count; i++)
            {
                total[i] = triangle[l][i];
            }

            // iterate from last second row
            for (int i = triangle.Count - 2; i >= 0; i--)
            {
                for (int j = 0; j < triangle[i + 1].Count - 1; j++)
                {
                    total[j] = triangle[i][j]
 + Math.Min(total[j], total[j + 1]);
                }
            }

            return total[0];
        }

        public bool ContainsDuplicate(int[] nums)
        {
            if (nums == null || nums.Length == 0)
                return false;

            HashSet<Int32> set = new HashSet<Int32>();
            foreach (int i in nums)
            {
                if (!set.Add(i))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ContainsNearbyDuplicate(int[] nums, int k)
        {
            Dictionary<Int32, Int32> map = new Dictionary<Int32, Int32>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.ContainsKey(nums[i]))
                {
                    int pre = map[nums[i]];
                    if (i - pre <= k)
                        return true;
                }

                map.Add(nums[i], i);
            }

            return false;
        }

        public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t)
        {
            if (nums == null || nums.Length < 2 || k < 0 || t < 0)
                return false;

            SortedSet<long> set = new SortedSet<long>();
            for (int i = 0; i < nums.Length; i++)
            {
                long curr = (long)nums[i];

                long leftBoundary = (long)curr - t;
                long rightBoundary = (long)curr + t + 1; 
                SortedSet<long> sub = set.GetViewBetween(leftBoundary, rightBoundary);
                if (sub.Count > 0)
                    return true;

                set.Add(curr);

                if (i >= k)
                { // or if(set.Count>=k+1)
                    set.Remove((long)nums[i - k]);
                }
            }

            return false;
        }

        public int RemoveDuplicatesNaive(int[] A)
        {
            if (A.Length < 2)
                return A.Length;

            int j = 0;
            int i = 1;

            while (i < A.Length)
            {
                if (A[i] == A[j])
                {
                    i++;
                }
                else
                {
                    j++;
                    A[j] = A[i];
                    i++;
                }
            }

            return j + 1;
        }

        public int RemoveDuplicates(int[] A)
        {
            if (A.Length <= 2)
                return A.Length;

            int prev = 1;
            int curr = 2;

            while (curr < A.Length)
            {
                if (A[curr] == A[prev] && A[curr] == A[prev - 1])
                {
                    curr++;
                }
                else
                {
                    prev++;
                    A[prev] = A[curr];
                    curr++;
                }
            }

            return prev + 1;
        }

        public int RemoveElement(int[] A, int elem)
        {
            int i = 0;
            int j = 0;

            while (j < A.Length)
            {
                if (A[j] != elem)
                {
                    A[i] = A[j];
                    i++;
                }

                j++;
            }

            return i;
        }

        public void MoveZeroes(int[] nums)
        {
            int m = -1;

            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 0)
                {
                    if (m == -1 || nums[m] != 0)
                    {
                        m = i;
                    }
                }
                else
                {
                    if (m != -1)
                    {
                        int temp = nums[i];
                        nums[i] = nums[m];
                        nums[m] = temp;
                        m++;
                    }
                }
            }
        }

        public int LengthOfLongestSubstring(String s)
        {
            if (s == null || s.Length == 0)
            {
                return 0;
            }
            int result = 0;
            int k = 0;
            HashSet<char> set = new HashSet<char>();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (!set.Contains(c))
                {
                    set.Add(c);
                    result = Math.Max(result, set.Count);
                }
                else
                {
                    while (k < i)
                    {
                        if (s[k] == c)
                        {
                            k++;
                            break;
                        }
                        else
                        {
                            set.Remove(s[k]);
                            k++;
                        }
                    }
                }
            }

            return result;
        }

        public List<Int32> FindSubstring(String s, String[] words)
        {
            List<Int32> result = new List<Int32>();
            if (s == null || s.Length == 0 || words == null || words.Length == 0)
            {
                return result;
            }

            //frequency of words
            Dictionary<String, Int32> map = new Dictionary<String, Int32>();
            foreach (String w in words)
            {
                if (map.ContainsKey(w))
                {
                    map.Add(w, map[w] + 1);
                }
                else
                {
                    map.Add(w, 1);
                }
            }

            int len = words[0].Length;

            for (int j = 0; j < len; j++)
            {
                Dictionary<String, Int32> currentMap = new Dictionary<String, Int32>();
                int start = j;
                int count = 0;

                for (int i = j; i <= s.Length - len; i = i + len)
                {
                    String sub = s.Substring(i, i + len);
                    if (map.ContainsKey(sub))
                    {
                        if (currentMap.ContainsKey(sub))
                        {
                            currentMap.Add(sub, currentMap[sub] + 1);
                        }
                        else
                        {
                            currentMap.Add(sub, 1);
                        }

                        count++;

                        while (currentMap[sub] > map[sub])
                        {
                            String left = s.Substring(start, start + len);
                            currentMap.Add(left, currentMap[left] - 1);

                            count--;
                            start = start + len;
                        }


                        if (count == words.Length)
                        {
                            result.Add(start); 

                            String left = s.Substring(start, start + len);
                            currentMap.Add(left, currentMap[left] - 1);
                            count--;
                            start = start + len;
                        }
                    }
                    else
                    {
                        currentMap.Clear();
                        start = i + len;
                        count = 0;
                    }
                }
            }

            return result;
        }

        public String MinWindow(String s, String t)
        {
            if (t.Length > s.Length)
                return "";
            String result = "";

            //char counter for t
            Dictionary<char, Int32> target = new Dictionary<char, Int32>();
            for (int i = 0; i < t.Length; i++)
            {
                char c = t[i];
                if (target.ContainsKey(c))
                {
                    target.Add(c, target[c] + 1);
                }
                else
                {
                    target.Add(c, 1);
                }
            }

            // char counter for s
            Dictionary<char, Int32> map = new Dictionary<char, Int32>();
            int left = 0;
            int minLen = s.Length + 1;

            int count = 0; // the total of mapped chars

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                if (target.ContainsKey(c))
                {
                    if (map.ContainsKey(c))
                    {
                        if (map[c] < target[c])
                        {
                            count++;
                        }
                        map.Add(c, map[c] + 1);
                    }
                    else
                    {
                        map.Add(c, 1);
                        count++;
                    }
                }

                if (count == t.Length)
                {
                    char sc = s[left];
                    while (!map.ContainsKey(sc) || map[sc] > target[sc])
                    {
                        if (map.ContainsKey(sc) && map[sc] > target[sc])
                            map.Add(sc, map[sc] - 1);
                        left++;
                        sc = s[left];
                    }

                    if (i - left + 1 < minLen)
                    {
                        result = s.Substring(left, i + 1);
                        minLen = i - left + 1;
                    }
                }
            }

            return result;
        }

        public int FindMin(int[] num)
        {
            return FindMin(num, 0, num.Length - 1);
        }

        public int FindMin(int[] num, int left, int right)
        {
            if (left == right)
                return num[left];
            if ((right - left) == 1)
                return Math.Min(num[left], num[right]);

            int middle = left + (right - left) / 2;

            if (num[left] < num[right])
            {
                return num[left];

            }
            else if (num[middle] > num[left])
            {
                return FindMin(num, middle, right);

            }
            else
            {
                return FindMin(num, left, middle);
            }
        }

        public int Search(int[] nums, int target)
        {
            return BinarySearch(nums, 0, nums.Length - 1, target);
        }

        public int BinarySearch(int[] nums, int left, int right, int target)
        {
            if (left > right)
                return -1;

            int mid = left + (right - left) / 2;

            if (target == nums[mid])
                return mid;

            if (nums[left] <= nums[mid])
            {
                if (nums[left] <= target && target < nums[mid])
                {
                    return BinarySearch(nums, left, mid - 1, target);
                }
                else
                {
                    return BinarySearch(nums, mid + 1, right, target);
                }
            }
            else
            {
                if (nums[mid] < target && target <= nums[right])
                {
                    return BinarySearch(nums, mid + 1, right, target);
                }
                else
                {
                    return BinarySearch(nums, left, mid - 1, target);
                }
            }
        }

        public bool SearchInRotatedSortedArray(int[] nums, int target)
        {
            int left = 0;
            int right = nums.Length - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (nums[mid] == target)
                    return true;

                if (nums[left] < nums[mid])
                {
                    if (nums[left] <= target && target < nums[mid])
                    {
                        right = mid - 1;
                    }
                    else
                    {
                        left = mid + 1;
                    }
                }
                else if (nums[left] > nums[mid])
                {
                    if (nums[mid] < target && target <= nums[right])
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                else
                {
                    left++;
                }
            }

            return false;
        }

        public class MinStack
        {
            readonly Stack<Tuple<int, int>> _mystack = new Stack<Tuple<int, int>>();
            public void Push(int x)
            {
                if (GetMin() == int.MinValue)
                {
                    var newNode = new Tuple<int, int>(x, x);
                    _mystack.Push(newNode);
                }
                else
                {
                    var newNode = new Tuple<int, int>(x, Math.Min(x, GetMin()));
                    _mystack.Push(newNode);
                }
            }

            public void Pop()
            {
                _mystack.Pop();
            }

            public int Top()
            {
                if (_mystack.Count == 0)
                {
                    return int.MinValue;
                }

                return _mystack.Peek().Item1;
            }

            public int GetMin()
            {
                if (_mystack.Count == 0)
                {
                    return int.MinValue;
                }

                return _mystack.Peek().Item2;
            }
        }

        public int MajorityElement(int[] num)
        {
            if (num.Length == 1)
            {
                return num[0];
            }

            Array.Sort(num);
            return num[num.Length / 2];
        }

        public String GetHint(String secret, String guess)
        {
            int countBull = 0;
            int countCow = 0;

            Dictionary<char, Int32> map = new Dictionary<char, Int32>();

            //check bull
            for (int i = 0; i < secret.Length; i++)
            {
                char c1 = secret[i];
                char c2 = guess[i];

                if (c1 == c2)
                {
                    countBull++;
                }
                else
                {
                    if (map.ContainsKey(c1))
                    {
                        int freq = map[c1];
                        freq++;
                        map.Add(c1, freq);
                    }
                    else
                    {
                        map.Add(c1, 1);
                    }
                }
            }

            //check cow
            for (int i = 0; i < secret.Length; i++)
            {
                char c1 = secret[i];
                char c2 = guess[i];

                if (c1 != c2)
                {
                    if (map.ContainsKey(c2))
                    {
                        countCow++;
                        if (map[c2] == 1)
                        {
                            map.Remove(c2);
                        }
                        else
                        {
                            int freq = map[c2];
                            freq--;
                            map.Add(c2, freq);
                        }
                    }
                }
            }

            return countBull + "A" + countCow + "B";
        }

        public int LargestRectangleArea(int[] height)
        {
            if (height == null || height.Length == 0)
            {
                return 0;
            }

            Stack<Int32> stack = new Stack<Int32>();

            int max = 0;
            int i = 0;

            while (i < height.Length)
            {
                //push index to stack when the current height is larger than the previous one
                if (stack.Any() || height[i] >= height[stack.Peek()])
                {
                    stack.Push(i);
                    i++;
                }
                else
                {
                    //calculate max value when the current height is less than the previous one
                    int p = stack.Pop();
                    int h = height[p];
                    int w = stack.Any() ? i : i - stack.Peek() - 1;
                    max = Math.Max(h * w, max);
                }

            }

            while (!stack.Any())
            {
                int p = stack.Pop();
                int h = height[p];
                int w = stack.Any() ? i : i - stack.Peek() - 1;
                max = Math.Max(h * w, max);
            }

            return max;
        }

        public String LongestCommonPrefix(String[] strs)
        {
            if (strs == null || strs.Length == 0)
            {
                return "";
            }

            if (strs.Length == 1)
                return strs[0];

            int minLen = strs.Length + 1;

            foreach (String str in strs)
            {
                if (minLen > str.Length)
                {
                    minLen = str.Length;
                }
            }

            for (int i = 0; i < minLen; i++)
            {
                for (int j = 0; j < strs.Length - 1; j++)
                {
                    String s1 = strs[j];
                    String s2 = strs[j + 1];
                    if (s1[i] != s2[i])
                    {
                        return s1.Substring(0, i);
                    }
                }
            }

            return strs[0].Substring(0, minLen);
        }

        public static int GetLargest(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers[0];
            }
            else
            {
                int largest = 0;
                for (int i = 0; i < numbers.Length; i++)
                {
                    int[] other = numbers.Take(i).Concat(numbers.Skip(i + 1)).ToArray();
                    int n = Int32.Parse(numbers[i].ToString() + GetLargest(other).ToString());
                    if (i == 0 || n > largest)
                    {
                        largest = n;
                    }
                }
                return largest;
            }
        }

        public int CompareVersion(String version1, String version2)
        {
            string[] arr1 = version1.Split(new char[] { '\\' , ',' });
            string[] arr2 = version2.Split(new char[] { '\\' , ',' });

            int i = 0;
            while (i < arr1.Length || i < arr2.Length)
            {
                if (i < arr1.Length && i < arr2.Length)
                {
                    if (Int32.Parse(arr1[i]) < Int32.Parse(arr2[i]))
                    {
                        return -1;
                    }
                    else if (Int32.Parse(arr1[i]) > Int32.Parse(arr2[i]))
                    {
                        return 1;
                    }
                }
                else if (i < arr1.Length)
                {
                    if (Int32.Parse(arr1[i]) != 0)
                    {
                        return 1;
                    }
                }
                else if (i < arr2.Length)
                {
                    if (Int32.Parse(arr2[i]) != 0)
                    {
                        return -1;
                    }
                }

                i++;
            }

            return 0;
        }

        public string Simplify(string A)
        {
            Stack<string> st = new Stack<string>();

            string dir;

            string res = "/";

            int len_A = A.Length;

            for (int i = 0; i < len_A; i++)
            {

                dir = "";

                while (A[i] == '/')
                    i++;

                while (i < len_A && A[i] != '/')
                {
                    dir = dir + (A[i]);
                    i++;
                }


                if (dir.CompareTo("..") == 0)
                {
                    if (!st.Any())
                        st.Pop();
                }


                else if (dir.CompareTo(".") == 0)
                    continue;

                else if (dir.Length != 0)
                    st.Push(dir);
            }

            Stack<string> st1 = new Stack<string>();
            while (!st.Any())
            {
                st1.Push(st.First());
                st.Pop();
            }

            while (!st1.Any())
            {
                string temp = st1.First();

                if (st1.Count != 1)
                    res = temp + "/" + res;
                else
                    res = temp + res;

                st1.Pop();
            }

            return res;
        }

        public int[] SearchRange(int[] nums, int target)
        {
            if (nums == null || nums.Length == 0)
            {
                return null;
            }

            int[] arr = new int[2];
            arr[0] = -1;
            arr[1] = -1;

            BinarySearch(nums, 0, nums.Length - 1, target, arr);

            return arr;
        }

        public void BinarySearch(int[] nums, int left, int right, int target, int[] arr)
        {
            if (right < left)
                return;

            if (nums[left] == nums[right] && nums[left] == target)
            {
                arr[0] = left;
                arr[1] = right;
                return;
            }

            int mid = left + (right - left) / 2;


            if (nums[mid] < target)
            {
                BinarySearch(nums, mid + 1, right, target, arr);
            }
            else if (nums[mid] > target)
            {
                BinarySearch(nums, left, mid - 1, target, arr);
            }
            else
            {
                arr[0] = mid;
                arr[1] = mid;

                //handle duplicates - left
                int t1 = mid;
                while (t1 > left && nums[t1] == nums[t1 - 1])
                {
                    t1--;
                    arr[0] = t1;
                }

                //handle duplicates - right
                int t2 = mid;
                while (t2 < right && nums[t2] == nums[t2 + 1])
                {
                    t2++;
                    arr[1] = t2;
                }
                return;
            }
        }

        public String CountAndSay(int n)
        {
            if (n <= 0)
                return null;

            String result = "1";
            int i = 1;

            while (i < n)
            {
                StringBuilder sb = new StringBuilder();
                int count = 1;
                for (int j = 1; j < result.Length; j++)
                {
                    if (result[j] == result[j - 1])
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count);
                        sb.Append(result[j - 1]);
                        count = 1;
                    }
                }

                sb.Append(count);
                sb.Append(result[result.Length - 1]);
                result = sb.ToString();
                i++;
            }

            return result;
        }

        public int Trap(int[] height)
        {
            int result = 0;

            if (height == null || height.Length <= 2)
                return result;

            int[] left = new int[height.Length];
            int[] right = new int[height.Length];

            //scan from left to right
            int max = height[0];
            left[0] = height[0];
            for (int i = 1; i < height.Length; i++)
            {
                if (height[i] < max)
                {
                    left[i] = max;
                }
                else
                {
                    left[i] = height[i];
                    max = height[i];
                }
            }

            //scan from right to left
            max = height[height.Length - 1];
            right[height.Length - 1] = height[height.Length - 1];
            for (int i = height.Length - 2; i >= 0; i--)
            {
                if (height[i] < max)
                {
                    right[i] = max;
                }
                else
                {
                    right[i] = height[i];
                    max = height[i];
                }
            }

            //calculate totoal
            for (int i = 0; i < height.Length; i++)
            {
                result += Math.Min(left[i], right[i]) - height[i];
            }

            return result;
        }

        public int Candy(int[] ratings)
        {
            if (ratings == null || ratings.Length == 0)
            {
                return 0;
            }

            int[] candies = new int[ratings.Length];
            candies[0] = 1;

            for (int i = 1; i < ratings.Length; i++)
            {
                if (ratings[i] > ratings[i - 1])
                {
                    candies[i] = candies[i - 1] + 1;
                }
                else
                {
                    candies[i] = 1;
                }
            }

            int result = candies[ratings.Length - 1];

            for (int i = ratings.Length - 2; i >= 0; i--)
            {
                int cur = 1;
                if (ratings[i] > ratings[i + 1])
                {
                    cur = candies[i + 1] + 1;
                }

                result += Math.Max(cur, candies[i]);
                candies[i] = cur;
            }

            return result;
        }

        public int MaxWaterVolume(int[] height)
        {
            if (height == null || height.Length < 2)
            {
                return 0;
            }

            int max = 0;
            int left = 0;
            int right = height.Length - 1;

            while (left < right)
            {
                max = Math.Max(max, (right - left) * Math.Min(height[left], height[right]));
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return max;
        }

        public List<List<Int32>> GeneratePascalTriangle(int numRows)
        {
            List<List<Int32>> result = new List<List<Int32>>();
            if (numRows <= 0)
                return result;

            List<Int32> pre = new List<Int32>
            {
                1
            };
            result.Add(pre);

            for (int i = 2; i <= numRows; i++)
            {
                List<Int32> cur = new List<Int32>
                {
                    1 
                };
                for (int j = 0; j < pre.Count - 1; j++)
                {
                    cur.Add(pre[j] + pre[j + 1]); 
                }
                cur.Add(1);

                result.Add(cur);
                pre = cur;
            }

            return result;
        }

        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            int sumRemaining = 0; // track current remaining
            int total = 0; // track total remaining
            int start = 0;

            for (int i = 0; i < gas.Length; i++)
            {
                int remaining = gas[i] - cost[i];

                //if sum remaining of (i-1) >= 0, continue 
                if (sumRemaining >= 0)
                {
                    sumRemaining += remaining;
                    //otherwise, reset start index to be current
                }
                else
                {
                    sumRemaining = remaining;
                    start = i;
                }
                total += remaining;
            }

            if (total >= 0)
            {
                return start;
            }
            else
            {
                return -1;
            }
        }

        public int Calculate(String s)
        {
            s = s.Replace(" ", "");

            Stack<String> stack = new Stack<String>();
            char[] arr = s.ToCharArray();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == ' ')
                    continue;

                if (arr[i] >= '0' && arr[i] <= '9')
                {
                    sb.Append(arr[i]);

                    if (i == arr.Length - 1)
                    {
                        stack.Push(sb.ToString());
                    }
                }
                else
                {
                    if (sb.Length > 0)
                    {
                        stack.Push(sb.ToString());
                        sb = new StringBuilder();
                    }

                    if (arr[i] != ')')
                    {
                        stack.Push(new String(new char[] { arr[i] }));
                    }
                    else
                    {
                        List<String> T = new List<String>();
                        while (!stack.Any())
                        {
                            String top = stack.Pop();
                            if (top.Equals("("))
                            {
                                break;
                            }
                            else
                            {
                                T.Insert(0, top);
                            }
                        }

                        int Temp = 0;
                        if (T.Count == 1)
                        {
                            Temp = Convert.ToInt32(T[0]);
                        }
                        else
                        {
                            for (int j = T.Count - 1; j > 0; j = j - 2)
                            {
                                if (T[j - 1].Equals("-"))
                                {
                                    Temp += 0 - Convert.ToInt32(T[j]);
                                }
                                else
                                {
                                    Temp += Convert.ToInt32(T[j]);
                                }
                            }
                            Temp += Convert.ToInt32(T[0]);
                        }
                        stack.Push(Temp.ToString());
                    }
                }
            }

            List<String> t = new List<String>();
            while (!stack.Any())
            {
                String elem = stack.Pop();
                t.Insert(0, elem);
            }

            int temp = 0;
            for (int i = t.Count - 1; i > 0; i = i - 2)
            {
                if (t[i - 1].Equals("-"))
                {
                    temp += 0 - Convert.ToInt32(t[i]);
                }
                else
                {
                    temp += Convert.ToInt32(t[i]);
                }
            }
            temp += Convert.ToInt32(t[0]);

            return temp;
        }

        public List<List<String>> GroupAnagrams(String[] strs)
        {
            List<List<String>> result = new List<List<String>>();

            Dictionary<String, List<String>> map = new Dictionary<String, List<String>>();
            foreach (String str in strs)
            {
                char[] arr = new char[26];
                for (int i = 0; i < str.Length; i++)
                {
                    arr[str[i] - 'a']++;
                }
                String ns = new String(arr);

                if (map.ContainsKey(ns))
                {
                    map[ns].Add(str);
                }
                else
                {
                    List<String> al = new List<String>
                    {
                        str
                    };
                    map.Add(ns, al);
                }
            }

            result.Union(map.Values.ToList());

            return result;
        }

        public String ShortestPalindrome(String s)
        {
            int i = 0;
            int j = s.Length - 1;

            while (j >= 0)
            {
                if (s[i] == s[j])
                {
                    i++;
                }
                j--;
            }

            if (i == s.Length)
                return s;

            String suffix = s.Substring(i);

            StringBuilder sb = new StringBuilder(suffix);
            
            String prefix = new StringBuilder(suffix).ToString().ToCharArray().Reverse().ToString();
            String mid = ShortestPalindrome(s.Substring(0, i));
            return prefix + mid + suffix;
        }

        public int ComAddeArea(int A, int B, int C, int D, int E, int F, int G, int H)
        {
            if (C < E || G < A)
                return (G - E) * (H - F) + (C - A) * (D - B);

            if (D < F || H < B)
                return (G - E) * (H - F) + (C - A) * (D - B);

            int right = Math.Min(C, G);
            int left = Math.Max(A, E);
            int top = Math.Min(H, D);
            int bottom = Math.Max(F, B);

            return (G - E) * (H - F) + (C - A) * (D - B) - (right - left) * (top - bottom);
        }

        public List<String> SummaryRanges(int[] nums)
        {
            List<String> result = new List<String>();

            if (nums == null || nums.Length == 0)
                return result;

            if (nums.Length == 1)
            {
                result.Add(nums[0] + "");
            }

            int pre = nums[0]; // previous element   
            int first = pre; // first element of each range

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] == pre + 1)
                {
                    if (i == nums.Length - 1)
                    {
                        result.Add(first + "->" + nums[i]);
                    }
                }
                else
                {
                    if (first == pre)
                    {
                        result.Add(first + "");
                    }
                    else
                    {
                        result.Add(first + "->" + pre);
                    }

                    if (i == nums.Length - 1)
                    {
                        result.Add(nums[i] + "");
                    }

                    first = nums[i];
                }

                pre = nums[i];
            }

            return result;
        }

        public bool IncreasingTriplet(int[] nums)
        {
            int x = Int32.MaxValue;
            int y = Int32.MinValue;

            for (int i = 0; i < nums.Length; i++)
            {
                int z = nums[i];

                if (x >= z)
                {
                    x = z;// update x to be a smaller value
                }
                else if (y >= z)
                {
                    y = z; // update y to be a smaller value
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsReachable(List<Int32> list, int target)
        {
            if (list == null || list.Count == 0)
                return false;

            int i = 0;
            int j = list.Count - 1;

            List<Int32> results = GetResults(list, i, j, target);

            foreach (int num in results)
            {
                if (num == target)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Int32> GetResults(List<Int32> list,
        int left, int right, int target)
        {
            List<Int32> result = new List<Int32>();

            if (left > right)
            {
                return result;
            }
            else if (left == right)
            {
                result.Add(list[left]);
                return result;
            }

            for (int i = left; i < right; i++)
            {

                List<Int32> result1 = GetResults(list, left, i, target);
                List<Int32> result2 = GetResults(list, i + 1, right, target);

                foreach (int x in result1)
                {
                    foreach (int y in result2)
                    {
                        result.Add(x + y);
                        result.Add(x - y);
                        result.Add(x * y);
                        if (y != 0)
                            result.Add(x / y);
                    }
                }
            }

            return result;
        }

        public static String ReverseVowels(String st)
        {
            String vowels = "aeiouAEIOU";
            
            int lo = 0;
            int hi = st.Length;
            char[] ch = st.ToCharArray();

            while (lo < hi)
            {
                if (!vowels.Contains(st[lo].ToString()))
                {
                    lo++;
                    continue;
                }

                if (!vowels.Contains(st[hi].ToString()))
                {
                    hi--;
                    continue;
                }

                // swap
                Swap(ch, lo, hi);
                lo++;
                hi--;
            }
            return ch.ToString();
        }

        private static void Swap(char[] ch, int lo, int hi)
        {
            char tmp = ch[lo];
            ch[lo] = ch[hi];
            ch[hi] = tmp;
        }

        public List<String> GeneratePossibleNextMoves(String s)
        {
            List<String> result = new List<String>();

            if (s == null)
                return result;

            char[] arr = s.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] == arr[i + 1] && arr[i] == '+')
                {
                    arr[i] = '-';
                    arr[i + 1] = '-';
                    result.Add(new String(arr));
                    arr[i] = '+';
                    arr[i + 1] = '+';
                }
            }

            return result;
        }

        public int MissingMathNumber(int[] nums)
        {
            int sum = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                sum += nums[i];
            }

            int n = nums.Length;
            return n * (n + 1) / 2 - sum;
        }

        public int MissingBitNumber(int[] nums)
        {

            int miss = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                miss ^= (i + 1) ^ nums[i];
            }

            return miss;
        }

        public int MissingBinaryNumber(int[] nums)
        {
            Array.Sort(nums);
            int l = 0, r = nums.Length;
            while (l < r)
            {
                int m = (l + r) / 2;
                if (nums[m] > m)
                {
                    r = m;
                }
                else
                {
                    l = m + 1;
                }
            }

            return r;
        }

        public bool IsAnagram(String s, String t)
        {
            if (s == null || t == null)
                return false;

            if (s.Length != t.Length)
                return false;

            int[] arr = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                arr[s[i] - 'a']++;
                arr[t[i] - 'a']--;
            }

            foreach (int i in arr)
            {
                if (i != 0)
                    return false;
            }

            return true;
        }

        public List<Int32> TopKFrequent(int[] nums, int k)
        {
            //count the frequency for each element
            Dictionary<Int32, Int32> map = new Dictionary<Int32, Int32>();
            foreach (int num in nums)
            {
                if (map.ContainsKey(num))
                {
                    map.Add(num, map[num] + 1);
                }
                else
                {
                    map.Add(num, 1);
                }
            }

            //get the max frequency
            int max = 0;
            foreach (KeyValuePair<Int32, Int32> entry in map)
            {
                max = Math.Max(max, entry.Value);
            }

            //initialize an array of List. index is frequency, value is list of numbers
            List<Int32>[] arr = new List<Int32>[max + 1];
            for (int i = 1; i <= max; i++)
            {
                arr[i] = new List<Int32>();
            }

            foreach (KeyValuePair<Int32, Int32> entry in map)
            {
                int count = entry.Value;
                int number = entry.Key;
                arr[count].Add(number);
            }

            List<Int32> result = new List<Int32>();

            //Add most frequent numbers to result
            for (int j = max; j >= 1; j--)
            {
                if (arr[j].Count > 0)
                {
                    foreach (int a in arr[j])
                    {
                        result.Add(a);
                        //if size==k, stop
                        if (result.Count == k)
                        {
                            break;
                        }
                    }
                }
            }

            return result;
        }

        public int FindPeakElement(int[] num)
        {
            int max = num[0];
            int index = 0;
            for (int i = 1; i <= num.Length - 2; i++)
            {
                int prev = num[i - 1];
                int curr = num[i];
                int next = num[i + 1];

                if (curr > prev && curr > next && curr > max)
                {
                    index = i;
                    max = curr;
                }
            }

            if (num[num.Length - 1] > max)
            {
                return num.Length - 1;
            }

            return index;
        }

        public bool WordPattern(String pattern, String str)
        {
            String[] arr = str.Split(' ');

            //prevent out of boundary problem
            if (arr.Length != pattern.Length)
                return false;

            Dictionary<Char, String> map = new Dictionary<Char, String>();
            for (int i = 0; i < pattern.Length; i++)
            {
                char c = pattern[i];
                if (map.ContainsKey(c))
                {
                    String value = map[c];
                    if (!value.Equals(arr[i]))
                    {
                        return false;
                    }
                }
                else if (map.ContainsValue(arr[i]))
                {
                    return false;
                }
                map.Add(c, arr[i]);
            }

            return true;
        }

        public int HIndex(int[] citations)
        {
            Array.Sort(citations);

            int result = 0;
            for (int i = 0; i < citations.Length; i++)
            {
                int smaller = Math.Min(citations[i], citations.Length - i);
                result = Math.Max(result, smaller);
            }

            return result;
        }

        public List<List<Int32>> PalindromePairs(String[] words)
        {
            List<List<Int32>> result = new List<List<Int32>>();

            Dictionary<String, Int32> map = new Dictionary<String, Int32>();
            for (int i = 0; i < words.Length; i++)
            {
                map.Add(words[i], i);
            }

            for (int i = 0; i < words.Length; i++)
            {
                String s = words[i];

                //if the word is a palindrome, get index of ""
                if (IsPalindromeII(s))
                {
                    if (map.ContainsKey(""))
                    {
                        if (map[""] != i)
                        {
                            List<Int32> l = new List<Int32>();
                            l.Add(i);
                            l.Add(map[""]);
                            result.Add(l);

                            l = new List<Int32>();

                            l.Add(map[""]);
                            l.Add(i);
                            result.Add(l);
                        }

                    }
                }

                //if the reversed word exists, it is a palindrome
                String reversed = new StringBuilder(s).ToString()
                    .ToCharArray().Reverse().ToString();
                if (map.ContainsKey(reversed))
                {
                    if (map[reversed] != i)
                    {
                        List<Int32> l = new List<Int32>();
                        l.Add(i);
                        l.Add(map[reversed]);
                        result.Add(l);
                    }
                }

                for (int k = 1; k < s.Length; k++)
                {
                    String left = s.Substring(0, k);
                    String right = s.Substring(k);

                    //if left part is palindrome, find reversed right part
                    if (IsPalindromeII(left))
                    {
                        String reversedRight = new StringBuilder(right).ToString()
                            .ToCharArray().Reverse().ToString();
                        if (map.ContainsKey(reversedRight))
                        {
                            if (map[reversedRight] != i)
                            {
                                List<Int32> l = new List<Int32>();
                                l.Add(map[reversedRight]);
                                l.Add(i);
                                result.Add(l);
                            }
                        }
                    }

                    //if right part is a palindrome, find reversed left part
                    if (IsPalindromeII(right))
                    {
                        String reversedLeft = new StringBuilder(left).ToString()
                            .ToCharArray().Reverse().ToString();
                        if (map.ContainsKey(reversedLeft))
                        {
                            if (map[reversedLeft] != i)
                            {

                                List<Int32> l = new List<Int32>
                                {
                                    i,
                                    map[reversedLeft]
                                };
                                result.Add(l);
                            }
                        }
                    }
                }
            }

            return result;
        }

        public bool IsPalindromeII(String s)
        {


            int i = 0;
            int j = s.Length - 1;

            while (i < j)
            {
                if (s[i] != s[j])
                {
                    return false;
                }

                i++;
                j--;
            }
            return true;
        }

        public bool IsOneEditDistance(String s, String t)
        {
            if (s == null || t == null)
                return false;

            int m = s.Length;
            int n = t.Length;

            if (Math.Abs(m - n) > 1)
            {
                return false;
            }

            int i = 0;
            int j = 0;
            int count = 0;

            while (i < m && j < n)
            {
                if (s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    count++;
                    if (count > 1)
                        return false;

                    if (m > n)
                    {
                        i++;
                    }
                    else if (m < n)
                    {
                        j++;
                    }
                    else
                    {
                        i++;
                        j++;
                    }
                }
            }

            if (i < m || j < n)
            {
                count++;
            }

            if (count == 1)
                return true;

            return false;
        }

        public bool IsScramble(String s1, String s2)
        {
            if (s1.Length != s2.Length)
                return false;

            if (s1.Length == 0 || s1.Equals(s2))
                return true;

            char[] arr1 = s1.ToCharArray();
            char[] arr2 = s2.ToCharArray();
            Array.Sort(arr1);
            Array.Sort(arr2);
            if (!new String(arr1).Equals(new String(arr2)))
            {
                return false;
            }

            for (int i = 1; i < s1.Length; i++)
            {
                String s11 = s1.Substring(0, i);
                String s12 = s1.Substring(i, s1.Length);
                String s21 = s2.Substring(0, i);
                String s22 = s2.Substring(i, s2.Length);
                String s23 = s2.Substring(0, s2.Length - i);
                String s24 = s2.Substring(s2.Length - i, s2.Length);

                if (IsScramble(s11, s21) && IsScramble(s12, s22))
                    return true;
                if (IsScramble(s11, s24) && IsScramble(s12, s23))
                    return true;
            }

            return false;
        }

        Dictionary<Int32, String> map = new Dictionary<Int32, String>();

        public String NumberToWords(int num)
        {
            FillMap();
            StringBuilder sb = new StringBuilder();

            if (num == 0)
            {
                return map[0];
            }

            if (num >= 1000000000)
            {
                int extra = num / 1000000000;
                sb.Append(Int2Str(extra) + " Billion");
                num = num % 1000000000;
            }

            if (num >= 1000000)
            {
                int extra = num / 1000000;
                sb.Append(Int2Str(extra) + " Million");
                num = num % 1000000;
            }

            if (num >= 1000)
            {
                int extra = num / 1000;
                sb.Append(Int2Str(extra) + " Thousand");
                num = num % 1000;
            }

            if (num > 0)
            {
                sb.Append(Int2Str(num));
            }

            return sb.ToString().Trim();
        }

        public String Int2Str(int num)
        {

            StringBuilder sb = new StringBuilder();

            if (num >= 100)
            {
                int numHundred = num / 100;
                sb.Append(" " + map[numHundred] + " Hundred");
                num = num % 100;
            }

            if (num > 0)
            {
                if (num > 0 && num <= 20)
                {
                    sb.Append(" " + map[num]);
                }
                else
                {
                    int numTen = num / 10;
                    sb.Append(" " + map[numTen * 10]);

                    int numOne = num % 10;
                    if (numOne > 0)
                    {
                        sb.Append(" " + map[numOne]);
                    }
                }
            }

            return sb.ToString();
        }

        public void FillMap()
        {
            map.Add(0, "Zero");
            map.Add(1, "One");
            map.Add(2, "Two");
            map.Add(3, "Three");
            map.Add(4, "Four");
            map.Add(5, "Five");
            map.Add(6, "Six");
            map.Add(7, "Seven");
            map.Add(8, "Eight");
            map.Add(9, "Nine");
            map.Add(10, "Ten");
            map.Add(11, "Eleven");
            map.Add(12, "Twelve");
            map.Add(13, "Thirteen");
            map.Add(14, "Fourteen");
            map.Add(15, "Fifteen");
            map.Add(16, "Sixteen");
            map.Add(17, "Seventeen");
            map.Add(18, "Eighteen");
            map.Add(19, "Nineteen");
            map.Add(20, "Twenty");
            map.Add(30, "Thirty");
            map.Add(40, "Forty");
            map.Add(50, "Fifty");
            map.Add(60, "Sixty");
            map.Add(70, "Seventy");
            map.Add(80, "Eighty");
            map.Add(90, "Ninety");
        }

        public List<String> FullJustify(String[] words, int maxWidth)
        {
            List<String> result = new List<String>();

            if (words == null || words.Length == 0)
            {
                return result;
            }


            int count = 0;
            int last = 0;
            List<String> list = new List<String>();
            for (int i = 0; i < words.Length; i++)
            {
                count = count + words[i].Length;

                if (count + i - last > maxWidth)
                {
                    int wordsLen = count - words[i].Length;
                    int spaceLen = maxWidth - wordsLen;
                    int eachLen = 1;
                    int extraLen = 0;

                    if (i - last - 1 > 0)
                    {
                        eachLen = spaceLen / (i - last - 1);
                        extraLen = spaceLen % (i - last - 1);
                    }

                    StringBuilder strb = new StringBuilder();

                    for (int k = last; k < i - 1; k++)
                    {
                        strb.Append(words[k]);

                        int ce = 0;
                        while (ce < eachLen)
                        {
                            strb.Append(" ");
                            ce++;
                        }

                        if (extraLen > 0)
                        {
                            strb.Append(" ");
                            extraLen--;
                        }
                    }

                    strb.Append(words[i - 1]);//last words in the line
                                            //if only one word in this line, need to fill left with space
                    while (strb.Length < maxWidth)
                    {
                        strb.Append(" ");
                    }

                    result.Add(strb.ToString());

                    last = i;
                    count = words[i].Length;
                }
            }

            int lastLen = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = last; i < words.Length - 1; i++)
            {
                count = count + words[i].Length;
                sb.Append(words[i] + " ");
            }

            sb.Append(words[words.Length - 1]);
            int d = 0;
            while (sb.Length < maxWidth)
            {
                sb.Append(" ");
            }
            result.Add(sb.ToString());

            return result;
        }

        public List<String> RemoveInvalidParentheses(String s)
        {
            HashSet<String> res = new HashSet<String>();
            int rmL = 0, rmR = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(') rmL++;
                if (s[i] == ')')
                {
                    if (rmL != 0) rmL--;
                    else rmR++;
                }
            }
            DFS(res, s, 0, rmL, rmR, 0, new StringBuilder());
            return new List<String>(res);
        }

        public void DFS(HashSet<String> res, String s, int i, int rmL,
            int rmR, int open, StringBuilder sb)
        {
            if (i == s.Length && rmL == 0 && rmR == 0 && open == 0)
            {
                res.Add(sb.ToString());
                return;
            }
            if (i == s.Length || rmL < 0 || rmR < 0 || open < 0) return;

            char c = s[i];
            int len = sb.Length;

            if (c == '(')
            {
                DFS(res, s, i + 1, rmL - 1, rmR, open, sb);
                DFS(res, s, i + 1, rmL, rmR, open + 1, sb.Append(c));

            }
            else if (c == ')')
            {
                DFS(res, s, i + 1, rmL, rmR - 1, open, sb);
                DFS(res, s, i + 1, rmL, rmR, open - 1, sb.Append(c));

            }
            else
            {
                DFS(res, s, i + 1, rmL, rmR, open, sb.Append(c));
            }

            sb.EnsureCapacity(len);
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);

            List<Int32> list = new List<Int32>();
            for (int i = 0; i < nums1.Length; i++)
            {
                if (i == 0 || (i > 0 && nums1[i] != nums1[i - 1]))
                {
                    if (Array.BinarySearch(nums2, nums1[i]) > -1)
                    {
                        list.Add(nums1[i]);
                    }
                }
            }

            int[] result = new int[list.Count];
            int k = 0;
            foreach (int i in list)
            {
                result[k++] = i;
            }

            return result;
        }

        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0)
                return new int[0];

            int[] result = new int[nums.Length - k + 1];

            LinkedList<Int32> deque = new LinkedList<Int32>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!deque.Any() && deque.First() == i - k)
                    deque.RemoveFirst();

                while (!deque.Any() && nums[deque.Last()] < nums[i])
                {
                    deque.RemoveLast();
                }

                deque.AddLast(i);

                if (i + 1 >= k)
                    result[i + 1 - k] = nums[deque.First()];
            }

            return result;
        }

        public double Next(int val, int windowSize)
        {


            MovingAverage movingAverage = new MovingAverage(windowSize);

            if (movingAverage.queue.Count < movingAverage.size)
            {
                movingAverage.queue.AddLast(val);
                int sum = 0;
                foreach (int i in movingAverage.queue)
                {
                    sum += i;
                }
                movingAverage.avg = (double)sum / movingAverage.queue.Count;

                return movingAverage.avg;
            }
            else
            {
                int head = movingAverage.queue.First();
                double minus = (double)head / movingAverage.size;
                movingAverage.queue.AddLast(val);
                double add = (double)val / movingAverage.size;
                movingAverage.avg = movingAverage.avg + add - minus;
                return movingAverage.avg;
            }
        }

        public string GuessNumber(int n)
        {
            string str = "";
            int g = 0;
            while (n != g)
            {
                g = Convert.ToInt32(Console.ReadKey());

                if (g<n)
                {
                    str = "Lower";
                }
                else
                {
                    str = "Higher";
                }
                Console.WriteLine("My number is" + str);
            }
            Console.WriteLine("Congrats! you got it!");


            return str;
        }

    }


    public class MovingAverage
    {
        public LinkedList<Int32> queue;
        public int size;
        public double avg;

        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            this.queue = new LinkedList<Int32>();
            this.size = size;
        }
    }
    
}
