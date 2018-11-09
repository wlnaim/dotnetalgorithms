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
    }
}
