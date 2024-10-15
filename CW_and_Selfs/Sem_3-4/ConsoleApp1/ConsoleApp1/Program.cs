using System;

internal class Separate
{
    // Получает на вход коэффициенты a, b, c квадратного уравнения.
    // Возвращает в параметрах x1 и x2 корни квадратного уравнения
    // Возвращает через return количество корней уравнения
    public static int Solve(double a, double b, double c, out double x1, out double x2)
    {
        x1 = x2 = 0;

        // уравнение вида c = 0
        if (a == 0 && b == 0)
        {
            if (c == 0) 
            {
                return 3;
            }
            return 0;
        }
        // линейное уравнение
        if (a == 0)
        {
            x1 = -c / b;
            x2 = 0;
            return 1;
        }
        // квадратное уравнение
        double d = Math.Sqrt((b * b) - (4 * a * c));
        // есть решения кв уравнения
        if (d >= 0)
        {
            x1 = (-b - d) / (2*a);
            x2 = (-b + d) / (2*a);
            return 2;
        }
        // нет решений кв уравнения
        return 0;
    }

    // Запрашивает у пользователя три коэффициента квадратного уравнения
    public static void ReadAbc(out double a, out double b, out double c)
    {
        // Считывание 1 переменной с проверкой на корректность, c - название переменной
        static void ReadValue(char c, out double x)
        {
            Console.Write($"Enter a value for {c}: ");
            while (!double.TryParse(Console.ReadLine(), out x)) {
                Console.WriteLine("Value is incorrect");
                Console.Write($"Enter a value for {c}: ");
            }
        }

        ReadValue('a', out a);
        ReadValue('b', out b);
        ReadValue('c', out c);
    }

    // Выводит количество корней и сами корни
    public static void ShowSolution(int rootCount, double x1, double x2)
    {
        string message;

        switch (rootCount)
        {
            case 0:
                message = $"Корней нет";
                break;
            case 1:
                message = $"Количество корней = 1. Корень = {x1}";
                break;
            case 2:
                message = $"Количество корней = 2. Корень 1 = {x1}. Корень 2 = {x2}";
                break;
            default:
                message = $"Бесконечное количество корней";
                break;
        }

        Console.WriteLine(message);
    }
}

internal class Program
{
    private static void Main()
    {
        Separate.ReadAbc(out double a, out double b, out double c);
        // Console.WriteLine($"a: {a}; b: {b}; c: {c}");

        int rootCount = Separate.Solve(a, b, c, out double x1, out double x2);
        // Console.WriteLine(rootCount);

        Separate.ShowSolution(rootCount, x1, x2);
    }
}