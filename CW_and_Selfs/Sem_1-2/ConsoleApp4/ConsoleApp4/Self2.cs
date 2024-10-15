namespace ConsoleApp4;

public class Self2
{
    public static void SolveSelf2()
    {
        Console.Write("Введите количество строк (M): ");
        int M = int.Parse(Console.ReadLine());
        
        Console.Write("Введите количество столбцов (N): ");
        int N = int.Parse(Console.ReadLine());
        
        int[,] matrix = GenerateRandomMatrix(M, N);
        PrintMatrix(matrix);

        Console.Write("Введите номер строки (k): ");
        int k = int.Parse(Console.ReadLine()) - 1; // минус 1, чтобы было 0-индексирование

        if (k >= 0 && k < M)
        {
            (int sum, int product) = SumAndProductOfRow(matrix, k);
            Console.WriteLine($"Сумма элементов строки {k + 1}: {sum}");
            Console.WriteLine($"Произведение элементов строки {k + 1}: {product}");
        }
        else
        {
            Console.WriteLine("Некорректный номер строки.");
        }
    }

    static int[,] GenerateRandomMatrix(int M, int N)
    {
        Random random = new Random();
        int[,] matrix = new int[M, N];

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = random.Next(1, 10); // случайные числа от 1 до 9
            }
        }

        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int M = matrix.GetLength(0);
        int N = matrix.GetLength(1);

        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static (int sum, int product) SumAndProductOfRow(int[,] matrix, int row)
    {
        int sum = 0;
        int product = 1;
        int N = matrix.GetLength(1);

        for (int j = 0; j < N; j++)
        {
            sum += matrix[row, j];
            product *= matrix[row, j];
        }

        return (sum, product);
    }
}