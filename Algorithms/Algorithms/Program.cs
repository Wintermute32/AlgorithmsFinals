using System;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
	class Program
    {
        static void Main(string[] args)
        {

            SetMatrixZeroes solOne = new SetMatrixZeroes();

            int[][] inputMatrix = new int[][] { new int[4] { 0, 1, 2, 0 }, new int[4] { 3, 4, 5, 2 }, new int[4] { 1, 3, 1, 5 } };

            var result = solOne.SetZeroes(inputMatrix);

            foreach (var x in result)
                foreach (var y in x)
                    Console.WriteLine(y);

        }
    }
}
