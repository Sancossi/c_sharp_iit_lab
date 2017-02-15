using System;


namespace lab1_2015
{


    class MyArrayController
    {
        public static int[] create()
        {
            Console.Write("Введите размер массива: ");
            uint lenght = uint.Parse(Console.ReadLine());

            return new int[lenght];
        }

        public static void input(int[] data)
        {
            Console.WriteLine("Введите элементы массива");
            for(int i = 0; i < data.Length; i++)
            {
                Console.Write("data[{0}]=", i);
                data[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine();
        }

        public static void print(int[] data)
        {
            for(int i = 0; i <data.Length; i++)
            {
                Console.Write("{0}, ", data[i]);
            }
            Console.WriteLine();
        }
    }
    /// <summary>
    /// Enter point 
    /// </summary>
    class App
    {
        public static void Main()
        {
            int[] a = MyArrayController.create();
            MyArrayController.input(a);
            MyArrayController.print(a);
        }
    }
}
