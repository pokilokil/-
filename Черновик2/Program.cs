using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Xml;
namespace Lesson2

{

    internal class Program

    {
        static string WordTranslate(string Translated, string ToTranslate)
        {
            
            Console.WriteLine("Напишите перевод " + ToTranslate);
            string word0;
            word0 = Console.ReadLine();



            while (word0 != Translated)
            {

            
                
                
                    Console.WriteLine("Это не правильный ответ. Попробуйте снова");
                    word0 = Console.ReadLine();

                

            }
            Console.WriteLine("Это правильный ответ, вы получаете 5 баллов");
            Console.WriteLine("Ваше количество баллов ");
            return word0;
        }
        static void Main(string[] args)
        {

            WordTranslate("Привет", "Hello");
            WordTranslate("Собака", "Dog");

        }
    }
}