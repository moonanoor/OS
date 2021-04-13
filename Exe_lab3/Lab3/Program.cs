using System;
using System.Collections.Generic;
using System.Threading;

namespace Lab3
{
    class Program
    {
        static bool check = true;
        private static Mutex mut = new Mutex();
        private static Thread newThread_prod;
        private static Thread newThread_cus;
        private static bool Is_ok = true;
        public static List<int> shelf = new List<int>() { };
        
        protected static int origRow = Console.CursorTop;
        protected static int origCol = Console.CursorLeft;
        static void Main(string[] args)
        {
            char stop;
            for (int i = 0; i < 3; i++)
            {
                newThread_prod = new Thread(new ThreadStart(Producer));
                newThread_prod.Name = String.Format("Thread{0}", i + 1);
               
                newThread_prod.Start();
            }

            for (int i = 0; i < 2; i++)
            {
                newThread_cus = new Thread(new ThreadStart(Customer));
                newThread_cus.Name = String.Format("Thread{0}", i + 4);
                newThread_cus.Start();
            }
            while (check)
            {
                stop = Console.ReadKey().KeyChar;
                if (stop == 'q') check = false;
            }



        }
        public static int i = 0;
        private static void Producer()
        {
            while (check)
            {
                while ((Is_ok)&&(check))
                {
                    Thread.Sleep(500);
                    if (shelf.Count > 100)
                    {
                        Is_ok = false;
                    }
                    else
                    {
                        if (shelf.Count > 100) continue;
                        Random newitem = new Random();
                        int a = newitem.Next(1, 100);
                        try
                        {
                            i++;
                            shelf.Insert(0, a);
                        }
                        catch { }
                        Console.WriteLine("{0}:Added " + i, Thread.CurrentThread.Name);
                    }
                }
            }
        }
        private static void Customer()
        {
            while (true)
            {
                if (shelf.Count > 100)
                {
                    Is_ok = false;
                }
                if (shelf.Count <= 80)
                {
                    Is_ok = true;
                }
                Thread.Sleep(500);
                if (shelf.Count != 0)
                {
                    try
                    {
                        i--;
                        shelf.RemoveAt(0);
                    }
                    catch
                    {

                    }
                    Console.WriteLine("{0}:Removed " + 1 + " from:{1}", Thread.CurrentThread.Name, shelf.Count + 1);
                }
                if ((!check) && (shelf.Count == 0)) break;
            }
        }
    }
}