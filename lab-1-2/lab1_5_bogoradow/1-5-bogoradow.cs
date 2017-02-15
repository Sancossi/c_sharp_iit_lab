/// <summary>
///Работа со строками 
///2. определяет, какой из двух заданных символов встречается чаще в строке;

/// </summary>


using System;
using System.Text;

namespace lab1_5_bogoradow
{
    class MyStringsController
    {

        /// <summary>
        /// Метод производит ввод строку с клавиатуры
        /// </summary>
        /// <returns>StringBuilder </returns>
        public static StringBuilder inputString()
        {
            Console.WriteLine("Введите строку: ");
            StringBuilder input = new StringBuilder(Console.ReadLine());
            return input;
        }


        /// <summary>
        /// Метод производит ввод двух символов с клавиатуры
        /// </summary>
        /// <returns> массив из двух символов</returns>
        public static char[] inputChars()
        {
            char[] a = new char[2];
            Console.WriteLine("Введите первый символ: ");
            a[0] = Console.ReadKey().KeyChar;
            Console.WriteLine();
            Console.WriteLine("Введите второй символ: ");
            a[1] = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return a;
        }

        public static void analize(StringBuilder text, char[] ch)
        {
            int countFirst = 0;
            int countSecond = 0;

            if(ch.Length < 2 )
            {
                throw new OverflowException("Массив строк должен быть длинной не менее двух символов");
            }



            for(int i = 0; i < text.Length; i++)
            {
                if(text[i] == ch[0])
                {
                    countFirst++;
                }

                if(text[i] == ch[1])
                {
                    countSecond++;
                }
            }

            if(countFirst > countSecond)
            {
                Console.WriteLine("Символ {0} встечается {1} раз", ch[0], countFirst);
            }
            else
            {
                Console.WriteLine("Символ {0} встечается {1} раз", ch[1], countSecond);
            }
        }
    }
    class lab1_5_bogoradow
    {
        static void Main(string[] args)
        {
            try
            {
                StringBuilder sb = MyStringsController.inputString();
                char[] a = MyStringsController.inputChars();
                MyStringsController.analize(sb, a);

            }
            catch(OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти для выделение памяти");
            }
            catch(FormatException)
            {
                Console.WriteLine("Введен не верный символ");
            }
            catch(Exception)
            {
                Console.WriteLine("Аварийное закрытие программы");
            }
        }
    }
}
