using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OzkaInsaat.Dal.Abstract
{
    public interface IGenericRepository<T>
    {
        List<T> TGetList();
        T TgetItemByID(int id);
        int TAdd(T entity);
        void TUpdate(T entity);
        void TDelete(T p);
        void SaveChange();
    }
}
