using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab2

{

    enum Frequency { Weekly, Monthly, Yearly }

    internal class Program

    {

        static void Main(string[] args)

        {

            //Создание 1 автора и его статей
            DateTime date1 = new DateTime(1989, 6, 6);
            Person author1 = new Person("Александр", "НеПушкин", date1);
            Article a1 = new Article(author1, "\"Секреты солений\"", 4.9);

            //Создание 2 автора и его статей
            DateTime date2 = new DateTime(1954, 2, 10);
            Person author2 = new Person("Скворцов", "Олег", date2);
            Article a2 = new Article(author2, "\"10 лучших бегунов 2021\"", 4.3);
            Article a3 = new Article(author2, "\"Калистеника: система тренировок с собственным весом\"", 4.0);

            //Создание журнала
            Magazine magazine = new Magazine("Журналище", 0, DateTime.Today, 2);

            //Добавление статей в журнал
            magazine.AddArticles(a1, a2, a3);

            //Вывод информации о журнале без списка статей и с ним
            Console.WriteLine($"Короткое представление информации о журнале\n{magazine.ToShortString()}");
            Console.WriteLine("\n-----------------------\n");
            Console.WriteLine($"Полное представление информации о журнале\n{magazine.ToFullString()}");

            //Присвоение значение через свойства класса Magazine
            magazine.Title = "Изменёнус";
            magazine.Edition = 100500;
            magazine.DateRelease = date1;
            magazine.Period = Frequency.Monthly;

            Console.WriteLine("-----------------------\nДополнительное задание\n");
            Console.WriteLine(magazine.ToFullString());



            //Дополнительное задание
            Console.WriteLine("Введите значение nrow и ncolomn через ; или : соответственно");
            string strToRead = Console.ReadLine();
            string[] arrStringToSplit = strToRead.Split(';', ':');
            int nrow = Convert.ToInt32(arrStringToSplit[0]);
            int ncolomn = Convert.ToInt32(arrStringToSplit[1]);
            Console.WriteLine($"Количество столбцов: {ncolomn}, количество строк: {nrow}");

            Article[] arr1 = new Article[nrow * ncolomn];
            Article[,] arr2 = new Article[nrow, ncolomn];
            Article[][] arr3 = new Article[nrow][];
            Random r = new Random();
            int timeBegin, timeEnd;
            
            //Измерение времени для одномерного массива
            timeBegin = Environment.TickCount;
            
            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i] = new Article();
                arr1[i].Title = $"Название {r.Next(11)}";
            }
            
            timeEnd = Environment.TickCount;
            Console.WriteLine($"Время выполнения операций для одномерного массива: {timeEnd - timeBegin} миллисекунд");
            
            //Измерение времени для прямоугольного массива
            timeBegin = Environment.TickCount;
            
            for (int i = 0; i < arr2.GetLength(0); i++)
            {
                for (int j = 0; j < arr2.GetLength(1); j++)
                {
                    arr2[i, j] = new Article();
                    arr2[i, j].Title = $"Название {r.Next(11)}";
                }
            }
            
            timeEnd = Environment.TickCount;
            Console.WriteLine($"Время выполнения операций для прямоугольного массива: {timeEnd - timeBegin} миллисекунд");

            //Измерение времени для зубчатого массива
            timeBegin = Environment.TickCount;

            for (int i = 0; i < nrow; i++)
            {
                arr3[i] = new Article[ncolomn];
                for (int j = 0; j < ncolomn; j++)
                {
                    arr3[i][j] = new Article();
                    arr3[i][j].Title = $"Название {r.Next(11)}";
                }
            }

            timeEnd = Environment.TickCount;
            Console.WriteLine($"Время выполнения операций для зубчатого массива: {timeEnd - timeBegin} миллисекунд");
        }

    }

}