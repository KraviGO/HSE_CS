namespace ConsoleApp5;

public class Self1
{
    public static void SolveSelf1()
    {
        Console.Write("Введите значение n: ");
        int.TryParse(Console.ReadLine(), out int n);
        
        int[,] matrix = FillMatrix(n);
        PrintMatrix(matrix);
    }

    static int[,] FillMatrix(int n)
    {
        int[,] matrix = new int[n, n];
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = (i + j) % n + 1;
            }
        }
        
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
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
}