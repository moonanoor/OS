using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
namespace Lab2
{
    public class peremennyi
    {
        public static string[] passwords =
            {
                "1115dd800feaacefdf481f1f9070374a2a81e27880f187396db67958b207cbad",
                "3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b",
                "74e1bb62f8dabb8125a58852b63bdf6eaef667cb56ac7f7cdba6d7305c50a22f"
            };
        public static char[] charactersToTest =
                {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't',
            'u', 'v', 'w', 'x', 'y', 'z'
        };
        public static DateTime timeStarted;
        public static int count_pass = 0;
        public static string result;
        public static int charactersToTestLength = charactersToTest.Length;
        public static long computedKeys = 0;
    }


    public class CreateCharArray
    {
        public static char[] CharArray(int length, char defaultChar)
        {
            return (from c in new char[length] select defaultChar).ToArray();
        }
    }

    public class Get_hash
    {
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            return sb.ToString().ToLower();
        }

        public static byte[] GetHash(string inputString)
        {
            using
                (
                    HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString)
            );

        }
    }

    public class KeySolution
    {

        public static void CreateNewKey(int currentCharPosition, char[] keyChars, int keyLength, int indexOfLastChar, string pswd)
        {

            var nextCharPosition = currentCharPosition + 1;
            for (int i = 0; i < peremennyi.charactersToTestLength; i++)
            {

                keyChars[currentCharPosition] = peremennyi.charactersToTest[i];

                if (currentCharPosition < indexOfLastChar)
                {
                    KeySolution.CreateNewKey(nextCharPosition, keyChars, keyLength, indexOfLastChar, pswd);
                }

                else
                {

                    peremennyi.computedKeys++;
                    if (Get_hash.GetHashString(new String(keyChars)) == pswd)
                    {
                        peremennyi.count_pass += 1;
                        Console.WriteLine("Поток {1}: Паролей подобрано - {0}", peremennyi.count_pass, Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine("Поток {1}: Прошло времени: {0} сек", DateTime.Now.Subtract(peremennyi.timeStarted).TotalSeconds, Thread.CurrentThread.ManagedThreadId);
                        peremennyi.result = new String(keyChars);
                        Console.WriteLine("Поток {1}: Полученный пароль: {0}", peremennyi.result, Thread.CurrentThread.ManagedThreadId);
                        Console.WriteLine("Поток {1}: Вычислено паролей: {0}", peremennyi.computedKeys, Thread.CurrentThread.ManagedThreadId);
                        return;
                    }
                }
            }
        }
        public static void StartBruteForce(int keyLength, string pswd)
        {

            var keyChars = CreateCharArray.CharArray(keyLength, peremennyi.charactersToTest[0]);
            var indexOfLastChar = keyLength - 1;
            Console.WriteLine("Хэш для потока {1}: {0}", pswd, Thread.CurrentThread.ManagedThreadId);
            KeySolution.CreateNewKey(0, keyChars, keyLength, indexOfLastChar, pswd);
        }
    }

    public class Strat_main
    {
        public static void StartProgram(object pasnumber)
        {

            Console.WriteLine("Поток {1}: Время начала подбора - {0}", peremennyi.timeStarted.ToString(), Thread.CurrentThread.ManagedThreadId);
            var estimatedPasswordLength = 5;
            KeySolution.StartBruteForce(estimatedPasswordLength, pasnumber.ToString());

        }
    }

    public class Main_class
    {
        public static void Start(int Menu)
        {
            if (Menu == 1)
            {
                peremennyi.timeStarted = DateTime.Now;
                for (int i = 0; i < 3; i++)
                {
                    Thread ytfug = new Thread(new ParameterizedThreadStart(Strat_main.StartProgram));
                    ytfug.Start(peremennyi.passwords[i]);
                }
            }
            else
            {
                peremennyi.timeStarted = DateTime.Now;
                for (int i = 0; i < 3; i++)
                {
                    Strat_main.StartProgram(peremennyi.passwords[i]);
                }
            }
        }
    }
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