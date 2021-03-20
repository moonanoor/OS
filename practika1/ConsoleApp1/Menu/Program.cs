using System;

namespace Menu
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu:
            int Menu_args;
            Console.WriteLine("Меню: \n");
            Console.WriteLine("1. Информация о дисках:");
            Console.WriteLine("2. Создание .txt файла:");
            Console.WriteLine("3. XML Файлы:");
            Console.WriteLine("4. JSON Файлы:");
            Console.WriteLine("5. ZIP - файлы:");
            Console.WriteLine("0. Выйти");
            Menu_args = Convert.ToInt32(Console.ReadLine());
            switch (Menu_args)
            {
                case 1: Task1.Main(); goto Menu;
                case 2: Task2.Main(); goto Menu;
                case 3: Task3.Main(); goto Menu;
                case 4: Task4.Main(); goto Menu;
                case 5: Task5.Main(); goto Menu;
                case 0: break;
                default: goto Menu;
            }
        }
    }
}
