/*
 * Дисциплина: "Программирование"
 * Группа: БПИ249
 * Студент: Кравченко Игорь
 * Дата: 03.10.2024
 * Вариант: 7
 * Задание: Основное
 */

namespace ConsoleApp1;

public class Program
{
    public static void Main()
    {
        bool repeat;
        do // Цикл повторения решения.
        {
            repeat = RunProgram();
        } while (repeat);
    }

    /// <summary>
    /// Основная логика решения
    /// </summary>
    /// <returns>true - продолжить цикл жизни, false - прервать цикл жизни</returns>
    static bool RunProgram()
    {
        try
        {
            // определение рабочей директории
            string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("ConsoleApp1"));
            
            // путь до файлов ввода/вывода
            string inputFilePath = $"{path}/WorkingFiles/input.txt";
            string outputFilePath = $"{path}/WorkingFiles/output.txt";
            
            // считывание данных
            string[] lines = ReadWrite.ReadFile(inputFilePath);
            
            if (lines.Length == 0)
            {
                Console.WriteLine("В файле не найдено содержимое");
                AskForExit();
                return true;
            }
            
            // считывание массива
            ReadWrite.ReadArrayInt(lines[0], out int[] array);
            
            if (array.Length == 0)
            {
                Console.WriteLine("Корректных данных в файле нет");
                AskForExit();
                return true;
            }
            
            if (array.Length % 2 != 0)
            {
                Console.WriteLine("Длина массива нечётная. Проверьте данные");
                AskForExit();
                return true;
            }
            
            // считывание коэффициентов
            double d = ReadWrite.ReadDouble("Введите вещественный коэффициент d (0 < d <= 1): ", x => 0 < x && x <= 1);
            int q = ReadWrite.ReadInt("Введите целочисленный коэффициент q (0 < q < 10): ", x => 0 < x && x < 10);

            // подсчет значений
            double c1 = CalculateC1(array, d);
            double c2 = CalculateC2(array, q);

            // формирование строки с ответом
            string[] ansLines = new string[4];
            
            ansLines[0] = $"C1: {c1:F2}";
            ansLines[1] = $"C2: {c2:F2}";
            ansLines[2] = $"C2/C1: {c2 / c1:F2}";
            ansLines[3] = $"C1/C2: {c1 / c2:F2}";
            
            // запись ответа в файл
            ReadWrite.WriteFileLines(outputFilePath, ansLines);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Произошло переполнение данных. Проверьте входные значения.");
            AskForExit();
            return true;
        }
        
        return !AskForExit();
    }

    static bool AskForExit()
    {
        ConsoleKeyInfo keyToExit;
        Console.WriteLine("Для выхода нажмите Escape....");
        keyToExit = Console.ReadKey();
        return keyToExit.Key == ConsoleKey.Escape;
    }

    static double CalculateC1(int[] x, double d)
    {
        double c1 = 0;

        try
        {
            checked
            {
                for (int i = 0; i < (x.Length - 1) / 2; i++)
                {
                    c1 += d * x[2 * i];
                }
            }
        }
        catch (OverflowException)
        {
            Console.WriteLine("Переполнение при расчёте C1.");
            throw;
        }

        return c1;
    }
    
    static double CalculateC2(int[] x, int q)
    {
        double c2 = 0;

        try
        {
            checked
            {
                for (int i = 0; i < (x.Length - 1) / 2; i++)
                {
                    c2 += x[2 * i + 1] / (double)q;
                }
            }
        }
        catch
        {
            Console.WriteLine("Переполнение при расчёте C2.");
            throw;
        }

        return c2;
    }
}