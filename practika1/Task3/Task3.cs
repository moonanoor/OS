using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

}

public class Task3
{
    public static async Task Main()
    {
        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            Person tom = new Person() { Name = "Tom", Age = 35 };
            await JsonSerializer.SerializeAsync<Person>(fs, tom);
            Console.WriteLine("Data has been saved to file");
        }

        using (FileStream fs = new FileStream("user.json", FileMode.OpenOrCreate))
        {
            Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
            Console.WriteLine($"Name: {restoredPerson.Name}  Age: {restoredPerson.Age}");
        }
    }

}
