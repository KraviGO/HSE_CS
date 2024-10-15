namespace ConsoleApp4;

public class Self3
{
    public static void SolveSelf3()
    {
        Console.Write("Введите количество строк (N): ");
        int N = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество столбцов (M): ");
        int M = int.Parse(Console.ReadLine());

        int[,] matrix = GenerateRandomMatrix(N, M);
        Console.WriteLine("Исходная матрица:");
        PrintMatrix(matrix);

        // Сортировка строк
        for (int i = 0; i < N; i++)
        {
            BubbleSortRow(matrix, i);
        }

        Console.WriteLine("Отсортированная матрица:");
        PrintMatrix(matrix);
    }

    static int[,] GenerateRandomMatrix(int N, int M)
    {
        Random random = new Random();
        int[,] matrix = new int[N, M];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = random.Next(-5, 6); // случайные числа от -5 до 5
            }
        }

        return matrix;
    }

    static void BubbleSortRow(int[,] matrix, int row)
    {
        int N = matrix.GetLength(1);
        for (int i = 0; i < N - 1; i++)
        {
            for (int j = 0; j < N - i - 1; j++)
            {
                if (matrix[row, j] > matrix[row, j + 1])
                {
                    // Меняем местами элементы
                    int temp = matrix[row, j];
                    matrix[row, j] = matrix[row, j + 1];
                    matrix[row, j + 1] = temp;
                }
            }
        }
    }

    static void PrintMatrix(int[,] matrix)
    {
        int N = matrix.GetLength(0);
        int M = matrix.GetLength(1);

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < M; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}