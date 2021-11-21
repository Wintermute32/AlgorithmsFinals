namespace Algorithms
{
	public class SetMatrixZeroes
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
