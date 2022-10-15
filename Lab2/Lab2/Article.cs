using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Article
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
}
