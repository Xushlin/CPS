using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitUseDemo.Service
{
    public interface IBaseService<TEntity>    {
      
        int Add(TEntity entity);
       
        int Update(TEntity entity);
        
        IList<TEntity> GetAll();
        
        TEntity GetById(int Id);
        
        int Delete(TEntity entity);
    }
}
