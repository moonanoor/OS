using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.IO;
public class Task4
{
   public static void Main()
    {
        XmlDocument xDoc = new XmlDocument();
        XDocument xdoc = new XDocument();
        Console.WriteLine("Сколько пользователей нужно внести?");
        string s = Console.ReadLine();
        int count = Convert.ToInt32(s);
        XElement list = new XElement("list");
        for (int i = 1; i <= count; i++)
        {
            XElement chel = new XElement("chel");
            Console.WriteLine("Введите имя пользователя");
            XAttribute username = new XAttribute("name", Console.ReadLine());
            Console.WriteLine("Введите компанию пользователся");
            XElement userage = new XElement("company", Console.ReadLine());
            Console.WriteLine("Введите имя пользователя");
            XElement usercompany = new XElement("age", Convert.ToInt32(Console.ReadLine()));
            chel.Add(username);
            chel.Add(userage);
            chel.Add(usercompany);
            list.Add(chel);
        }

        xdoc.Add(list);
        xdoc.Save("users.xml");
        Console.WriteLine("Прочитать только что записанный xml файл? y/n");
        switch (Console.ReadLine())
        {
            case "y":
                Console.WriteLine();
                xDoc.Load("users.xml");
                XmlElement xRoot = xDoc.DocumentElement;
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.Count > 0)
                    {
                        XmlNode attr = xnode.Attributes.GetNamedItem("name");
                        if (attr != null)
                            Console.WriteLine($"Имя: {attr.Value}");
                    }

                    foreach (XmlNode childnode in xnode.ChildNodes)
                    {
                        if (childnode.Name == "company")
                        {
                            Console.WriteLine($"Компания: {childnode.InnerText}");
                        }

                        if (childnode.Name == "age")
                        {
                            Console.WriteLine($"Возраст: {childnode.InnerText}");
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Удалить созданный xml файл? y/n");
                switch (Console.ReadLine())
                {
                    case "y":
                        FileInfo xmlfilecheck = new FileInfo("users.xml");
                        if (xmlfilecheck.Exists)
                        {
                            xmlfilecheck.Delete();
                        }
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("Вы не выбрали значение");
                        break;
                }
                Console.WriteLine();
                break;

            case "n":
                Console.WriteLine("Удалить созданный xml файл? y/n");
                switch (Console.ReadLine())
                {
                    case "y":
                        FileInfo xmlfilecheck = new FileInfo("users.xml");
                        if (xmlfilecheck.Exists)
                        {
                            xmlfilecheck.Delete();
                        }
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("Вы не выбрали значение");
                        break;
                }
                break;

            default:
                Console.WriteLine("Вы не выбрали значение");
                break;
        }

    }
}