///<summary>Создать программу для поиска указанного текста в файлах, удовлетворяющих заданной маске, и замене этого тектса на другой указанный текст. Поиск производится как в указанном каталоге, так и в его подкаталогах. 
/// Выполнит студент группы 60322-2 Богорадов Василий
/// </summary>	


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab_4_2
{

    class Program
    {
        /// <summary>
        /// Метод производит поиск текста в файлах удовлетворяющих заданной маске, и заменяет этот текст на другой указанный. 
        /// </summary>
        /// <param name="pathdir">Папка для поиска</param>
        /// <param name="mask">Маска для файлов</param>
        /// <param name="find">Текст для поиска</param>
        /// <param name="replace">Текст для замены</param>
        public static void FindAndReplace(string pathdir, string mask, string find, string replace)
        {
            if(Directory.Exists(pathdir)) // Проверяем существует ли указанная папка 
            {
                throw new DirectoryNotFoundException(); 
            }

            string[] listdir = Directory.GetDirectories(pathdir); // получаем список подкатологов

            string[] listfile = Directory.GetFiles(pathdir, mask); // получаем список файлов удовлетворяющих условию

            foreach(string filename in listfile) // проходим по полученному списку файлов
            {
                string text = File.ReadAllText(filename); // читаем весь файл в переменную
                text = text.Replace(find, replace); // Заменяем текст
                File.WriteAllText(filename, text); // Записываем изменения
            }

            foreach(string dirname in listdir) // Проходим по списку подпапок в каталоге
            {
                FindAndReplace(dirname, mask, find, replace); // Запускаем рекурсивно метод поиска данных
            }
        }

        /// <summary>
        /// Точка входа в программу
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Пожалуйства введите папку для поиска.");
                Console.WriteLine("[По-умолчанию C:\\Test]");
                Console.Write(">");
                string pathdir = Console.ReadLine(); // чтение пользовательских данных 
                if(pathdir == "") // если ничего не введенено
                {
                    pathdir = "C:\\Test"; // то заменяем значением по-умолчанию
                }

                Console.WriteLine("Пожалуйства введите маску для поиска.");
                Console.WriteLine("[По-умолчанию *.*");
                Console.Write(">");
                string mask = Console.ReadLine(); // чтение пользовательских данных
                if(mask == "") // если ничего не введено
                {
                    mask = "*.*";
                }

                Console.WriteLine("Пожалуйства введите текст для поиска.");
                Console.WriteLine("[По-умолчанию ничего]");
                Console.Write(">");
                string findtext = Console.ReadLine();


                Console.WriteLine("Пожалуйства введите текст для замены.");
                Console.WriteLine("[По-умолчанию ничего]");
                Console.Write(">");
                string pasletext = Console.ReadLine();

                FindAndReplace(pathdir, mask, findtext, pasletext);



            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (ArgumentNullException)
            {

            }
            catch (ArgumentException)
            {

            }
            catch (PathTooLongException)
            {

            }
            catch (FormatException)
            {

            }
            catch (IOException)
            {

            }
            catch (NotSupportedException)
            {

            }

        }
    }
}
