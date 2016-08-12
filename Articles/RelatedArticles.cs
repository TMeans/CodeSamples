using System;
using System.Collections.Generic;
using System.Linq;

public class RelatedArticles
{
    //Given a particular article, find, score, and return a list of related articles using multiple criteria (dates, authors, keywords, titles)
    public static List<Article> GetRelatedArticles(Article mainArticle, List<Article> allArticles)
    {
        SortedDictionary<Article, double> score = new SortedDictionary<Article, double>();

        foreach (Article article in allArticles)
        {
            string authorName = article.author.fullname();
            double commonTagCount = 0;
            double titleScore = 0;
            double totalScore = 0;
            double authorScore = 0;
            double dateYearTagScore = 0;
            double dateWeightedScore = 0;


            foreach (string tag in mainArticle.tags)
            {
                //if main articles tag matches the title of any other article in the list
                if (article.title == tag)
                {
                    titleScore = 5;
                }

                //if a tag or date in the main article matches the date of another article, or vice versa
                if (tag.IndexOf(article.date.Year.ToString()) > -1 || article.date.Year.ToString().IndexOf(tag) > -1 || article.date.Year == mainArticle.date.Year)
                {
                    dateYearTagScore = 0.5;
                }

                //if author name in the main article matches a tag of another article, or vice versa
                if (tag.IndexOf(authorName) > -1 || authorName.IndexOf(tag) > -1)
                {
                    authorScore += 2;
                }

                //if tags are shared between articles, even partially
                foreach (string articleTag in article.tags)
                {
                    if (tag.IndexOf(articleTag) > -1 || articleTag.IndexOf(tag) > -1)
                    {
                        commonTagCount += 0.5;
                    }
                }
            }

            //custom scoring criteria giving extra relative weight to recent articles
            TimeSpan timespan = (DateTime.Now - article.date);
            if (timespan.Days < 365)
            {
                dateWeightedScore += 7 / Convert.ToDouble(timespan.Days + 1);
            }
            dateWeightedScore += 1 / Convert.ToDouble(timespan.Days + 1);

            totalScore = commonTagCount + titleScore + authorScore + dateYearTagScore + dateWeightedScore;            

            if (totalScore > 0)
            {
                score.Add(article, totalScore);
            }  
        }

        //returns a list of related articles sorted by relation score
        return score.Keys.ToList();
    }
}
