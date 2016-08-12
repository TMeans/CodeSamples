using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CodeSamples.CSharp.API
{
    public class ArticlesAPI
    {
        [WebMethod]
        public static List<Article> getAllArticles()
        {
            //assumes database context
            return database.articles.ToList();
        }

        [WebMethod]
        public static List<Article> getRelatedArticles(int articleID)
        {
            //assumes database context
            List<Article> allArticles = database.articles.ToList();
            Article mainArticle = allArticles.Where(x => x.id == articleID).FirstOrDefault();
            if(mainArticle != null)
            {
                allArticles.Remove(mainArticle);
                return RelatedArticles.GetRelatedArticles(mainArticle, allArticles);
            }
            return null;
        }
    }

    
}