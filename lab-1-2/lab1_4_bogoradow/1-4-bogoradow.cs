/// Лабараторная работа 1. Задание 4. Вариант 2
/// Богорадов Василий. Группа 60322-2
/// 
/// Дан массив размером NxN, элемент которого целые числа(Для хранения массив использовать ступенчатый массив)
/// Четные столбцы заменить на вектор X
/// 
using System;

namespace lab1_4_bogoradow
{
    /// <summary>
    /// Класс для работы с двумерными матрицами представленными ввиде двумерного ступенчатого массива
    /// </summary>
    class MyMatrixController
    {

        /// <summary>
        /// Метод создания двумерного ступенчатого массива массив заданной длинны length 
        /// </summary>
        /// <returns>Пустой массив заданной длинны</returns>
        public static int[][] create()
        {
            int lenght = 0;
            Console.Write("Введите длинну массива: ");
            while (true)
            {
                try
                {
                    lenght = int.Parse(Console.ReadLine());
                    if (lenght <= 1) throw new OverflowException("Размер матрицы не должен быть меньше либо равен 1");
                    break;
                }
                catch (FormatException e)
                {
                    Console.Write(e.Message);
                    Console.WriteLine("Пожайлуства повторите ввод");
                }
                catch(ArgumentNullException e)
                {
                    Console.Write(e.Message);
                    Console.WriteLine("Пожайлуства повторите ввод");
                }
                catch(OverflowException e)
                {
                    Console.Write(e.Message);
                    Console.WriteLine("Пожайлуства повторите ввод");
                }   
              
            }
           
            
            int[][] a = new int[lenght][];
            for(int i = 0; i < lenght; i++)
            {
                a[i] = new int[lenght];
            }
            return a;
        }

        /// <summary>
        /// Метод выполняет ввод элементов двумерного массива с клавиатуры
        /// </summary>
        /// <param name="data">Двумерный рваный массив</param>
        public static void inputMatrix(int[][] data)
        {
            if (data.Length == 0) throw new OverflowException("Пустой массив");
            if (data.Length != data[0].Length) throw new OverflowException("Размеры матрицы не корректны");

            for(int i = 0; i < data.Length;i++)
            {
                for(int j = 0; j < data[i].Length; j++)
                {
                    Console.Write("data[{0}][{1}]= ", i, j);
                    data[i][j] = int.Parse(Console.ReadLine());
                }
            }
        }



        /// <summary>
        /// Метод выполняет ввод элементов вектора с клавиатуры
        /// </summary>
        /// <param name="lenght">Длинна вектора</param>
        /// <returns>Вектор представленный ввиде одномерного массива целых чисел</returns>
        public static int[] inputVector(int lenght)
        {
            if (lenght <= 0) throw new OverflowException("Длинна вектора меньше либо ровна нулю");
            int[] result = new int[lenght];

            for(int i = 0; i < result.Length; i++)
            {
                Console.Write("vector[{0}]= ", i);
                result[i] = int.Parse(Console.ReadLine());
            }

            return result;
        }

        /// <summary>
        /// Метод заменяет четные столбцы матрицы вектором
        /// </summary>
        /// <param name="matrix">Исходная матрица</param>
        /// <param name="vector">Вектор</param>
        /// <returns>Матрица с заменеными четными столбцами на вектор</returns>
        public static int[][] changeMatrix(int[][] matrix, int[] vector)
        {
            if (matrix.Length == 0) throw new OverflowException("Матрица пуста");
            if (matrix.Length != vector.Length) throw new OverflowException("Матрица и вектор имеют разную длинну");

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i].Length != matrix.Length) throw new OverflowException("Одна из строк имеет длинну отличную от длинны столбца");
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if(j % 2 != 0) //т.к. у массивов измерение начинает с 0, то нечетные столбцы массива будут являться четными столбцами матрицы
                    {
                        matrix[i][j] = vector[i];
                    }
                }
            }

            return matrix;
        }

        public static void print(int[][] matrix)
        {
            foreach(int[] row in matrix)
            {
                foreach(int i in row)
                {
                    Console.Write("{0,5}", i);
                }
                Console.WriteLine();
            }
        }
        
    }

    class lab1_4_bogoradow
    {
        static void Main(string[] args)
        {
            try
            {
                int[][] matrix = MyMatrixController.create();
                Console.WriteLine("Введите матрицу");
                MyMatrixController.inputMatrix(matrix);
                Console.WriteLine("Введите вектор");
                int[] vector = MyMatrixController.inputVector(matrix.Length);
                Console.WriteLine("Исходная матрица");
                MyMatrixController.print(matrix);
                Console.WriteLine("Изменная матрица");
                matrix = MyMatrixController.changeMatrix(matrix, vector);
                MyMatrixController.print(matrix);

            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Выход за пределы массива");
            }
            catch(OutOfMemoryException)
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
