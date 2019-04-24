using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAlgorithms
{
    public class MinimumDistanceOfAdjacentPair
    {
        public int solution(int[] array)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            if (array.Length == 1)
            {
                return -2;
            }
            Array.Sort(array);

            long minimumDistance = long.MaxValue;

            for(int i = 1; i < array.Length; i++)
            {
                long distance = (long)array[i] - array[i - 1];
                if(distance < minimumDistance)
                {
                    minimumDistance = distance;
                }
            }

            return minimumDistance > 100000000 ? -1 : (int)minimumDistance;
        }
    }
}
