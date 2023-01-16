using OzkaInsaat.Bll.Abstract;
using OzkaInsaat.Dal.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OzkaInsaat.Bll.Concrete
{
    public class GenericService<T>: IGenericService<T> where T : class
    {
        private readonly IServiceProvider service;
        private readonly IGenericRepository<T> repository;
        private readonly IUnitOfWork unitOfWork;
        public GenericService(IServiceProvider service)
        {
            unitOfWork = service.GetService<IUnitOfWork>();
            this.repository = unitOfWork.GetRepository<T>();
            this.service = service;
        }
        public List<T> TGetList()
        {
            return repository.TGetList();
        }
        public T TgetItemByID(int id)
        {
            return repository.TgetItemByID(id);
        }
        public int TAdd(T entity)
        {
            return repository.TAdd(entity);
        }
        public void TUpdate(T entity)
        {
            repository.TUpdate(entity);
        }
        public void TDelete(T entity)
        {
            repository.TDelete(entity);
        }
        public void SaveChange()
        {
            repository.SaveChange();
        }
    }
}
