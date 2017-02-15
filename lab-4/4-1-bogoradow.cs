/// <summary>
///Создать программу, которая ищет в указанном каталоге файлы, удовлетворяющие заданной маске, и дата последней модификации которых находится в указанном диапазоне. Поиск производится как в указанном каталоге, так и в его подкаталогах. Результаты поиска сбрасываются в файл отчета. 
///Выполнил студент группы 60322-2 Богорадов 
/// </summary>
using System;
using System.IO;
using System.Text;

namespace lab_4_bogoradow
{
    class Program
    {

        /// <summary>
        /// Проверка файла 
        /// </summary>
        /// <param name="path">Путь к корневой папке</param>
        /// <param name="mask">Маска поиска файла</param>
        /// <param name="start">Начало диапазона изменения файла(не раньше чем)</param>
        /// <param name="end">Конец диапазона изменения файла(не позже чем)</param>
        /// <returns></returns>
        public static string FindFilesInFind(string path, string mask, DateTime start, DateTime end)
        {
                       
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException();
            }

            StringBuilder sb = new StringBuilder();

            string[] listdir = Directory.GetDirectories(path);

            string[] listfiles = Directory.GetFiles(path, mask);


            
            // проходим по списку полученных файлов
            foreach (string s in listfiles)
            {
                
                if(File.GetLastWriteTime(s) < end && File.GetLastWriteTime(s) > start)
                {
                    sb.Append(Path.GetFileName(s))
                        .Append("\t")
                        .Append(File.GetLastWriteTime(s))
                        .Append("\n");
                }
            }
            
            // если есть файлы которые удовлетворяют условиям то добавляем в начало строки название каталога
            if (sb.Length !=0)
            {

                sb.Insert(0, path + "\n");
            }

            // рекурсивно запускаем поиск в подкатологах(если такие есть)
            foreach (string s in listdir)
                sb.Append(FindFilesInFind(s, mask, start, end));

            return sb.ToString();
        }
        static void Main(string[] args)
        {
            try
            {
                //string dirpath = "H:\\IIT";

                Console.Write("Введите каталог для поиска(по умолчаню) > ");
                string dirpath = Console.ReadLine();

                if (dirpath == "")
                {
                    dirpath = "H:\\IIT";
                }

                Console.Write("Введите маску для поиска > ");
                string filemask = Console.ReadLine();
                if(filemask == "")
                {
                    filemask = "*.doc";
                }

                Console.Write("Введите начало изменения : ");
                string buffer = Console.ReadLine();
                DateTime start = new DateTime();
                if (buffer == "")
                {
                    start = DateTime.MinValue;
                }
                else
                {
                    start = DateTime.Parse(Console.ReadLine());
                }
                buffer = "";

                Console.Write("Введите конец изменения : ");
                buffer = Console.ReadLine();
                DateTime end = new DateTime();
                if (buffer == "")
                {
                    end = DateTime.MaxValue;
                }
                else
                {
                    end = DateTime.Parse(Console.ReadLine());
                }
                Console.WriteLine(FindFilesInFind(dirpath, filemask, DateTime.MinValue, DateTime.Now));
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
            catch(PathTooLongException)
            {

            }
            catch(FormatException)
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
