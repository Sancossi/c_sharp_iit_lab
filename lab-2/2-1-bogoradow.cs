/* Выполнил студент группы 60322-2 Богорадов Василий. Вариант 2
 * 2.	Создать класс Triangle, разработав следующие элементы класса: 
o	Поля: 
    -	int a, b, c; 
o	Конструктор, позволяющий создать экземпляр класса с заданными длинами сторон. 
o	Методы, позволяющие: 
        - вывести длины сторон треугольника на экран; 
        - рассчитать периметр треугольника; 
        - рассчитать площадь треугольника. 
o	Свойства: 
        -	позволяющее получить-установить длины сторон треугольника (доступное для чтения и записи); 
        -	позволяющее установить, существует ли треугольник с данными длинами сторон (доступное только для чтения). 
 2.	В класс Triangle добавить: 
o	Индексатор, позволяющий по индексу 0 обращаться к полю a, по индексу 1 - к полю b, по индексу 2 - к полю c. 
o	Перегрузку: 
    -	операции ++ (--): одновременно увеличивает (уменьшает) значение полей a, b и c на 1; 
    -	констант true и false: обращение к экземпляру класса дает значение true, если треугольник с заданными длинами сторон существует, иначе false; 
    -	операции *: одновременно домножает поля a, b и c на скаляр; 
    -	преобразования типа Triangle в string (и наоборот). 

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_bogoradow
{
    class Triangle
    {
        private double a;
        private double b;
        private double c;
        
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="a">Первая строна треугольника</param>
        /// <param name="b">Вторая строна треугольника</param>
        /// <param name="c">Третья сторона треугольника</param>
        public Triangle(double a, double b, double c)
        {
            // проверка треугольника на существование: сумма двух любых сторон должна быть больше третьей
            ///if ((a + b) < c) throw new OverflowException("Данный треугольник не может существовать");
            this.a = a;
            this.b = b;
            this.c = c;
        }

        /// <summary>
        /// Вывод длинны сторон треугольника на экран
        /// </summary>
        public void Print()
        {
            Console.WriteLine("a = {0}, b = {1}, c = {2}", a, b, c);
        }

        /// <summary>
        /// Рассчет периметра треугольника
        /// </summary>
        /// <returns>Периметр треугольника</returns>
        public double GetPerimert()
        {
            return a + b + c;
        }

        /// <summary>
        /// Рассчет площадь треугольника
        /// </summary>
        /// <returns>Площадь треугольника</returns>
        public double GetArea()
        {
            double p = (a + b + c) / 2; // получаем полупериметр треугольника
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }

        /// <summary>
        /// Свойство для доступа к строне треугольника A
        /// </summary>
        public double A
        {
            get
            {
                return a;
            }
            set
            {
                ////if (value > (b + c)) throw new OverflowException("Данный треугольник не может существовать");// проверка треугольника на существование: сумма двух любых сторон должна быть больше третьей
                this.a = value;
            }
        }

        /// <summary>
        /// Свойство для доступа к стороне B
        /// </summary>
        public double B
        {
            get
            {
                return b;
            }

            set
            {
                ////if (value > (a + c)) throw new OverflowException("Данный треугольник не может существовать");// проверка треугольника на существование: сумма двух любых сторон должна быть больше третьей
                this.b = value;
            }
        }

        /// <summary>
        /// Свойство для доступа к стороне C
        /// </summary>
        public double C
        {
            get
            {
                return c;
            }

            set
            {
                ///if (value > (a + b)) throw new OverflowException("Данный треугольник не может существовать");/// проверка треугольника на существование: сумма двух любых сторон должна быть больше третьей
                this.c = value;

            }
        }

        /// <summary>
        /// Своство для проверки на существование треугольника
        /// </summary>
        public bool IsExist
        {
            get
            {
                if ((a + b) > c) return true;
                return false;
            }
        }


        /// <summary>
        /// Индексатор для доступа к стронам треугольника
        /// </summary>
        /// <param name="i">Индекс стараны треугольника(от 0 до 2)</param>
        /// <returns>Размер соответсвующей стороны</returns>
        public double this[int i]
        {
            get
            {
                
                switch (i)
                {
                    case 0:
                        return a;
                    case 1:
                        return b;
                    case 2:
                        return c;
                    default:
                        throw new Exception("Не верный номер индексатора");
                   
                }
            }

            set
            {
                switch(i)
                {
                    case 0:
                        a = value;
                        break;
                    case 1:
                        b = value;
                        break;
                    case 2:
                        c = value;
                        break;
                    default:
                        throw new Exception("Не верный номер индексатора");
                }
            }
        }

        /// <summary>
        /// Перегрузка операции инкримента
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Triangle operator ++(Triangle x)
        {
            return new Triangle(x.A + 1, x.B + 1, x.C + 1);
        }

        /// <summary>
        /// Перегрузка операции декримента
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static Triangle operator --(Triangle x)
        {
            return new Triangle(x.A - 1, x.B - 1, x.C - 1);
        }


        public static Triangle operator *(Triangle t, double x)
        {
            return new Triangle(x*t.A, x*t.B, x*t.C);
        }
        
        /// <summary>
        /// Перегрузка оператора true
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator true(Triangle t)
        {
            if ((t.A + t.B) > t.C) return true;
            return false;
        }

        /// <summary>
        /// Перегрузка оператора false
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static bool operator false(Triangle t)
        {
            if ((t.A + t.B) < t.C) return true;
            return true;
        }

        /// <summary>
        /// Преобразование Triangle в стринг
        /// </summary>
        /// <param name="t"></param>
        public static implicit operator string(Triangle t)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(t.A)
                .Append(", ")
                .Append(t.B)
                .Append(", ")
                .Append(t.C);
            return sb.ToString();
        }

        /// <summary>
        /// Преобразование типа из string в Triangle
        /// </summary>
        /// <param name="s">Строка в формате "a, b, c"</param>
        public static implicit operator Triangle(string s)
        {
            Triangle t = new Triangle(0, 0, 0);
            string[] subs = s.Split(',', ' ');
            if (subs.Length < 0 || subs.Length > 3) throw new FormatException("Не верный формат строки");
            for(int i = 0; i < 3; i++)
            {
                t[i] = Double.Parse(subs[i]);
            }
            return t;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            string s = "1,2,3"; 
            Triangle t = new Triangle(0, 0, 0);
            t = s;
            t = t * 2;
            t.Print();

        }
    }
}
