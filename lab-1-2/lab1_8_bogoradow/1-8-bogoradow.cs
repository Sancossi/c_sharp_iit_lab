/// <summary>
/// Выполнит студент группы 60322-2 Богорадов Василий.
/// II.В двумерном массиве, элементы которого – целые числа, произвести следующие действия:
/// 1.	Вставить новую строку после строки, в которой находится первый встреченный минимальный элемент.
/// 2.	Вставить новый столбец перед всеми столбцами, в которых встречается заданное число.
/// 3.	Удалить все строки, в которых нет ни одного четного элемента.
/// 4.	Удалить все столбцы, в которых все элементы положительны.
/// 5.	Удалить из массива k-тую строку и j-тый столбец, если их значения совпадают.
/// 6.	Уплотнить массив, удалив из него все нулевые строки и столбцы. 

/// </summary>


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_8_bogoradow
{
    class MyArray2D
    {
        private int[,] Data; // поле для хранения массива
        
        private int Row // число для хранения колличества строк в массиве
        { get; set; } 
        private int Collumn // поле для хранения колличества стобцов в массиве
        { get; set; } 

        /// <summary>
        /// Конструктор класса, создает пустой массив заданных размеров
        /// </summary>
        /// <param name="Row">Колличество строк</param>
        /// <param name="Collumn">Колличество столбцов</param>
        public MyArray2D(int Row, int Collumn)
        {
            Data = new int[Row, Collumn];
            this.Row = Row;
            this.Collumn = Collumn;
        }

        /// <summary>
        /// Конструктор класса, созданиет массив по образцу
        /// </summary>
        /// <param name="Data">Двумерный массив</param>
        public MyArray2D(int[,] data)
        {
           Data = data;
            this.Row = data.GetLength(0);
            this.Collumn = data.GetLength(1);
        }
        /// <summary>
        /// Выводит на экран массив
        /// </summary>
        public void Print()
        {
            for(int rowCount = 0; rowCount < Row; rowCount++)
            {
                for(int colCount = 0; colCount < Collumn; colCount++)
                {
                    Console.Write("{0} ", Data[rowCount, colCount]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Вставляет в текущий массив строку по заданному индексу
        /// </summary>
        /// <param name="index">Индекс вставляемой строки</param>
        /// <param name="row">строка</param>
        private void InsertRow(int index, int[] row)
        {
            // проверяем дали пустую строку
            if (row.Length == 0)
           { 
                // TODO: Вставить исключение
            }
            // проверяем совпадает ли длина вставляемой строки и длинна массива
            if (row.Length != this.Collumn)
            {
                // TODO: Вставить исключение
            }
            // проверяем не хотим ли мы вставить строку, за пределами текущего массива

            if (index > (Row + 1))
            {
                // TODO: Вставить исключение
            }

            this.Row++; // Увеличиваем колличество строк для работы с массивом 
            int[,] newData; // Обьявляем ссылку для работы с массивом

            if (Data.GetLength(0) > this.Row) // Проверяем есть свободные строки в массиве(ситуация возможна после удаления строк)
            {
                // Случай когда в массиве есть свободное место
                newData = Data;// Выделение памяти не нужно. Присваеваем ссылку на уже существующий массив 
            }
            else
            {
                // Случай когда свободного места в массиве нет
                newData = new int[Row, Collumn]; // Создаем новый массив в соотвесвии с необходимыми размерам массива
                // Переписываем массив с начала до места вставки новой строки 
                for (int rowCount = 0; rowCount < index; rowCount++)
                {
                    for (int colCount = 0; colCount < this.Collumn; colCount++)
                    {
                        newData[rowCount, colCount] = Data[rowCount, colCount]; // Переписываем все данные не смешая их до места вставки новой 
                    }
                }
            }

            // Переписываем массив с последней строки до места вставки
            for (int rowCount = this.Row - 1; rowCount > index; rowCount--)
            {
                for (int colCount = 0; colCount < this.Collumn; colCount++)
                {
                    newData[rowCount, colCount] = Data[rowCount - 1, colCount]; // Переписываем все данные смешая их на одну строку ниже
                }
            }

            //переписываем вставляемую строку
            for (int colCount = 0; colCount < this.Collumn; colCount++)
            {
                newData[index, colCount] = row[colCount];
            }

            // присваемываем ссылку на измененный массив текущему
            Data = newData;

        }

        /// <summary>
        /// Добавляет в текущий массив столбец по заданому индексу
        /// </summary>
        /// <param name="index">Индекс для вставки</param>
        /// <param name="collumn" >Cтоблец для вставки</param>
        private void InsertCollumn(int index, int[] collumn)
        {
            // проверяем дали пустую строку
            if (collumn.Length == 0)
            {
                // TODO: Вставить исключение
            }
            // проверяем совпадает ли длина вставляемой строки и длинна массива
            if (collumn.Length != this.Row)
            {
                // TODO: Вставить исключение
            }
            // проверяем не хотим ли мы вставить строку, за пределами текущего массива
            if (index > (this.Collumn + 1))
            {
                // TODO: Вставить исключение
            }

            this.Collumn++; // Увеличиваем пространство для работы с массивом

            int[,] newData; // Обьявляем ссылку на новый массив

            if(Data.GetLength(1) > Collumn) // Проверяем есть ли свободные столбцы в массиве
            {
                // Случай когда в массиве есть свободное место
                newData = Data;// Выделение памяти не нужно. Присваеваем ссылку на уже существующий массив 
            }
            else
            {
                // Случай когда свободного места в массиве нет
                // Необходимо расширение
                newData = new int[Row, Collumn]; // Создаем новый массив в соотвесвии с необходимыми размерам массива
                // Переписываем все столбцы от начала до места вставки в новый массив
                for (int rowCount = 0; rowCount < this.Row; rowCount++)
                {
                    for (int colCount = 0; colCount < index; colCount++)
                    {
                        newData[rowCount, colCount] = Data[rowCount, colCount]; // Переписываем все данные смешая их на одну строку ниже
                    }
                }
            }

            // Переписываем массив с последнего стобца до места вставки
            for (int rowCount = 0; rowCount < this.Row; rowCount++)
            {
                for (int colCount = this.Collumn -1 ; colCount > index; colCount--)
                {
                    newData[rowCount, colCount] = Data[rowCount, colCount-1]; // Переписываем все данные смешая их на один столбец правее
                }
            }

            // присваемываем ссылку на измененный массив текущему
            Data = newData;
        }

        /// <summary>
        /// Удаляет строку из массива по заданному индексу
        /// </summary>
        /// <param name="index">Индекс для удаления строки</param>
        private void DeleteRow(int index)
        {
            // Провермяем не хотим ли мы удалить строку которая находиться за пределелами массива
            if(index < 0 || index > this.Row)
            {
                // TODO: Вставить исключение 
            }

            // Идем от строки удаления до конца массива
            for(int rowCount = index; rowCount <this.Row -1; rowCount++)
            {
                for(int colCount = 0; colCount < this.Collumn; colCount++)
                {
                    // Переписываем все данные смешая их на один строку выше
                    Data[rowCount, colCount] = Data[rowCount+1, colCount]; 
                }
            }           
            // Уменшаем доступное число строк для работы с массивом
            Row--; 
            
        }

        /// <summary>
        /// Удаляем столбец из массива по заданному индексу
        /// </summary>
        /// <param name="index">Индекс для удаления столбца</param>
        private void DeleteCollumn(int index)
        {
            // Провермяем не хотим ли мы удалить строку которая находиться за пределелами массива
            if (index < 0 || index > this.Collumn)
            {
                // TODO: Вставить исключение 
            }

            // Идем от удаляемого столбца до конца массива
            for(int rowCount = 0; rowCount < this.Row; rowCount++)
            {
                for(int colCount = index; colCount < this.Collumn -1 ; colCount++)
                {
                    // Переписываем все данные смешая их на один столбец левее
                    Data[rowCount, colCount] = Data[rowCount, colCount + 1];
                }
            }
            // Уменшаем доступное число столбцов для работы с массивом
            Collumn--;
        }

        /// <summary>
        ///  Вставляет новую строку после строки, в которой находится первый встреченный минимальный элемент.
        /// </summary>
        /// <param name="row">Столбец для вставки в текущий массив</param>
        public void InsertRowFromMinElement(int[] row)
        {
            int min = Int32.MaxValue; // минимальный найденный элемент
            int minRowIndex= -1; // номер строки к которой содержиться минимальный надейнный элемент
            for(int x = 0; x < this.Row; x++ )
            {
                for(int y = 0; y < this.Collumn; y++)
                {
                    if(Data[x,y] < min)
                    {
                        minRowIndex = x;
                        min = Data[x, y];
                    }
                }
            }
            if(minRowIndex > -1)
            {
                InsertRow(minRowIndex+1, row);
            }
        }

        /// <summary>
        /// Вставляет новый столбец перед всеми столбцами, в которых встречается заданное число.
        /// </summary>
        /// <param name="value">Искомое значение</param>
        /// <param name="collumn">Стобец для вставки в массив</param>
        public void IndertCollumnAfterGivenNumber(int value,int [] collumn)
        {
            for(int y = this.Collumn -1; y >=0 ; y--)// Перебераем стоблцы начиная с конца массива(слева направо)
            {
                // Перебераем строки от начала до конца
                for(int x = 0; x < this.Row; x++) 
                {
                    //если нашли совпадение
                    if (Data[x,y] == value) 
                    {
                        // Вставляем строку
                        InsertCollumn(y, collumn);
                        // Выходим из цикла
                        break;
                    }
                }
                
            }
        }

        /// <summary>
        /// Удаляет все строки, в которых нет ни одного четного элемента.
        /// </summary>
        public void DeleteRowWithoutEvenElement()
        {
            bool isEven = false;
            for (int x = 0; x < this.Row; x++)
            {
                isEven = false;
                for (int y = 0; y < this.Collumn; y++)
                {
                    // Проверяем является ли четный элемент
                    if (Data[x, y] % 2 == 0 )
                    {
                        isEven = true;
                        // Выходим из этой итерации 
                        break;
                    }
                }
                // Если не найден четный элемент
                if(!isEven)
                {
                    DeleteRow(x); //Удаляем строку
                }
            }
        }

        /// <summary>
        /// Удалить все столбцы, в которых все элементы положительны.
        /// </summary>
        public void DeleteCollumnWithAllPositiveElements()
        {
            bool allPositiveElements = true;
            for (int y = this.Collumn - 1; y >= 0; y--)// Перебераем стоблцы начиная с конца массива(слева направо)
            {
                allPositiveElements = true; // в начале итерации устанавливаем флаг все элементы положительны
                // Перебераем строки от начала до конца
                for (int x = 0; x < this.Row; x++)
                {
                    // есть элемент меньше нуля
                    if(Data[x,y] < 0)
                    {
                        // Устанавливаем флаг на ложь
                        allPositiveElements = false;
                        // Завершаем итерацию
                        break;
                    }
                }
                // если все элементы в столбце положителы
                if (allPositiveElements)
                {
                    // удаляем его
                    DeleteCollumn(y);
                }

            }
        }

        /// <summary>
        /// Удалить из массива k-тую строку и j-тый столбец, если их значения совпадают.
        /// </summary>
        /// <param name="k">Индекс строки для проверки</param>
        /// <param name="j">Индекс столбца для проверки</param>
        public void DeleteRowAndCollumnIfEquals(int k, int j)
        {
            if (Row != Collumn)
            {
                // Что делать если длинны разные?!
            }

            bool isEqual = true;
            for (int i = 0; i < Row; i++)
            {
                if (Data[j, i] != Data[i, k])
                {
                    isEqual = false;
                }
            }
            if (!isEqual)
            {
                DeleteRow(k);
                DeleteCollumn(j);
            }

        }

        /// <summary>
        /// Уплотняет массив, удалив из него все нулевые строки и столбцы.
        /// </summary>
        public void DeleteAllZeroRowsAndCollumns()
        {
            DeleteAllZeroRows();
            DeleteAllZeroCollums();
        }

        /// <summary>
        /// Удаляет все строки состоящие из нулей
        /// </summary>
        private void DeleteAllZeroRows()
        {
            bool isZeroRow = true;
            for (int x = 0; x < this.Row; x++)
            {
                isZeroRow = true;
                for (int y = 0; y < this.Collumn; y++)
                { 
                    // есть элемент меньше нуля
                    if (Data[x, y] != 0)
                    {
                        // Устанавливаем флаг на ложь
                        isZeroRow = false;
                        // Завершаем итерацию
                        break;
                    }
                }
                if(isZeroRow)
                {
                    DeleteRow(x);
                }
            }
        }
        /// <summary>
        /// Удаляет все столбцы состоящие из нулей
        /// </summary>
        private void DeleteAllZeroCollums()
        {
            bool isZeroCollumn = true;
            for (int y = this.Collumn - 1; y >= 0; y--)// Перебераем стоблцы начиная с конца массива(слева направо)
            {
                isZeroCollumn = true; // в начале итерации устанавливаем флаг все равны нулю
                // Перебераем строки от начала до конца
                for (int x = 0; x < this.Row; x++)
                {
                    // есть элемент не равен нулю
                    if (Data[x, y] != 0)
                    {
                        // Устанавливаем флаг на ложь
                        isZeroCollumn = false;
                        // Завершаем итерацию
                        break;
                    }
                }
                // если все элементы в столбце положителы
                if (isZeroCollumn)
                {
                    // удаляем его
                    DeleteCollumn(y);
                }

            }
        }
    }
    class lab1_8_bogoradow
    {
        static void Main(string[] args)
        {
            int[,] a = { { 1, 2, 3, 4 }, { 2, 5, -6, 7 }, { 3, 11, 9, 1 }, { -4, 0, 0, 0 }, { 0, 0, 0, 0 } };
            MyArray2D b = new MyArray2D(a);
            b.Print();
            Console.WriteLine();
            int[] c = { 0, 0, 0, 0 };
            b.DeleteAllZeroRowsAndCollumns();           
            b.Print();

        }
    }
}
