/// Лабараторная работа 1. Задание 3
/// <author> Богорадов Василий. Группа 20322-1
using System;

namespace lab1_3_bogoradow
{

    class MyMatrixController
    {

        public static int[,] create()
        {
            Console.Write("Введите размер матрицы: ");
            uint n = uint.Parse(Console.ReadLine());
            if (n <= 1)
            {
                throw new OverflowException("Длинна матрицы равна или меньше 1");
            }
            return new int[n, n];
            
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

        public static int getSumSecindaryDiagonal(int[,] data)
        {
            int result = 0;
            int n = data.GetLength(0);
            for (int i = 0; i < n; i++)
            {
                result += data[i, n - i -1];
            }
            return result;
        }
    }

    class lab1_3_bogoradow
    {
        static void Main(string[] args)
        {
            try
            {
                int [,] a=MyMatrixController.create();
                MyMatrixController.input(a);
                Console.WriteLine("Введенная матрица:");
                MyMatrixController.print(a);
                Console.WriteLine("Сумма элементов расположенный на побочной матрице равна {0}", MyMatrixController.getSumSecindaryDiagonal(a));
                
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
