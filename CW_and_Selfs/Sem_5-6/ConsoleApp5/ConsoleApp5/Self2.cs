namespace ConsoleApp5;

public class Self2
{
    public static void SolveSelf2()
    {
        Console.Write("Введите количество строк (m): ");
        int.TryParse(Console.ReadLine(), out int m);
        
        Console.Write("Введите количество столбцов (n): ");
        int.TryParse(Console.ReadLine(), out int n);
        
        int[,] matrix = GenerateRandomMatrix(m, n);
        PrintMatrix(matrix);

        Console.Write("Введите номер строки (k): ");
        int.TryParse(Console.ReadLine(), out int k);
        k--;

        if (k >= 0 && k < m)
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

    static int[,] GenerateRandomMatrix(int m, int n)
    {
        Random random = new Random();
        int[,] matrix = new int[m, n];

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = random.Next(1, 10); // случайные числа от 1 до 9
            }
        }

        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int m = matrix.GetLength(0);
        int n = matrix.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
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
        int n = matrix.GetLength(1);

        for (int j = 0; j < n; j++)
        {
            sum += matrix[row, j];
            product *= matrix[row, j];
        }

        return (sum, product);
    }
}