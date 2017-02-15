///Разработать рекурсивный метод для вывода на экран всех возможных разложений натурального числа n на слагаемые (без повторений). Например, для n=5 на экран должно быть выведено:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1_10_bogoradow
{
    
    class lab1_10_bogoradow
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">осталось набрать слагаемых на сумму n</param>
        /// <param name="k">слогаемые не более k</param>
        /// <param name="s">строка для хранения слогаемых</param>
        public static void r(int n, int k, string s)
        {
            if (n < 0) return;

            if (n == 0)
            {
                Console.WriteLine(s);
                
            }
            else
            {
                if((n-k)>= 0)
                {
                    r(n - k, k, s + " " +k);
                }

                if ((k-1)>0)
                {
                    r(n, k - 1, s);
                }
            }
        }
            
        static void Main(string[] args)
        {
           
            r(5, 4, "");
        }
    }
}
