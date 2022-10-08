using System;
using System.Collections.Generic;
using System.Linq;
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
        int birthYear;

        public Person()
        {
            name = "Пусто";
            suname = "Пусто";
            birthDay = new DateTime(1);
            birthYear = birthDay.Year;
        }

        public Person(string name, string suname, DateTime birthDay)
        {
            if (name.Length < 2 || suname.Length < 2 || birthDay > DateTime.Today)
                Console.WriteLine("Неверно введены данные!");
            else
            {
                this.name = name;
                this.suname = suname;
                this.birthDay = birthDay;
                this.birthYear = birthDay.Year;
            }
        }

        public string GetName() { return name; }

        public void SetName(string name) { this.name = name; }

        public string GetSuname() { return suname; }

        public void SetSuname(string suname) { this.suname = suname; }

        public DateTime GetBirthDay() { return birthDay; }

        public int GetBirthYear() { return birthYear; }

        public void SetBirthYear(int year) { birthYear = year; birthDay.AddYears(2); }

        public string ToFullString()

        {

            return "Имя: " + name + "Фамилия: " + suname +
                "Дата рождения: " + birthDay + "Год рождения: " + birthYear;
        }

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

        public string ToFullString()
        {
            return "Автор: " + Author.ToFullString() + "Название статьи: " + Title +
                "Рейтинг статьи: " + Top;
        }
    }

    class Magazine
    {
        string title;
        Frequency period;
        DateTime dateIn;
        int edition;
        Article[] articlesInMagazine;

        public Magazine()
        {
            title = "Неизвестно";
            period = 0;
            dateIn = new DateTime(1);
            edition = 0;
            //массив артиклов?
        }

        public Magazine(string title, Frequency period, DateTime dateIn, int edition)
        {
            this.title = title;
            this.period = period;
            this.dateIn = dateIn;
            this.edition = edition;
        }

        public string GetTitle() { return title; }
        public void SetTitle(string title) { this.title = title; }
        public Frequency GetPeriod() { return period; }
        public void SetPeriod(Frequency period) { this.period = period; }
        public DateTime GetDateIn() { return dateIn; }
        public void SetDateIn(DateTime dateIn) { this.dateIn = dateIn; }
        public int GetEdition() { return edition; }
        public void SetEdition(int edition) { this.edition = edition; }
        public void PrintArtticles() { foreach (Article article in articlesInMagazine) { Console.WriteLine(article.ToFullString()); } }
        public double GetSredTop()
        {
            double sum = 0;
            foreach (var article in articlesInMagazine)
            {
                sum += article.Top;
            }
        }

    }



    internal class Program

    {

        static void Main(string[] args)

        {



        }

    }

}

