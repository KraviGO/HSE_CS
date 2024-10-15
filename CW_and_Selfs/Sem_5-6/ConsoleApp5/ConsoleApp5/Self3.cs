namespace ConsoleApp5;

public class Self3
{
    public static void SolveSelf3()
    {
        Console.Write("Введите количество строк (n): ");
        int.TryParse(Console.ReadLine(), out int n);
        
        Console.Write("Введите количество столбцов (m): ");
        int.TryParse(Console.ReadLine(), out int m);

        int[,] matrix = GenerateRandomMatrix(n, m);
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        // Сортировка строк
        for (int i = 0; i < n; i++)
        {
            BubbleSortRow(matrix, i);
        }

        Console.WriteLine("Отсортированная матрица:");
        PrintMatrix(matrix);
    }

    static int[,] GenerateRandomMatrix(int n, int m)
    {
        Random random = new Random();
        int[,] matrix = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = random.Next(-5, 6); // случайные числа от -5 до 5
            }
        }

        return matrix;
    }

    static void BubbleSortRow(int[,] matrix, int row)
    {
        int n = matrix.GetLength(1);
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (matrix[row, j] > matrix[row, j + 1])
                {
                    // Меняем местами элементы
                    (matrix[row, j], matrix[row, j + 1]) = (matrix[row, j + 1], matrix[row, j]);
                }
            }
        }
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
}