using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
	public class ThreeSumSolution
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> outputList = new List<IList<int>>();

            if (nums.Length <= 1)
            {
                IList<int> work =
                  nums.ToList<int>();
            }
    
            Array.Sort(nums);

            int b = 0;
            int c = 0;

            HashSet<string> hashSet = new HashSet<string>();

            for (int a = 0; a < nums.Length - 2; a++)
            {
                while (a > 0 && nums[a] == nums[a - 1] && a < nums.Length - 2)
                {
                    a++;
                }

                b = a + 1;
                c = nums.Length - 1;
          
                while(b < c)
                {

                    if (nums[a] + nums[b] + nums[c] == 0)
                    {                      
                      var addMeList = new List<int> { nums[a], nums[b], nums[c] };
                      outputList.Add(addMeList);
                      c = nums.Length - 1;
                      b++;
                        while (nums[b] == nums[b - 1] && b < c)
                            b++;
                    }
                    if (nums[a] + nums[b] + nums[c] < 0)
                        b++;

                    if (nums[a] + nums[b] + nums[c] > 0)
                    {        
                        c--;
                    }
                }
            }

            return outputList;
        }

        public static string addToHash(int a, int b, int c)
        {
            var formattedString = string.Format(a.ToString() + b.ToString() + c.ToString());
            Console.WriteLine(formattedString);
            return formattedString;
        }

    }

}
