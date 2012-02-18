using System.Linq;

namespace HtmlAgilityPackTool.Data
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        public void Create(T entity)
        {
            var db = new MokoEntities();
            var set = db.Set<T>();
            set.Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            var db = new MokoEntities();
            var set = db.Set<T>();
            set.Remove(entity);
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            var db = new MokoEntities();
            db.SaveChanges();
        }

        public IQueryable<T> Query()
        {
            var db = new MokoEntities();
            var set = db.Set<T>();
            return set;
        }
    }
}
