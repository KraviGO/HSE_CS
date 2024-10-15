using System.Reflection.Metadata;

namespace ConsoleApp5;

public class Self9
{
    public const int ONETAB = 4;
    
    public static void SolveSelf9()
    {
        Console.Write("Введите количество строк (N): ");
        int.TryParse(Console.ReadLine(), out int n);

        int[][] table = GetTable(n);
        CalculateTable(table);
        
        PrintTable(table);
    }

    static int[][] GetTable(int n)
    {
        int[][] table = new int[n][];
        
        for (int i = 1; i <= n; i++)
        {
            table[i-1] = new int[i];
        }

        return table;
    }

    static void CalculateTable(int[][] table)
    {
        table[0][0] = 1;
        for (int i = 1; i < table.Length; i++)
        {
            table[i][0] = 1;
            table[i][^1] = 1;
            for (int j = 1; j < i; j++)
            {
                table[i][j] = table[i - 1][j] + table[i - 1][j - 1];
            }
        }
    }

    static void PrintTable(int[][] table)
    {
        
        for (int i = 0; i < table.Length; i++)
        {
            Console.Write(new string('\t', (table.Length - i - 1) / 2));
            
            for (int j = 0; j < table[i].Length; j++)
            {
                if (i % 2 == 1)
                {
                    Console.Write(new string(' ', ONETAB));
                }
                Console.Write(table[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }
}