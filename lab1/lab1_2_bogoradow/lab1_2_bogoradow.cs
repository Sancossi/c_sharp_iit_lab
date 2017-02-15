using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab1_2_bogoradow
{

    class MyArrayController
    {
        public static int[] create()
        {
            Console.Write("Введите размер массива: ");
            uint lenght = uint.Parse(Console.ReadLine());
            if (lenght < 1)
            {
                throw new OverflowException("Неверная длинна массива");
            }
            int[] data = new int[lenght];
            return data;
        }

        public static void input(int[] data)
        {
            Console.WriteLine("Введите элементы последовательности");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("data[{0}]=", i);
                data[i] = int.Parse(Console.ReadLine());
            }
        }

        public static int findMax(int[] data)
        {
            int result = int.MinValue;
            
            foreach (int a in data)
            {
                if (a > result)
                {
                    result = a;
                }
            }

            return result;
        }

        public static void change(int[] data, int max)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == max)
                {
                    data[i] = 0;
                }
            }
        }

        public static void print(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("{0} ", data[i]);
            }
            Console.WriteLine();
        }
    }

    class lab1_2_bogoradow
    {
        static void Main(string[] args)
        {
            try
            {
                int[]a = MyArrayController.create();
                MyArrayController.input(a);
                Console.WriteLine("Исходный массив");
                MyArrayController.print(a);
                int max = MyArrayController.findMax(a);
                Console.WriteLine("Максимальный элемент в массиве равняется: {0}", max);
                MyArrayController.change(a, max);
                Console.WriteLine("Измененный массив");
                MyArrayController.print(a);
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Недостаточно памяти для создания массива");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за пределы массива");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введен некоректный символ");
            }
            catch
            {
                Console.WriteLine("Аварийное закрытие программы");
            }

        }

    }
}
