/// <summary>
/// Выполнит студент группы 60322-2 Богорадов Василий.
/// Самостоятельная работа
/// I.В одномерном массиве, элементы которого – целые числа, произвести следующие действия:
/// 2.Вставить новый элемент после всех элементов, которые заканчиваются на данную цифру.
/// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_7_bogoradow
{

    class MyArray
    {

        protected int[] Data;
        protected int Length;

        /// <summary>
        /// Выполняет инициализацию пустого массива заданной длинны
        /// </summary>
        /// <param name="length">Длинна массива для инициализации</param>
        public MyArray(int length)
        {
            this.Data = new int[length];
            this.Length = length;
        }

        /// <summary>
        /// Выполняет инициализацию обьекта по заданному массиву
        /// </summary>
        /// <param name="data">Массив</param>
        public MyArray(int[] data)
        {
            this.Data = data;
            this.Length = data.Length; 
        }
        
        /// <summary>
        /// Удаляет из массива четные цифры
        /// </summary>
        public void DeleteEven()
        {
            for(int i = 0; i < Length; i++)
            {
                if(Data[i] % 2 == 0)
                {
                    Delete(i);
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        public void DeleteZeroElement()
        {
            for(int i = Length -1; i >=0; i--)
            {
                if(Data[i] == 0)
                {
                    Delete(i);
                }
            }
        }
        /// <summary>
        /// Удаляет из массива повторяющиеся значения, оставляя первое вхождение
        /// </summary>
        public void DeleteDublicate()
        {
            for(int i = 0; i < Length; i++)
            {
                for(int j = Length -1 ; j > i; j--)
                {
                    if(Data[i] == Data[j])
                    {
                        Delete(j);
                    }
                }
            }
        }

        /// <summary>
        /// Всталяет новый элеммент после всех цифр в массиве оканчивающихся на определенную цифру 
        /// </summary>
        /// <param name="value">цифра на которую оканчивается число</param>
        /// <param name="newElement">новый элемент для вставки</param>
        public void InsertAfterAllItemsGivenNummber(int value, int newElement)
        {
            
            if (value < 0)
            {
                Console.WriteLine("Введено отрицательное значение. Знак учитоваться не будет");
                value *= -1;
            }
            // Получаем колличество разрядов для случая если мы хотим найти числа заканчивающие на 99, к примеру.
            int CountDegits = 0; // число разрядов 
            if (value != 0)
            {
                int buf = value; // переменная для целочисленного деления
                while (buf > 0)
                {
                    buf /= 10;
                    CountDegits++;
                }
            }
            else
            {
                CountDegits = 1; // Костыль для того если просят посмотреть все цифры заканчивающиеся на ноль. При этом число разрядов получает равно нулю(хотя для дальнейщей работы оно должно в таком случае равняться 1)
            }
            //Console.WriteLine("Число разрядов {0}", CountDegits);

            // Идем с конца массива
            for (int i = Length - 1; i > 0; i--)
            {

                if((Data[i] % (10*CountDegits))== value)
                {
                    Insert(i + 1, newElement);
                }
            }
        }


        /// <summary>
        /// Всталяет новый элементь между парами элементов, имеющие разынме знаки
        /// </summary>
        /// <param name="newElement"></param>
        public void InsertBetweenElementWithDeffSigns(int newElement)
        {
            for(int i = Length -1; i > 0; i--)
            {
                
                if (checkDeffSigns(Data[i], Data[i-1]))
                {
                    
                    Insert(i, newElement);
                }
            }
        }

        /// <summary>
        /// "Удаляет" из массива число с заданным индексом
        /// </summary>
        /// <param name="index">Индекс элемента для удаления</param>
        private void Delete(int index)
        {
            for (int i = index; i < Length -1; i++)
            {
                Data[i] = Data[i + 1];
            }
            Data[Length - 1] = 0;
            Length--;
        }

        /// <summary>
        /// Вставляет в массив по заданному индексу число 
        /// </summary>
        /// <param name="index">Индекс для вставки в массив числа</param>
        /// <param name="value">Значение для вставки</param>
        private void Insert(int index, int value)
        {
            Length++;
            if (Data.Length >= Length)
            {
                // cлучай когда реальная длинна позволяет добавить элемент
                for (int i = Length - 1; i > index; i--)
                {
                    Data[i] = Data[i - 1];
                }
                Data[index] = value;
            }
            else
            {
                // cлучай когда реальная длинна не позволяет добавить элемент
                // Создаем новый массив 
                int[] NewData = new int[Length];
                // Копируем с права на лево элеметы до вставляемого элемента в новый массив(с конца массива) со смещением
                for (int i = Length - 1; i > index; i--)
                {
                    NewData[i] = Data[i - 1];
                }
                // Копируем слево направо элементы до вставляемого элемента в новый массив(с начала массива) без смещения
                for(int i = 0; i < index; i++)
                {
                    NewData[i] = Data[i];
                }
                //Присваеваем ссылки
                Data = NewData;
            }
            // Добавляем новое значение
            Data[index] = value;
        }

    

        /// <summary>
        /// Выводит на экран массив
        /// </summary>
        public void Print()
        {
            for(int i = 0; i <Length; i++)
            {
                Console.Write("{0} ", Data[i]);
                
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Проверяет два являются ли два числа разные знаки
        /// </summary>
        /// <param name="a">Число</param>
        /// <param name="b">Число</param>
        /// <returns>true - если знаки у двух чисел разные false - если знаки одинаковые</returns>
        private bool checkDeffSigns(int a, int b)
        {
            if (a > 0 ^ b > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    class lab1_7_bogoradow
    {
        static void Main(string[] args)
        {
            int[] a = {0,0, 1, 0 , 0,1,0};
            MyArray b = new MyArray(a);

            b.Print();
            b.DeleteZeroElement();
            b.Print();


        }
    }
}
