using System.Collections.Generic;
using System.Linq;
using FUNewsManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace FUNewsManagement.Repository
{
    public class NewsRepository
    {

        private static NewsRepository _instance;
        private readonly FunewsManagementContext _context;

        public NewsRepository() { 
            _context = new FunewsManagementContext.Instance();
        }

        public NewsArticle GetNewsArticleById(string id)
        {
            try
            {
                var news = _context.NewsArticles
                    .Where(n=> n.NewsArticleId == id)
                    .OrderBy(a => a.NewsTitle)
                    .FirstOrDefault();
                if (news == null)
                {
                    throw new Exception("News article not found");

                }
                return news;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
            
        }

        public List<NewsArticle> GetAll()
        {
            return _context.NewsArticles.ToList();
        }

        public void Add(NewsArticle article)
        {
            _context.NewsArticles.Add(article);
            _context.SaveChanges();
        }

        public void Delete(NewsArticle article)
        {
            _context.NewsArticles.Remove(article);
            _context.SaveChanges();
        }

        public void Update(NewsArticle article)
        {
            _context.Entry(article).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
