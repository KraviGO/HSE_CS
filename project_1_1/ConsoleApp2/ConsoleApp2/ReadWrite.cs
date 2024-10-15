using System.Globalization;

namespace ConsoleApp2;

/// <summary>
/// Класс с методами для считывания и вывода данных.
/// </summary>
public class ReadWrite
{
    /// <summary>
    /// Считывание всех строк из файла
    /// </summary>
    /// <param name="path">Путь до файла из которого будут считываться данные</param>
    /// <returns>Массив строк</returns>
    public static string[] ReadFile(string path)
    {
        try
        {
            // Проверяем, существует ли файл
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"Входной Файл на диске отсутствует - {path}");
            }

            // Чтение всех строк из файла
            string[] lines = File.ReadAllLines(path);

            return lines;
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Ошибка: каталог не найден - {ex.Message}");
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Проблемы с открытием файла - {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Проблемы с чтением данных из файла - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
        
        return new string[0];
    }
    
    /// <summary>
    /// переводит строку с данными в массив с целочислеными значениями
    /// </summary>
    /// <param name="line">строка с данными</param>
    /// <param name="array">массив для хранения корректных данных с ввода</param>
    public static void ReadArrayInt(string line, out int[] array)
    {
        string[] input = line.Split(";");

        // подсчет количества коректных данных
        int arraySize = 0;
        for (int inpCur = 0; inpCur < input.Length; inpCur++)
        {
            if (int.TryParse(input[inpCur], out _)) arraySize++;
        }

        array = new int[arraySize];
        
        // заполнение массива коректными данными
        for (int inpCur = 0, arrCur = 0; inpCur < input.Length && arrCur < arraySize; inpCur++)
        {
            if (int.TryParse(input[inpCur], out array[arrCur]))
            {
                arrCur++;
            }
        }
    }

    /// <summary>
    /// Считывание целочисленной переменной. Запрашивается ввод переменной до тех пор, пока не будет введено коректное значение
    /// </summary>
    /// <param name="text">Текст выведенный перед тем как запросить ввод</param>
    /// <param name="validator">валидатор, можно задать свою функцию для определения корректности данных</param>
    /// <returns>считанное целочисленное значение</returns>
    public static int ReadInt(string text, Func<int, bool> validator = null)
    {
        // Валидатор не передан при вызове метода
        validator = validator ?? (_ => true);
        
        int value;
        do
        {
            Console.Write(text);
            if (int.TryParse(Console.ReadLine(), out value))
            {
                if (validator(value))
                {
                    return value;
                }
                Console.WriteLine("Данные не удовлетворяют условию");
            }
            else
            {
                Console.WriteLine("Некоректные ввод");
            }
        } while (true);
    }
    
    /// <summary>
    /// Считывание вещественной переменной. Запрашивается ввод переменной до тех пор, пока не будет введено коректное значение
    /// </summary>
    /// <param name="text">Текст выведенный перед тем как запросить ввод</param>
    /// <param name="validator">Валидатор, можно задать свою функцию для определения корректности данных</param>
    /// <returns>Считанное целочисленное значение</returns>
    public static double ReadDouble(string text, Func<double, bool> validator = null)
    {
        validator = validator ?? (_ => true);
        
        double value;
        do
        {
            Console.Write(text);
            string input = Console.ReadLine();
            
            if (double.TryParse(input, NumberStyles.Float, CultureInfo.CurrentCulture, out value) ||
                double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                if (validator(value))
                {
                    return value;
                }
                Console.WriteLine("Данные не удовлетворяют условию");
            }
            else
            {
                Console.WriteLine("Некоректные ввод");
            }
        } while (true);
    }
    
    /// <summary>
    /// Выводит строки в указанный файл
    /// </summary>
    /// <param name="filePath">Путь до файла</param>
    /// <param name="lines">Массив со строками</param>
    public static void WriteFileLines(string filePath, string[] lines)
    {
        try
        {
            // Запись строк в файл
            File.WriteAllLines(filePath, lines);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine($"Проблемы с сохранением файла - {ex.Message}");
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine($"Ошибка: каталог не найден - {ex.Message}");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Проблемы с записью данных в файл - {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла ошибка: {ex.Message}");
        }
    }
} 