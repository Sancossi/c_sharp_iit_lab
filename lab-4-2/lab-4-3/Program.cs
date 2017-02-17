/// Выполнен студентом группы 60322-2 Богорадов Василий
///
/// Создать программу для поиска по всему диску файлов и каталогов, удовлетворяющих заданной маске. Необходимо вывести найденную информацию на экран в компактном виде (с нумерацией объектов) и запросить у пользователя о дальнейших действиях. Варианты действий: удалить все найденное, удалить указанный файл (каталог), удалить диапазон файлов (каталогов). 
using System;
using System.Text;
using System.IO;


namespace lab_4_3
{

    /// <summary>
    /// Класс для хранения списка имен файлов 
    /// </summary>
    class List
    {
        public string[] data = null; // поле хранения имен файлов
        

        public string[] Data
        {
            get
            {
                if (data != null)
                {
                    return data;
                }
                return null;
            }
        }

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
            if(position > (data.Length)) // проверяем не хотим ли мы удалить элемент за пределами массива
            {
                throw new IndexOutOfRangeException(); // выбрасываем исключение если это так
            }
            string[] result = new string[data.Length + 1]; // создаем новый массив для хранения новых данных
            for(var i = 0; i < position; i++) // проходим от начала массива до места вставки
            {
                result[i] = data[i]; // заносим данные из старого массива в новый
            }
            result[position] = item; // вставляем в новый массив элемент для вставки
            for(var i = position + 1; i < result.Length; i++) // идем от следующией позиции от ставки до конца нового массива
            {
                result[i + 1] = data[i]; // заносим данные из старого массива в новый со смещением
            }
            data = result; // присваеваем ссылку на новый массив полю 
        }

        /// <summary>
        /// Метод удаляет элемент находящийся по заданному индексу и возвращаем имя удаленного элемента
        /// </summary>
        /// <param name="position">Индекс удаляемого элемента</param>
        /// <returns>Имя удаленного элемента</returns>
        public  string Delete(int position)
        {

            if(position > (data.Length - 1)) // проверяем не хотим ли мы удалить элемент за пределами массива
            {
                throw new IndexOutOfRangeException(); // выбрасываем исключение если это так
            }
            string buffer = data[position]; // получаем удаляемый элемент
            string[] result = new string[data.Length - 1]; // создаем новый массив 
            for(var i = 0; i < position; i++) // проходим по нему от начала до места удаления
            {
                result[i] = data[i]; // копируем данные из старого массива  в новый
            }
            for(var i = position; i < result.Length; i++) // перебираем элементы от места удаления до конца массива
            {
                result[i] = data[i + 1]; // копируем данные из старого массива в новый со смещением
            }
            data = result; // присваеваем сслыку на новый массив полю
            return buffer; // возвращаем удаленный элемент
        }

        /// <summary>
        /// Добавляет в конец массива элемент
        /// </summary>
        /// <param name="item">Элемент для вставки</param>
        public void Add(string item)
        {
            InsertElement(item, data.Length);
        }

        public void Add(List items)
        {
            Add(items.ToString());
        }

        /// <summary>
        /// Добавляет в конец списка имен файлов 
        /// </summary>
        /// <param name="items"></param>
        public void Add(string[] items)
        {
            string[] result = new string[data.Length + items.Length]; // создаем новый массив для хранения данных
            for(var i = 0; i < data.Length; i++) // проходим от начала до конца первоначального массива
            {
                result[i] = data[i]; // копируем данные в новый массив
            }
            for(var i = data.Length; i < result.Length; i++)  // проходим от конца первочального массива до конца нового массива
            {
                result[i] = items[i - data.Length]; // вставляем данные в новый массив со смещением 
            }

            data = result; // присваеваем ссылку на новый массив полю
        }

        

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            
            foreach(string s in data)
            {
                result.Append(s)
                    .Append("\n");
            }

            return result.ToString();
            
        }
    }

    
    class Controller
    {
        List list = null;

        public Controller()
        {

        }



        public void Delete(int start, int end)
        {
            if(start < 0)
            {
                start = 0;
                Console.WriteLine("Ошибка. Выход за допустимые пределы. Начальное значение диапазона изменено на {0}", start);
            }
            if(list.Data.Length > end)
            {
                end = list.Data.Length;
                Console.WriteLine("Ошибка. Выход за допустимые пределы. Конечное значение диапазона изменено на {0}", end);
            }
            for (var i = end; i > start; i++)
            {
                string buffer = list.Delete(i);
                if(File.Exists(buffer))
                {
                    File.Delete(buffer);
                }
                else if(Directory.Exists(buffer))
                {
                    Directory.Delete(buffer);
                }
                
            }
        }

        public List GetList(string path,string mask)
        {
            if(!Directory.Exists(path)) // Проверяем существует ли указанная папка 
            {
                throw new DirectoryNotFoundException(); 
            }
            List result = new List();
            string[] listdirs = Directory.GetDirectories(path,  mask);
            string[] listfiles = Directory.GetFiles(path, mask);

            result.Add(path);
            result.Add(listfiles);

            foreach(string dir in listdirs)
            {
                result.Add(GetList(dir, mask));
            }
            return result;
        }
    }

    class Menu
    {

        
        Controller controller = null;
        public Menu()
        {
            controller = new Controller();
        }

        public void ChangeDisk()
        {

        }
        public void View(string path, string mask)
        {
            List list = controller.GetList(path, mask);
            Console.WriteLine(list.ToString());
            // TODO: Сделать компактный вид
        }

        public void View(int start, int end)
        {

        }

        public void Delete()
        {

        }
        public void Delete(int index)
        {

        }

        public void Delete(int start, int end)
        {

        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.View("D:\\IIT", "*");

        }
    }
}
