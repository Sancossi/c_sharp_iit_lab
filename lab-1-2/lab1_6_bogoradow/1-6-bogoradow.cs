/// <summary>
/// Дана строка, в которой содержится осмысленное текстовое сообщение.
/// Слова сообщения разделяются пробелами и знаками препинания.
/// Вывести только те слова сообщения,  которые начинаются с прописной буквы.
/// Богорадов Василий. Вариант 2. Группа 60322-2. 
/// </summary>



using System;
using System.Text;


namespace lab1_6_bogoradow
{

    class MyStringController
    {
        /// <summary>
        /// Метод для ввода строки с клавиатуры
        /// </summary>
        /// <returns>Возвращает строку</returns>
        public static string inputString()
        {
            Console.WriteLine("Введите строку: ");

            string data = Console.ReadLine();

            return data;
        }
        /// <summary>
        /// Метод выводит на монитор символы начинающиеся с большой буквы
        /// </summary>
        /// <param name="text">Строка для анализа</param>
        public static void analize(string text)
        {
            string[] l = text.Split(' ', ',', '?', '-', '!');

            StringBuilder sb = new StringBuilder();

            foreach(string s in l)
            {


                if(s.Length>0 && char.IsUpper(s[0]))
                {
                    sb.Append(s).Append(" ");
                }
            }

            Console.WriteLine("Найденные слова");
            Console.WriteLine(sb);
        }
    }
    
    class lab1_6_bogoradow
    {
        /// <summary>
        /// Точка входа в приложение
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try {
                string s = MyStringController.inputString();
                MyStringController.analize(s);

            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за пределы массива");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти");

            }
            catch (Exception)
            {
                Console.WriteLine("Аварийное закрытие программы");
                Console.WriteLine();
            }
        }
    }
}
