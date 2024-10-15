namespace ConsoleApp5;

public class Self4
{
    public static void SolveSelf4()
    {
        Console.Write("Введите количество строк (n): ");
        int.TryParse(Console.ReadLine(), out int n);

        Console.Write("Введите количество столбцов (m): ");
        int.TryParse(Console.ReadLine(), out int m);

        int[,] matrix = new int[n, m];
        int[] columnSums;
        
        while (true)
        {
            Console.WriteLine("Выберите способ заполнения матрицы:");
            Console.WriteLine("1. Заполнение случайными числами");
            Console.WriteLine("2. Ввод матрицы с клавиатуры");
            Console.WriteLine("3. Вывести матрицу и суммы столбцов");
            Console.WriteLine("0. Выход");
            int.TryParse(Console.ReadLine(), out int choice);

            switch (choice)
            {
                case 1:
                    matrix = FillMatrixWithRandom(n, m);
                    Console.WriteLine("Матрица заполнена случайными числами.");
                    break;
                case 2:
                    matrix = FillMatrixFromInput(n, m);
                    Console.WriteLine("Матрица заполнена с клавиатуры.");
                    break;
                case 3:
                    PrintMatrix(matrix);
                    columnSums = CalculateColumnSums(matrix);
                    Console.WriteLine("Суммы столбцов:");
                    PrintArray(columnSums);
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Некорректный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
    
    static int[,] FillMatrixWithRandom(int n, int m)
    {
        Random random = new Random();
        int[,] matrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                matrix[i, j] = random.Next(1, 10);
            }
        }
        return matrix;
    }
    
    static int[,] FillMatrixFromInput(int n, int m)
    {
        int[,] matrix = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write($"Введите элемент [{i + 1}, {j + 1}]: ");
                int.TryParse(Console.ReadLine(), out matrix[i, j]);
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
    
    static int[] CalculateColumnSums(int[,] matrix)
    {
        int n = matrix.GetLength(0);
        int m = matrix.GetLength(1);
        int[] columnSums = new int[m];

        for (int j = 0; j < m; j++)
        {
            for (int i = 0; i < n; i++)
            {
                columnSums[j] += matrix[i, j];
            }
        }

        return columnSums;
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