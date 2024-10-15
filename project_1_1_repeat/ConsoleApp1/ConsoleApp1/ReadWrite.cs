namespace ConsoleApp1
{
    /// <summary>
    /// Класс с методами для считывания и вывода данных.
    /// </summary>
    public static class ReadWrite
    {
        /// <summary>
        /// Считывание всех строк из файла.
        /// </summary>
        /// <param name="path"> Путь до файла из которого будут считываться данные. </param>
        /// <returns> Массив строк. </returns>
        public static string[] ReadFile(string path)
        {
            try
            {
                // Проверяем, существует ли файл
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("Входной Файл на диске отсутствует");
                }

                // Чтение всех строк из файла
                string[] lines = File.ReadAllLines(path);

                return lines;
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Ошибка: каталог не найден");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Проблемы с открытием файла");
            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с чтением данных из файла");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        
            return [];
        }
    
        /// <summary>
        /// Переводит строку с данными в массив с целочисленными значениями.
        /// </summary>
        /// <param name="line"> Строка с данными. </param>
        /// <param name="array"> Массив для хранения корректных данных с ввода. </param>
        public static void ReadArrayInt(string line, out int[] array)
        {
            string[] input = line.Split(";");

            // Подсчет количества корректных данных.
            int arraySize = 0;
            foreach (string elem in input)
            {
                if (int.TryParse(elem, out int num) && num is > 0 and < 10000 && num % 5 == 0)
                {
                    arraySize++;
                }
            }

            array = new int[arraySize];
        
            // Заполнение массива корректными данными.
            for (int inpCur = 0, arrCur = 0; inpCur < input.Length && arrCur < arraySize; inpCur++)
            {
                if (int.TryParse(input[inpCur], out int num) && num is > 0 and < 10000 && num % 5 == 0)
                {
                    array[arrCur] = num;
                    arrCur++;
                }
            }
        }
    
        /// <summary>
        /// Выводит строки в указанный файл.
        /// </summary>
        /// <param name="filePath"> Путь до файла. </param>
        /// <param name="lines"> Массив со строками. </param>
        public static void WriteFileLines(string filePath, string[] lines)
        {
            try
            {
                // Запись строк в файл
                File.WriteAllLines(filePath, lines);
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Проблемы с сохранением файла");
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("Ошибка: каталог не найден");
            }
            catch (IOException)
            {
                Console.WriteLine("Проблемы с записью данных в файл");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}