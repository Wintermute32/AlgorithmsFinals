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

            SolutionOne solOne = new SolutionOne();

            int[][] inputMatrix = new int[][] { new int[4] { 0, 1, 2, 0 }, new int[4] { 3, 4, 5, 2 }, new int[4] { 1, 3, 1, 5 } };

            var result = solOne.SetZeroes(inputMatrix);

            foreach (var x in result)
                foreach (var y in x)
                    Console.WriteLine(y);

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
    public class SolutionOne
    {
        public int[][] SetZeroes(int[][] matrix)
        {
            for (int a = 0; a < matrix.Length; a++)
                for (int b = 0; b < matrix[a].Length; b++)
                { 
                    if (matrix[a][b] == 0)
                    {
                        for (int q = 0; q < matrix[a].Length; q++)
                        {
                            if (matrix[a][q] != 0)
                                matrix[a][q] = 0;
                            else
                            {
                                b = q;
                                break;
                            }
                        }
                        for (int z = 0; z < matrix.Length; z++)
                            matrix[z][b] = 0;

                        if (b < matrix[a].Length)
                            b++;
                        else
                            break;

                    }
                }

            for (int a = 0; a < matrix.Length; a++)
                for (int b = 0; b < matrix[a].Length; b++)
                {
                    if (matrix[a][b] == -1)
                        matrix[a][b] = 0;
                }
                    return matrix;
        }
    }

}
