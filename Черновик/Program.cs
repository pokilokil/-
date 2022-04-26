
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

//Задача "Хватит ли мне денег на переезд в Америку ,если я переведу свои рубли в долларовую валюту"
{
    // API или dll - публичные методы и классы!
    // внутри у этого кода могут быть свои внутренныи классы 
    // есть публичные методы которые всем видны
    // есть детали реализации под капотом - приват
    public class CurrencyConverter
    {
        private string _name = "hello";
        private string apikey = "fadsfaf35235234efw32";
        public string CURRENCY="";
        //свойство. по сути это Гет и Сет функции в одну строку
        //public double kurs { get { if (kurs > 100) return 100}; };    private set; }


        private double pkurs;
        public double GetKurs()
        {
            if (pkurs > 100) return 100;
            return pkurs;
        }
        private void SetKurs(double k)
        {
            pkurs = k;
        }

        public CurrencyConverter(string curr)
        {
            //консруктор. вызывается при слове new и в основном заполняет поля и проводит проверки
            if (curr.Length == 3)
            {
                CURRENCY = curr;
            }
            else
            {
                //erorr
                throw new FormatException("3 letters!");
            }
        }
        public CurrencyConverter()
        {
            //пустой
            CURRENCY = "USD";
        }
        /// <summary>
        /// главная функция. возвращает курс валюты
        /// функция - это просто название куска кода, параметры и тд
        /// метод - привязанная к классу фукнция (метод класса CurrencyConverter)
        /// </summary>
        /// <param name="currency">три буквы валюты</param>
        /// <returns>ЧИСЛО курса</returns>
        public double mainConverter(string currency )
        {
            string line = returnLineFromCBR();

            double result = InternetSearch(line, currency);
            
            SetKurs(result);

            return result;
        }
        public double mainConverterField()
        {
            string line = returnLineFromCBR();

            double result = InternetSearch(line, CURRENCY);

            return result;
        }
        //получаем строку из ЦБ. приват - пользователю это не надо
        private string returnLineFromCBR()
        {
            string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            WebResponse response = null;
            StreamReader strReader = null;
            WebRequest request = WebRequest.Create(url);
            response = request.GetResponse();
            strReader = new StreamReader(response.GetResponseStream());
            string line = strReader.ReadToEnd();
            response.Close();

            return line;
        }
        //ищем в строке валютут - приват, пользователю это не надо тоже
        private double InternetSearch(string line, string courceof)
        {
            int posUSD = line.IndexOf(courceof);//ищем USD
            int positionValue = line.IndexOf("Value", posUSD);
            int posBeginCourse = positionValue + 6;
            string course = line.Substring(posBeginCourse, 7);
            double courceUSD = Convert.ToDouble(course);
            return courceUSD;
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
        http://www.cbr.ru/scripts/XML_daily.asp

            //string url = "http://www.cbr.ru/scripts/XML_daily.asp";
            //WebResponse response = null;
            //StreamReader strReader = null;
            //WebRequest request = WebRequest.Create(url);
            //response = request.GetResponse();
            //strReader = new StreamReader(response.GetResponseStream());
            //string line = strReader.ReadToEnd();
            //response.Close();

            CurrencyConverter cv = new CurrencyConverter("USD");
            //cv.CURRENCY = "USD";

            Console.WriteLine( cv.mainConverter("USD") );
            Console.WriteLine(cv.GetKurs);
        }
        //static double InternetSearch(string line, string courceof)
        //{
        //    int posUSD = line.IndexOf(courceof);//ищем USD
        //    int positionValue = line.IndexOf("Value", posUSD);
        //    int posBeginCourse = positionValue + 6;
        //    string course = line.Substring(posBeginCourse, 7);
        //    double courceUSD = Convert.ToDouble(course);
        //    return courceUSD;
        //}
    }
}