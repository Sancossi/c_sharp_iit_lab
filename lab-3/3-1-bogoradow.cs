///Лабараторная работа 3. Вариант 2. Студент группы 60322-2. Богорадов Василий
///1.	Создать абстрактный класс Stud с методами, позволяющим вывести на экран информацию о персоне, а также определить ее возраст(на момент текущей даты). 
///2.	Создать производные классы: Абитуриент(фамилия, дата рождения, факультет), Студент(фамилия, дата рождения, факультет, курс), Преподавать(фамилия, дата рождения, факультет, должность, стаж), со своими методами вывода информации на экран, и определения возраста.
///3.	Создать базу(массив) из n персон, вывести полную информацию из базы на экран, а также организовать поиск персон, чей возраст попадает в заданный диапазон–. 


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace lab3_bogoradow

{

    abstract class Stud
    {
        protected string surname; // Фамилия
        protected DateTime birthday; // Дата рождения
        protected string deportament; // Факультет

        /// <summary>
        /// Конструктор класса 
        /// Какие то изменения
        
        /// </summary>
        /// <param name="surname"></param>
        /// <param name="birthday"></param>
        public Stud(string surname, DateTime birthday, string deportament)
        {
            this.surname = surname;
            this.birthday = birthday;
            this.deportament = deportament;
        }

        /// <summary>
        /// Выводит на экран информацию о человеке
        /// </summary>
        public virtual void PrintPersonalInfo()
        {
            Console.WriteLine("Фимилия: " + surname);
            Console.WriteLine("Дата рождения: " + birthday.ToString("d"));
            Console.WriteLine("Факультет: " + deportament);
        }

        /// <summary>
        /// Выводит на экран возраст человека на сегоднешний день
        /// </summary>
        public virtual void PrintAge()
        {
            Console.WriteLine("Возраст: " + (Age));
        }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - birthday.Year;
            }
        }

    }

    /// <summary>
    /// Класс абитуриент
    /// </summary>
    class Enrolle : Stud
    {
        
        protected int course; // Курс

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="surname">Фимилия</param>
        /// <param name="dt">Дата рождение</param>
        /// <param name="deportament">Факультет</param>
        /// <param name="course">Курс</param>
        public Enrolle(string surname, DateTime dt, string deportament, int course):base(surname, dt, deportament)
        {
           
            this.course = course;
        }

        /// <summary>
        /// Выводит на экран информацию о абитуриенте
        /// </summary>
        public override void PrintPersonalInfo()
        {
            base.PrintPersonalInfo();
            Console.WriteLine("Курс: " + course);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(surname)
                .Append("\t")
                .Append(birthday.ToString("d"))
                .Append("\t")
                .Append(deportament)
                .Append("\t")
                .Append(course);
            return sb.ToString();
        }
    }

    /// <summary>
    /// Класс преподователь
    /// </summary>
    class Teatcher : Stud
    {
        
        protected string position; // должность
        protected int standing; // стаж

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="surname">Фамилия</param>
        /// <param name="dt">Дата рождения</param>
        /// <param name="deportament">Факультет</param>
        /// <param name="position">Должность</param>
        /// <param name="standing">Стаж</param>
        public Teatcher(string surname, DateTime dt, string deportament, string position, int standing) : base(surname, dt, deportament)
        {
            this.position = position;
            this.standing = standing;
        }

        
        /// <summary>
        /// Вывод на экран персональной информации преподователя
        /// </summary>
        public override void PrintPersonalInfo()
        {
            base.PrintPersonalInfo();
            Console.WriteLine("Должность: " + position);
            Console.WriteLine("Стаж: " + standing);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(surname)
                .Append("\t")
                .Append(birthday.ToString("d"))
                .Append("\t")
                .Append(deportament)
                .Append("\t")
                .Append(position)
                .Append("\t")
                .Append(standing) ;

            return sb.ToString();
        }
    }

    /// <summary>
    /// Класс для работы с базой студентов
    /// </summary>
    class StudController
    {
        static string filename = null; // путь к файлу
        
        /// <summary>
        /// Свойство для доступа к полю
        /// </summary>
        public static string Path
        {
            set
            {
                filename = value;
            }

            get
            {
                return filename;
            }
        }
        public static Stud ParseLine(string line)
        {
            Stud result = null;
            string[] subs = line.Split('\t');
            if(subs.Length == 4)
            {
                result = new Enrolle(subs[0], DateTime.Parse(subs[1]), subs[2], int.Parse(subs[3]));
            }
            else
            {
                if (subs.Length == 5)
                {
                    result = new Teatcher(subs[0], DateTime.Parse(subs[1]), subs[2], subs[3], int.Parse(subs[4]));
                }
                else throw new FormatException("База поврежденна");
            }

            return result;
        }
        public static Stud[] LoadFile()
        {
            string[] lines = null;
            Stud[] result = null;
            if (filename != null)
            {
                lines = System.IO.File.ReadAllLines(filename);


                result = new Stud[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    result[i] = ParseLine(lines[i]);
                }
            }
            return result;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Stud[] c = null;
            try
            {
                StudController.Path = @"D:\test\base.txt";
                c = StudController.LoadFile();
                Console.WriteLine("Считано из файла {0} записей", c.Length);
            } catch(FileNotFoundException e)
            {
                Console.WriteLine("Файл не найдет. " + e);
                Environment.Exit(e.HResult);

            }
            catch (FileLoadException e)
            {
                Console.WriteLine("Ошибка чтения файла" +e);
                Environment.Exit(e.HResult);

            }
            catch (Exception e )
            {
                Console.WriteLine("Ошибка: " + e);
                Environment.Exit(e.HResult);
            } 

            try {
                foreach (Stud s in c)
                {
                    s.PrintPersonalInfo();
                    s.PrintAge();
                    Console.WriteLine();
                }
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Ошибка: " + e);
                Environment.Exit(e.HResult);

            }

            int a = 0;
            int b = 0;

            try
            {
                Console.Write("Введите начало диапазона поиска: ");
                a = int.Parse(Console.ReadLine());

                Console.Write("Введите конец диапазона поиска: ");
                b = int.Parse(Console.ReadLine());

                if (a > b)
                {
                    int buf = a;
                    a = b;
                    b = buf;
                }
                Console.WriteLine("Результаты поиска: ");
                foreach (Stud s in c)
                {
                    if (s.Age <= b && s.Age >= a)
                    {
                        s.PrintPersonalInfo();
                        s.PrintAge();
                        Console.WriteLine();
                    }
                }
            } catch(FormatException e)
            {
                Console.WriteLine("Введен не коректный символ: " + e);
                Environment.Exit(e.HResult);

            }

            
        }
    }
}
