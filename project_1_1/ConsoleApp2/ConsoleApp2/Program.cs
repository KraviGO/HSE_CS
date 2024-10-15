/*
 * Дисциплина: "Программирование"
 * Группа: БПИ249
 * Студент: Кравченко Игорь
 * Дата: 03.10.2024
 * Вариант: 7
 * Задание: Дополнительное
 */

namespace ConsoleApp2;

internal static class Program
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
        // определение рабочей директории
        string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("ConsoleApp2"));
        
        // путь до файлов
        string configFilePath = $"{path}/WorkingFiles/config.txt";
        string inputFilePath = $"{path}/WorkingFiles/input.txt";
        string outputFilePath = $"{path}/WorkingFiles/output_{GetLastFileNum(configFilePath)+1}.txt";
        
        // считывание данных
        string[] lines = ReadWrite.ReadFile(inputFilePath);
        
        if (lines.Length == 0)
        {
            Console.WriteLine("В файле не найдено содержимое");
            AskForExit();
            return true;
        }

        // хранит ответы для всех массивов
        string[] allAnsOnArrays = new string[lines.Length];
        
        for (int i = 0; i < lines.Length; i++)
        {
            try
            {
                // считывание массива
                ReadWrite.ReadArrayInt(lines[i], out int[] array);

                if (array.Length == 0 || array.Length % 2 != 0)
                {
                    continue;
                }

                // считывание коэффициентов
                double d = ReadWrite.ReadDouble("Введите вещественный коэффициент d (0 < d <= 1): ",
                    x => 0 < x && x <= 1);
                int q = ReadWrite.ReadInt("Введите целочисленный коэффициент q (0 < q < 10): ", x => 0 < x && x < 10);

                // подсчет значений
                double c1 = CalculateC1(array, d);
                double c2 = CalculateC2(array, q);

                // формирование строки с ответом
                string ansString = $"C1: {c1:F2}\nC2: {c2:F2}\nC2/C1: {c2 / c1:F2}\nC1/C2: {c1 / c2:F2}\n";

                // сохранение ответа в массив
                allAnsOnArrays[i] = ansString;
            }
            catch (OverflowException)
            {
                Console.WriteLine($"Произошло переполнение данных для массива с {i}-й строчки");
            }
        }

        // формирование строк с ответами для записи в файл
        string[] fileLines;
        int fileLinesSize = 0;

        // подсчет количества обработанных входных масивов
        for (int i = 0; i < lines.Length; i++)
        {
            if (allAnsOnArrays[i] != null)
            {
                fileLinesSize++;
            }
        }
        
        fileLines = new string[fileLinesSize];
        
        // запись ответом на обработанные входные масивы
        for (int i = 0, j = 0; i < lines.Length; i++)
        {
            if (allAnsOnArrays[i] != null)
            {
                fileLines[j++] = allAnsOnArrays[i];
            }
        }
        
        // запись ответов в файл
        ReadWrite.WriteFileLines(outputFilePath, fileLines);
        
        // обновим номер последнего файла с ответами
        AddNumberOfFile(configFilePath);
        
        return !AskForExit();
    }

    /// <summary>
    /// Спрашивает пользователя о завершении программы
    /// </summary>
    /// <returns>При нажатии клафиши Escape - false, в остальных случаях - true</returns>
    static bool AskForExit()
    {
        ConsoleKeyInfo keyToExit;
        Console.WriteLine("Для выхода нажмите Escape....");
        keyToExit = Console.ReadKey();
        return keyToExit.Key == ConsoleKey.Escape;
    }

    /// <summary>
    /// Возвращает номер последнего существующего файла с ответами
    /// </summary>
    /// <param name="configFilePath">Пусть до файла с конфигом</param>
    /// <returns>Номер последнего файла с ответами</returns>
    static int GetLastFileNum(string configFilePath)
    {
        // при отсутствии файла он создается с 1 строчкой: "0"
        if (!File.Exists(configFilePath))
        {
            ReadWrite.WriteFileLines(configFilePath, new [] {"0"});
            return 0;
        }
        
        string[] lines = ReadWrite.ReadFile(configFilePath);

        // если файл не содержит информации о номере последнего файла вывода, то в файл запишется 1 строка: "0"
        if (lines.Length == 0 || !int.TryParse(lines[0], out int num))
        {
            ReadWrite.WriteFileLines(configFilePath, new [] {"0"});
            return 0;
        }

        return num;
    }
    
    /// <summary>
    /// Увеличивает значение числа в конфиге на 1
    /// </summary>
    /// <param name="configFilePath"></param>
    static void AddNumberOfFile(string configFilePath)
    {
        int lastFileNum = GetLastFileNum(configFilePath);
        string[] newFileNum = { (lastFileNum + 1).ToString() };
        
        ReadWrite.WriteFileLines(configFilePath, newFileNum);
    }

    /// <summary>
    /// Считает и возвращает значение С1
    /// </summary>
    /// <param name="x">Массив значений</param>
    /// <param name="d">коэффициент</param>
    /// <returns>Значение C1</returns>
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
    
    /// <summary>
    /// Считает и возвращает значение С2
    /// </summary>
    /// <param name="x">Массив значений</param>
    /// <param name="q">коэффициент</param>
    /// <returns>Значение C2</returns>
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