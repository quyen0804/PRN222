using FUNewsManagement.Models;
using FUNewsManagement.Repository;

namespace FUNewsManagement.Service
{
    public class NewsService
    {
        private readonly NewsRepository _newsRepository;

        public NewsService(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public NewsArticle GetNewsArticleById(string id)
        {
            return _newsRepository.GetNewsArticleById(id);
        }

        public void DeleteNewsArticleById(string id)
        {
            _newsRepository.Delete(_newsRepository.GetNewsArticleById(id));
        }

        public void CreateNews(NewsArticle newsArticle)
        {
            _newsRepository.Add(newsArticle);
        }

        public void UpdateNews(NewsArticle newsArticle)
        {
            _newsRepository.Update(newsArticle);
        }
    }
}
