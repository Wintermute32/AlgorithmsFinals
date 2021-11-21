using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
	class Program
	{
        static void Main(string[] args)
        {
            int[] halfOne = new int[9] { 1212, 6, 17, 20, 21, 56,292,10, 1111};
            int[] result = MergeSort(halfOne);
            
            foreach (var x in result)
                Console.WriteLine(x);

            Console.WriteLine(Solution.SingleNumber(new int[5] { 3, 4, 4, 1, 1 }));

            Console.WriteLine(6^2);
        }

        public static int[] MergeSort(int[] inputArr)
        {
            if (inputArr.Length <= 1)
                return inputArr;

            int[] halfOne = new int[inputArr.Length / 2];
            int[] halfTwo;
            int midPoint;
            int k = 0;

            if (inputArr.Length % 2 != 0)
                midPoint = (inputArr.Length / 2) + 1;
            else
                midPoint = inputArr.Length / 2;

            halfTwo = new int[midPoint];

            for (int i = 0; i < inputArr.Length/2; i++)
                halfOne[i] = inputArr[i];

            for (int i = inputArr.Length / 2; i < inputArr.Length; i++)
            {
                halfTwo[k] = inputArr[i];
                k++;
            }

            int[] sortedOne = MergeSort(halfOne);
            int[] sortedTwo = MergeSort(halfTwo);

            return Merge(sortedOne, sortedTwo);   
    
        }

        public static int[] Sort(int[] inputArr)
        {
            int dex = 0;

            while(dex < inputArr.Length)
            {
                for (int i = dex; i <inputArr.Length; i++)
                {
                    if (inputArr[dex] > inputArr[i])
                    {
                        int pushBack = inputArr[dex];
                        int pullForward = inputArr[i];

                        inputArr[dex] = pullForward;
                        inputArr[i] = pushBack;
                    }
                }
                dex++;
            }
            return inputArr;            
        }

        public static int[] Merge(int[] arrayOne, int[] arrayTwo) // assumes sorted arrays
        {
            int[] outputArr = new int[arrayOne.Length + arrayTwo.Length];
            int dexA = 0;
            int dexB = 0;
            bool isOneDone = false;
            bool isTwoDone = false;
            //we use switches to stop pulling numbers from emptied halves
            for (int i = 0; i < outputArr.Length; i++)
            {
                if (arrayOne[dexA] <= arrayTwo[dexB] && !isOneDone || isTwoDone)
                {
                    outputArr[i] = arrayOne[dexA];

                    if (dexA >= arrayOne.Length - 1)
                        isOneDone = true;

                    if (dexA < arrayOne.Length - 1)
                        dexA++;
                }
                else if (!isTwoDone)
                {
                    outputArr[i] = arrayTwo[dexB];

                    if (dexB >= arrayTwo.Length - 1)
                        isTwoDone = true;

                    if (dexB < arrayTwo.Length - 1)
                        dexB++;
                }
            }
            return outputArr;
        }


    }

    public class Solution
    {
        public static int SingleNumber(int[] nums)
        {
            var singleNumber = 0;
            foreach (var num in nums)
            {
                singleNumber ^= num;
            }
            return singleNumber;
        }
    }

    public class ThreeSumSolution
    {
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            int n = 0;
            int q = 0;

            IList<IList<int>> outputList = new List<IList<int>>();

            while (n < nums.Length - 2)
            {
                q = n + 1;

                for (int i = q; i < nums.Length - 1; i++)
                {
                    for (int j = q + 1; j < nums.Length; j++)
                    {
                        if (nums[n] + nums[i] + nums[j] == 0)
                        {
                            List<int> addMeList = new List<int>() { nums[n], nums[i], nums[j] };
                            addMeList.Sort();

                            if (!outputList.Contains(addMeList))
                                outputList.Add(addMeList);

                            outputList[i].Remove(i);
                        }
                    }
                }
                n++;
            }

            return outputList;
        }
    }
}
