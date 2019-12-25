using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Domain;
using T.STORE.SYSTEM.Repository.EntityFramework;

namespace T.STORE.SYSTEM.Application.Base
{
    public abstract class BaseAppService<TEntity> : IBaseAppService<TEntity> where TEntity : Entity
    {
        private readonly IStoreSystemRepositoryBase<TEntity> _repositiory;

        protected BaseAppService(IStoreSystemRepositoryBase<TEntity> repositiory)
        {
            _repositiory = repositiory;
        }

        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = await _repositiory.FirstOrDefaultAsync(predicate ?? (t => true));
            return query;
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _repositiory.FirstOrDefault(predicate ?? (t => true));
            return query;
        }


        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var query = await _repositiory.GetAllListAsync(predicate ?? (t => true));
            return query.OrderByDescending(d => d.CreateTime).ToList();
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositiory.CountAsync(predicate ?? (x => true));
        }
    }
}
