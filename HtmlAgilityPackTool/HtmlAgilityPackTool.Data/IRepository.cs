using System.Linq;

namespace HtmlAgilityPackTool.Data
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        IQueryable<T> Query();
    }
}
