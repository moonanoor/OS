using System;
using System.IO;
using System.IO.Compression;

public class Task5
{
   public static void Main()
    {
        string[] namelist = { ".//archive", ".//text_dezip", "text.zip" };
        FileInfo check = new FileInfo(namelist[2]);
        if (check.Exists)
        {
            File.Delete(namelist[2]);
            try
            {
                Directory.Delete(namelist[0], true);
                Directory.Delete(namelist[1], true);
            }
            catch
            { }
        }
        else
        {
            DirectoryInfo dirInfo = new DirectoryInfo("archive");
            try
            {
                dirInfo.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        Console.WriteLine("Введите строку для записи в файл:");
        string text = Console.ReadLine();
        DirectoryInfo dirInfo1 = new DirectoryInfo(namelist[0]);
        dirInfo1.Create();
        using (FileStream fstream = new FileStream($"{namelist[0]}\\note.txt", FileMode.OpenOrCreate))
        {
            byte[] array = System.Text.Encoding.Default.GetBytes(text);
            fstream.Write(array, 0, array.Length);
            Console.WriteLine("Текст записан в файл");
        }
        Console.WriteLine();
        ZipFile.CreateFromDirectory(namelist[0], namelist[2]);
        Console.WriteLine($"Папка {namelist[0]} архивирована в файл {namelist[2]}");
        Console.WriteLine();
        FileInfo fileInf = new FileInfo(namelist[2]);
        if (fileInf.Exists)
        {
            Console.WriteLine("Имя файла: {0}", fileInf.Name);
            Console.WriteLine("Время создания: {0}", fileInf.CreationTime);
            Console.WriteLine("Тип файла: {0}", fileInf.Extension);
            Console.WriteLine("Размер: {0}", fileInf.Length);
            Console.WriteLine("Путь: {0}", fileInf.Directory);
        }
        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
        DirectoryInfo dirInfo2 = new DirectoryInfo(namelist[1]);
        dirInfo2.Create();
        ZipFile.ExtractToDirectory(namelist[2], namelist[1]);
        Console.WriteLine($"Файл {namelist[2]} распакован в папку {namelist[1]}");
        FileInfo fileInf2 = new FileInfo(".//text_dezip//note.txt");
        if (fileInf.Exists)
        {
            Console.WriteLine("Имя файла: {0}", fileInf2.Name);
            Console.WriteLine("Время создания: {0}", fileInf2.CreationTime);
            Console.WriteLine("Тип файла: {0}", fileInf2.Extension);
            Console.WriteLine("Размер: {0}", fileInf2.Length);
            Console.WriteLine("Путь: {0}", fileInf.Directory);
        }
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();
    }
}