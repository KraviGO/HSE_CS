namespace ConsoleApp5;

public class Self6
{
    public static void SolveSelf6()
    {
        Console.Write("Введите количество строк (n): ");
        int.TryParse(Console.ReadLine(), out int n);

        Console.Write("Введите количество столбцов (m): ");
        int.TryParse(Console.ReadLine(), out int m);

        int[,] matrix = FillMatrixWithRandom(n, m);
        Console.WriteLine("Матрица A:");
        PrintMatrix(matrix);

        int[] minValues = GetMinElementsOfRows(matrix);
        Console.WriteLine("Массив B (минимальные элементы каждой строки):");
        PrintArray(minValues);
    }
    
    static int[,] FillMatrixWithRandom(int n, int m)
    {
        Random rand = new Random();
        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = rand.Next(10, 101);
            }
        }

        return matrix;
    }
    
    static void PrintMatrix(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
    
    static int[] GetMinElementsOfRows(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] minElements = new int[n];

        for (int i = 0; i < n; i++)
        {
            int min = matrix[i, 0];
            for (int j = 1; j < m; j++)
            {
                if (matrix[i, j] < min)
                {
                    min = matrix[i, j];
                }
            }
            minElements[i] = min;
        }

        return minElements;
    }
    
    static void PrintArray(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + "\t");
        }
        Console.WriteLine();
    }
}