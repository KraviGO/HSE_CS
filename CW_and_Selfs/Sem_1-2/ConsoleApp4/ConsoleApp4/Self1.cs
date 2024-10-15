namespace ConsoleApp4;

public class Self1
{
    public static void SolveSelf1()
    {
        Console.Write("Введите значение N: ");
        int N = int.Parse(Console.ReadLine());
        
        int[,] matrix = FillMatrix(N);
        PrintMatrix(matrix);
    }

    static int[,] FillMatrix(int N)
    {
        int[,] matrix = new int[N, N];
        
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                matrix[i, j] = (i + j) % N + 1;
            }
        }
        
        return matrix;
    }

    static void PrintMatrix(int[,] matrix)
    {
        int N = matrix.GetLength(0);
        
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }
}