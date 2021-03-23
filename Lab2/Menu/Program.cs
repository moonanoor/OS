using System;
using Methods_For_lab_3;
namespace Lab2
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
        Menu:
            int Menu_args;
            Console.WriteLine("Меню: \n");
            Console.WriteLine("1. Многопоточный:");
            Console.WriteLine("2. Однопоточный:");
            Menu_args = Convert.ToInt32(Console.ReadLine());
            switch (Menu_args)  
            {
                
                
                case 1: Main_class.Start(Menu_args) ;  goto Menu;
                case 2: Main_class.Start(Menu_args) ; goto Menu;
                case 0: break;
                default: goto Menu;
            }
        }
    }
}