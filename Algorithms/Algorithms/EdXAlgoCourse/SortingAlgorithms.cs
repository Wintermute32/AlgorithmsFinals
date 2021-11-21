namespace Algorithms
{
	public class SortingAlgorithms
	{
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

            for (int i = 0; i < inputArr.Length / 2; i++)
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

            while (dex < inputArr.Length)
            {
                for (int i = dex; i < inputArr.Length; i++)
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
        
}
