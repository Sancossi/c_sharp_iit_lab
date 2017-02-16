using System;
using System.Text;


namespace lab_4_3
{

    /// <summary>
    /// Класс для хранения списка имен файлов 
    /// </summary>
    class List
    {
        string[] data = null; // поле хранения имен файлов

        /// <summary>
        /// Конструктор класса по-умолчанию
        /// </summary>
        public List()
        {
           data = new string[] { };
        }


        public List(string[] s)
        {
            data = s;
        }


        /// <summary>
        /// Метод вставляет элемент в заданную позицию
        /// </summary>
        /// <param name="item">Элемент для вставки</param>
        /// <param name="position">Позиция для вставки</param>
        private void InsertElement(string item, int position)
        {
            string[] result = new string[data.Length + 1];
            for(var i = 0; i < position; i++)
            {
                result[i] = data[i];
            }
            result[position] = item;
            for(var i = position + 1; i < result.Length; i++)
            {
                result[i + 1] = data[i];
            }
            data = result;
        }

        /// <summary>
        /// Метод удаляет элемент находящийся по заданному индексу
        /// </summary>
        /// <param name="position">Индекс удаляемого элемента</param>
        /// <returns>Имя удаленного элемента</returns>
        private string Delete(int position)
        {
            string buffer = data[position];
            string[] result = new string[data.Length - 1];
            for(var i = 0; i < position; i++)
            {
                result[i] = data[i];
            }
            for(var i = position; i < result.Length; i++)
            {
                result[i] = data[i + 1];
            }
            data = result;
            return buffer;
        }

        public void Add(string item)
        {
            
        }

        /// <summary>
        /// Добавляет в конец списка имен файлов 
        /// </summary>
        /// <param name="items"></param>
        public void Add(string[] items)
        {
            string[] result = new string[data.Length + items.Length];
            for(var i = 0; i < data.Length; i++)
            {
                result[i] = data[i];
            }
            for(var i = data.Length; i < result.Length; i++)
            {
                result[i] = items[i - data.Length];
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(data.ToString())
                .Append();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List test = new List(new string[]{ "a","b","c"});
            test.Add(new string[] { "d", "e" });

            Console.WriteLine(test.ToString());
        }
    }
}
