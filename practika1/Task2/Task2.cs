using System;
using System.IO;
using System.Text;


public class Task2
{
    public static void Main()
    {
        string path = @"C:\Users\User\source\repos\OS\practika1\Task2\text.txt";

        if (File.Exists(path))
        {
            File.Delete(path);
        }

        using (FileStream fs = File.Create(path))
        {
            AddText(fs, "I`m student of RTY MIREA");
        }


        using (FileStream fs = File.OpenRead(path))
        {
            byte[] b = new byte[1024];
            UTF8Encoding temp = new UTF8Encoding(true);
            while (fs.Read(b, 0, b.Length) > 0)
            {
                Console.WriteLine(temp.GetString(b));
            }
        }
        Console.Write("Delete File?\n1)yes \t 2)no\n");
        string x = Console.ReadLine();
        if (x == "1")
        {
            File.Delete(path);
        }

    }
    private static void AddText(FileStream fs, string value)
    {
        byte[] info = new UTF8Encoding(true).GetBytes(value);
        fs.Write(info, 0, info.Length);
    }
}
