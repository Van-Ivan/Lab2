using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Magazine
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
                return articlesInMagazine.Average(article => article.Top);
                double sum = 0;

                for (int i = 0; i < articlesInMagazine.Length; i++)
                {
                    sum += articlesInMagazine[i].Top;
                }
                return sum / articlesInMagazine.Length;
            }
        }

        public void AddArticles(params Article[] articles)
        {
            Article[] arr = new Article[(articlesInMagazine?.Length ?? 0) + articles.Length];
            //Array.Resize(ref articlesInMagazine, )
            
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
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < articlesInMagazine.Length; i++)
            {
                sb.AppendLine(articlesInMagazine[i].Title);// +Environment.NewLine;
            }
            
            return $"Название: {title}\nПериодичность: {period}\nДата релиза: {dateRelease}\nТираж номер: {edition}\nСписок статей:\n{sb.ToString()}";
        }

        public string ToShortString()
        {
            return $"Название: {title}\nПериодичность: {period}\nДата релиза: {dateRelease}\nТираж номер: {edition}\nСредний рейтинг статей: {Convert.ToString(AverageTop)}";
        }
    }
}
