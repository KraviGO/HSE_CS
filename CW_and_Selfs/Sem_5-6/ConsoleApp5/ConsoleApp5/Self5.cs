namespace ConsoleApp5;

public class Self5
{
    public static void SolveSelf5()
    {
        Console.Write("Введите размер квадратной матрицы (n): ");
        int.TryParse(Console.ReadLine(), out int n);

        double[,] matrix = FillMatrixWithRandom(n);
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        MirrorLowerTriangle(matrix);
        Console.WriteLine("Матрица после зеркального отображения нижней треугольной части относительно побочной диагонали:");
        PrintMatrix(matrix);
    }
    
    static double[,] FillMatrixWithRandom(int n)
    {
        Random rand = new Random();
        double[,] matrix = new double[n, n];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = Math.Round(-9.25 + rand.NextDouble() * (9.33 + 9.25), 2);
            }
        }

        return matrix;
    }
    
    static void PrintMatrix(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    
    static void MirrorLowerTriangle(double[,] matrix)
    {
        int n = matrix.GetLength(0);

        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                (matrix[i, j], matrix[n - j - 1, n - i - 1]) = (matrix[n - j - 1, n - i - 1], matrix[i, j]);
            }
        }
    }
}