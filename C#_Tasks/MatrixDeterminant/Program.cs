using System;

namespace MatrixDeterminant
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,]
            {
                {1, 2, 3},
                {4, 3, 6},
                {7, 8, 9}
            };

            int determinant = CalculateDeterminant(matrix);
            Console.WriteLine("Determinant: " + determinant);
        }

        static int CalculateDeterminant(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            if (rows != cols)
            {
                throw new ArgumentException("Матрицата не е квадратна");
            }

            if (rows == 1 && cols == 1)
            {
                return matrix[0, 0];
            }

            int determinant = 0;

            for (int i = 0; i < rows; i++)
            {
                int sign = (i % 2 == 0) ? 1 : -1;

                int[,] subMatrix = GetSubMatrix(matrix, i);

                determinant += sign * matrix[0, i] * CalculateDeterminant(subMatrix);
            }

            return determinant;
        }

        static int[,] GetSubMatrix(int[,] matrix, int colToRemove)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            int[,] subMatrix = new int[rows - 1, cols - 1];

            int rowIndex = 0;

            for (int i = 0; i < cols; i++)
            {
                if (i == colToRemove)
                {
                    continue;
                }

                for (int j = 1; j < rows; j++)
                {
                    subMatrix[j - 1, rowIndex] = matrix[j, i];
                }

                rowIndex++;
            }

            return subMatrix;
        }
    }
}
