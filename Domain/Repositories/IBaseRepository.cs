using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBaseRepository <TEntity> where TEntity : BaseDomain
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task <TEntity>GetById(int id);
        Task<TEntity> List();
        Task<TEntity> GetByName(string name);



    }

}
