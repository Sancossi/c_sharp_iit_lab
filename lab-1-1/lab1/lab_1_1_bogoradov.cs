/// Лабараторная работа 1. Задание 1
/// <author> Богорадов Василий. Группа 20322-1
using System;

namespace lab1
{
    /*Класс для работы с массивами */
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

        public static int[,] create2D()
        {
            Console.Write("Введите число стобцов массива: ");
            uint сollumns = uint.Parse(Console.ReadLine());
            if (сollumns < 1)
            {
                throw new OverflowException("Неверная длинна массива");
            }

            Console.Write("Введите число строк массива: ");

            uint rows = uint.Parse(Console.ReadLine());
            if (rows < 1)
            {
                throw new OverflowException("Неверная длинна массива");
            }

            int[,] data = new int[сollumns, rows];
            return data;
        }


        public static void input(int[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write("data[{0}]=", i);
                data[i] = int.Parse(Console.ReadLine());
            }
        }

        public static void input(int[,] data)
        {
            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    Console.Write("data[{0}][{1}]=", i, y);
                    data[i, y] = int.Parse(Console.ReadLine());
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


        public static void print(int[,] data)
        {
            for (int x = 0; x < data.GetLength(0); x++)
            {
                for (int y = 0; y < data.GetLength(1); y++)
                {
                    Console.Write("{0,5}", data[x, y]);
                }
                Console.WriteLine();
            }
        }

        public static void modify(int[] data)
        {
            Console.WriteLine("Введите границы интервала [a, b]");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());
            if (a > b) throw new OverflowException("a не может быть больше b");
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] <= b && data[i] >= a)
                {
                    data[i] = 0;
                }
            }
        }

        public static void modify(int[,] data)
        {
            Console.WriteLine("Введите границы интервала [a,b]");
            Console.Write("a = ");
            int a = int.Parse(Console.ReadLine());
            Console.Write("b = ");
            int b = int.Parse(Console.ReadLine());

            if (a > b) throw new OverflowException("a не может быть больше b");

            for (int i = 0; i < data.GetLength(0); i++)
            {
                for (int y = 0; i < data.GetLength(1); i++)
                {
                    if (data[i, y] <= b && data[i, y] >= a)
                    {
                        data[i, y] = 0;
                    }
                }
            }
        }

    }


    /*Точка входа */
    class App
    {
        static void Main()
        {
            try
            {
                int[] a = MyArrayController.create();
                MyArrayController.input(a);
                Console.WriteLine("Исходный массив");
                MyArrayController.print(a);
                MyArrayController.modify(a);
                Console.WriteLine("Измененный массив");
                MyArrayController.print(a);

                int[,] b = MyArrayController.create2D();
                MyArrayController.input(b);
                Console.WriteLine("Исходный массив");
                MyArrayController.print(a);
                MyArrayController.modify(a);
                Console.WriteLine("Измененный массив");
                MyArrayController.print(a);
                
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
                Console.WriteLine("Не достаточно памяти для создания массива");
            }
            catch (FormatException)
            {
                Console.WriteLine("Введен некорректный символ");
            }
            catch
            {
                Console.WriteLine("Аварийное закрытие программы");
            }
        }
    }
}
