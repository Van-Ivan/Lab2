using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Лаба_1

{

    class Person
    {

        string name;
        string suname;
        DateTime birthDay;

        public Person()
        {
            Random random = new Random();
            name = "Пусто";
            suname = "Пусто";
            birthDay = new DateTime();
        }

        public Person(string name, string suname, DateTime birthDay)
        {
                this.name = name;
                this.suname = suname;
                this.birthDay = birthDay;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Suname
        {
            get { return suname; }
            set { suname = value; }
        }

        public DateTime BirthDay
        {
            get { return birthDay; }
            set { birthDay = value; }
        }

        public int BirthYear
        {
            get { return birthDay.Year; }
            set { birthDay.AddYears(birthDay.Year - value); }
        }

        public string ToFullString() { return "Имя: " + name + "Фамилия: " + suname + "Дата рождения: " + birthDay; }

        public string ToShortString() { return "Имя: " + name + "Фамилия: " + suname; }
    }

    enum Frequency { Weekly, Monthly, Yearly }

    class Article
    {
        public Person Author { get; set; }

        public string Title { get; set; }

        public double Top { get; set; }


        public Article(Person author, string title, double top)
        {
            Author = author;
            Title = title;
            Top = top;
        }

        public Article()
        {
            Author = new Person();
            Title = "Неизвестно";
            Top = 0;
        }

        public string ToFullString() { return "Автор: " + Author.ToFullString() + "Название статьи: " + Title + "Рейтинг статьи: " + Top; }
    }

    class Magazine
    {
        string title;
        Frequency period;
        DateTime dateRelease;
        int edition;
        Article[] articlesInMagazine;

        public Magazine()
        {
            title = "Неизвестно";
            period = 0;
            dateRelease = new DateTime(1);
            edition = 0;
            
        }

        public Magazine(string title, Frequency period, DateTime dateRelease, int edition)
        {
            this.title = title;
            this.period = period;
            this.dateRelease = dateRelease;
            this.edition = edition;
        }

        public string Title { get { return title; } set { title = value; } }

        public Frequency Period { get { return period; } set { period = value; } }

        public DateTime DateRelease { get { return dateRelease; } set { dateRelease = value; } }

        public int Edition { get { return edition; } set { edition = value; } }

        public double AverageTop
        {
            get
            {
                double sum = 0;

                for (int i = 0; i < articlesInMagazine.Length; i++)
                {
                    sum += articlesInMagazine[i].Top;
                }
                return sum/articlesInMagazine.Length;
            }
        }

        public void AddArticles(params Article[] articles)
        {
            Article[] arr = new Article[(articlesInMagazine?.Length ?? 0) + articles.Length];

            for (int i = 0; i < (articlesInMagazine?.Length ?? 0); i++)
            {
                arr[i] = articlesInMagazine[i];
            }

            for (int i = (articlesInMagazine?.Length ?? 0), j = 0; i < arr.Length; i++, j++)
            {
                arr[i] = articles[j];
            }

            articlesInMagazine = arr;
        }

        public string ToFullString() 
        {
            string catalogArticles = String.Empty;

            for (int i = 0; i < articlesInMagazine.Length; i++)
            {
                catalogArticles += articlesInMagazine[i].Title + '\n';
            }

            return $"Название: {title}\nПериодичность: {period}\nДата релиза: {dateRelease}\nТираж номер: {edition}\nСписок статей:\n{catalogArticles}";
        } 

        public string ToShortString()
        {
            return $"Название: {title}\nПериодичность: {period}\nДата релиза: {dateRelease}\nТираж номер: {edition}\nСредний рейтинг статей: {Convert.ToString(AverageTop)}";
        }
    }



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

            Console.WriteLine("-----------------------\n");
            Console.WriteLine(magazine.ToFullString());
        }

    }

}