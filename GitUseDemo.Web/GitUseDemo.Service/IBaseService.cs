using System.Collections.Generic;

namespace GitUseDemo.Service
{
    public interface IBaseService<TViewModel,in TModel>
    {

#pragma warning disable 693
        int Add<TModel>();
#pragma warning restore 693
#pragma warning disable 693
        int Update<TModel>();
#pragma warning restore 693
        IList<TViewModel> GetAll();
        TViewModel GetById<TId>(TId id);

    }
}