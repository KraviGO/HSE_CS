/*
 * Пересдача проекта 1_1.
 * Дисциплина: "Программирование"
 * Группа: БПИ249
 * Студент: Кравченко Игорь
 * Дата: 03.10.2024
 * Вариант: 18
 * Задание: Основное
 */

namespace ConsoleApp1
{
    internal static class Program
    {
        /// <summary>
        /// Цикл жизни программы.
        /// </summary>
        public static void Main()
        {
            bool repeat;
            do
            {
                repeat = RunProgram();
            } while (repeat);
        }

        /// <summary>
        /// Основная логика решения.
        /// </summary>
        /// <returns> True - продолжить цикл жизни, false - прервать цикл жизни. </returns>
        private static bool RunProgram()
        {
            try
            {
                // Определение рабочей директории.
                string path = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().LastIndexOf("ConsoleApp1", StringComparison.Ordinal));
            
                // Путь до файлов ввода/вывода.
                string inputFilePath = $"{path}/WorkingFiles/input.txt";
                string outputFilePath = $"{path}/WorkingFiles/output.txt";
            
                // Считывание данных.
                string[] lines = ReadWrite.ReadFile(inputFilePath);
            
                // Проверка, что файл содержит информацию.
                if (lines.Length == 0)
                {
                    Console.WriteLine("В файле не найдено содержимое");
                    AskForExit();
                    return true;
                }
            
                // Считывание массива.
                ReadWrite.ReadArrayInt(lines[0], out int[] array1);
                ReadWrite.ReadArrayInt(lines[1], out int[] array2);
            
                // Проверка, что массивы равной длины и они не нулевой длины.
                if (array1.Length == 0 || array2.Length == 0 || array1.Length != array2.Length)
                {
                    ReadWrite.WriteFileLines(outputFilePath, ["-1"]);
                    Console.WriteLine("Корректных данных в файле нет");
                    AskForExit();
                    
                    return true;
                }

                // подсчет значений
                (int minArray1, int maxArray1) = MinAndMaxInArray(array1);
                (int minArray2, int maxArray2) = MinAndMaxInArray(array2);
                double s = CalculateS(array1, array2);

                // формирование строки с ответом
                string[] ansLines = new string[5];
                
                ansLines[0] = $"Минимальный из X: {minArray1}";
                ansLines[1] = $"Максимальное из X: {maxArray1}";
                ansLines[2] = $"Минимальный из Y: {minArray2}";
                ansLines[3] = $"Максимальное из Y: {maxArray2}";
                ansLines[4] = $"S = {s:F4}";
            
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

        /// <summary>
        /// Проверка на выход из цикла жизни.
        /// </summary>
        /// <returns> True - нажали Escape, false - иначе. </returns>
        private static bool AskForExit()
        {
            Console.WriteLine("Для выхода нажмите Escape....");
            ConsoleKeyInfo keyToExit = Console.ReadKey();
            return keyToExit.Key == ConsoleKey.Escape;
        }

        /// <summary>
        /// За 1 проход цикла, определяет минимальный и максимальные значения элементов в непустом массиве.
        /// </summary>
        /// <param name="array"> Массив в котором производится расчет. </param>
        /// <returns> (mn, mx), где mn - минимальное значение, mx - максимальное значение.
        ///             Для пустого массива вернет (0, 0).
        /// </returns>
        private static (int, int) MinAndMaxInArray(int[] array)
        {
            if (array.Length == 0)
            {
                return (0, 0);
            }
            
            int mn = array[0];
            int mx = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                mn = Math.Min(mn, array[i]);
                mx = Math.Max(mx, array[i]);
            }

            return (mn, mx);
        }
    
        /// <summary>
        /// Считает значение S по формуле.
        /// </summary>
        /// <param name="array1"> Первый массив X. </param>
        /// <param name="array2"> Второй массив Y. </param>
        /// <returns> Значение S. </returns>
        private static double CalculateS(int[] array1, int[] array2)
        {
            try
            {
                double s = 0;

                checked
                {
                    for (int i = 0; i < array1.Length; i++)
                    {
                        s += (1.0 / array1[i]) + (1.0 / array2[i]);
                    }
                }

                return s;
            }
            catch (OverflowException)
            {
                Console.WriteLine("Переполнение при расчёте S.");
                throw;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Деление на 0 при расчёте S.");
                throw;
            }
        }
    }
}