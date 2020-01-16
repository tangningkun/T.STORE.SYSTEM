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
        private readonly IStoreSystemRepository<TEntity> _repositiory;

        protected BaseAppService(IStoreSystemRepository<TEntity> repositiory)
        {
            _repositiory = repositiory;
        }

        /// <summary>
        /// 异步单条查询(可根据条件)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = await _repositiory.FirstOrDefaultAsync(predicate ?? (t => true));
            return query;
        }
        /// <summary>
        /// 同步单条查询(可根据条件)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var query = _repositiory.FirstOrDefault(predicate ?? (t => true));
            return query;
        }

        /// <summary>
        /// 获取所有数据(可根据条件)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            var query = await _repositiory.GetAllListAsync(predicate ?? (t => true));
            return query.OrderByDescending(d => d.CreateTime).ToList();
        }
        /// <summary>
        /// 统计总数(可根据条件)
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repositiory.CountAsync(predicate ?? (x => true));
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            return await _repositiory.InsertEntityAsync(entity);
        }
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual async Task<bool> EditAsync(TEntity entity)
        {
            return await _repositiory.EditEntityAsync(entity);
        }
    }
}
