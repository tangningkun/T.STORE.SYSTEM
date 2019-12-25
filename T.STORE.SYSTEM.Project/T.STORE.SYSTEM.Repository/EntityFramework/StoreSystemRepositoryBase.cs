using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Domain;
using T.STORE.SYSTEM.EntityFrameworkCore;
using T.STORE.SYSTEM.Repository.EntityFramework;

namespace T.STORE.SYSTEM.Repository.EntityFramework
{
    public class StoreSystemRepositoryBase<TEntity> : IStoreSystemRepositoryBase<TEntity> where TEntity : Entity
    {
        private StoreDbContext _dbContext { get; set; }
        public StoreSystemRepositoryBase()
        {
            _dbContext = (StoreDbContext)DBContextFactory.CReateDbContext();
        }

        #region 其他
        /// <summary>
        /// 获取此存储库中所有实体的计数
        /// </summary>
        /// <returns>实体数量</returns>
        public int Count()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Count();
        }
        /// <summary>
        /// 根据给定的条件获取此存储库中所有实体的计数
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体数量</returns>
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().Count();
        }
        /// <summary>
        /// 根据给定的条件获取此存储库中所有实体的计数
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体数量</returns>
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().CountAsync();
        }
        /// <summary>
        /// 获取此存储库中所有实体的计数
        /// </summary>
        /// <returns>实体数量</returns>
        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().CountAsync();
        }
        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
                /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体得数量</returns>
        public long LongCount(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().LongCount();
        }

        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
                /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <returns>实体得数量</returns>

        public long LongCount()
        {
            return _dbContext.Set<TEntity>().AsNoTracking().LongCount();
        }
        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
        /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <returns>实体得数量</returns>
        public async Task<long> LongCountAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().LongCountAsync();
        }
        /// <summary>
        /// 根据给定谓词获取此存储库中所有实体的计数（使用此方法）
        /// 如果预期的返回值比System.Int32.MaxValue强，则重载。
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体得数量</returns>
        public async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await _dbContext.Set<TEntity>().AsNoTracking().LongCountAsync();
        }
        #endregion


        #region 删除
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        public bool DeleteEntity(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
            //_dbContext.Set<TEntity>().Remove(entity);
            return _dbContext.SaveChanges() > 0;
        }
        /// <summary>

        #endregion

        #region 插入
        public TEntity InsertEntity(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        public async Task<TEntity> InsertEntityAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task InsertEntitiesAsync(List<TEntity> entities)
        {
            using (var ctxTransaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    _dbContext.Set<TEntity>().AddRange(entities);
                    var res = await _dbContext.SaveChangesAsync();
                    if (res == entities.Count)
                        ctxTransaction.Commit();//回滚事务
                    else
                        ctxTransaction.Rollback();

                }
                catch (Exception)
                {
                    ctxTransaction.Rollback();//回滚事务
                }
            }
        }
        #endregion

        #region 获取

        /// <summary>
        /// 获取具有给定主键的实体
        /// </summary>
        /// <param name="id">获取的实体的主键</param>
        /// <returns>实体</returns>
        public TEntity Get(int id)
        {
            return _dbContext.Set<TEntity>().Where(d => d.Id.Equals(id)).AsNoTracking().FirstOrDefault();
            //return db.FirstOrDefault(CreateEqualityExpressionForId(id));
        }

        /// <summary>
        /// 获取具有给定主键的实体
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>实体</returns>
        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbContext.Set<TEntity>().Where(d => d.Id.Equals(id)).AsNoTracking().FirstAsync();
        }
        /// <summary>
        /// 获取具有给定谓词的一个实体。 如果没有实体或者引发异常
        /// 多个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体</returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll(x => true).AsNoTracking().Single(predicate);

        }
        /// <summary>
        /// 获取具有给定谓词的一个实体。 如果没有实体或者引发异常
        /// 多个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体</returns>
        public async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await GetAll(x => true).AsNoTracking().SingleAsync(predicate);
        }
        /// <summary>
        /// 获取具有给定给定谓词的实体，如果未找到则获取null
        /// </summary>
        /// <param name="predicate">谓词来过滤实体</param>
        /// <returns>实体或null</returns>
        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll(x => true).AsNoTracking().FirstOrDefault(predicate);
        }
        /// <summary>
        /// 获取具有给定主键的实体，如果未找到则获取null
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>实体或null/returns>
        public TEntity FirstOrDefault(int id)
        {
            return _dbContext.Set<TEntity>().Where(d => d.Id.Equals(id)).AsNoTracking().FirstOrDefault();
        }
        /// <summary>
        /// 获取具有给定给定谓词的实体，如果未找到则获取null
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        public async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {

            return await _dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }
        /// <summary>
        /// 获取具有给定主键的实体，如果未找到则获取null
        /// </summary>
        /// <param name="id">获取的实体的主键</param>
        /// <returns>实体</returns>
        public async Task<TEntity> FirstOrDefaultAsync(int id)
        {
            return await _dbContext.Set<TEntity>().Where(d => d.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);
        }

        /// <summary>
        /// 用于根据给定的谓词获取所有实体
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        public List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().ToList();
        }
        /// <summary>
        /// 用于根据给定的谓词获取所有实体
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        public async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();

        }

        /// <summary>
        /// 用于获取用于从整个表中检索实体的IQueryable一个或多个
        /// </summary>
        /// <param name="propertySelectors">包含表达式的列表</param>
        /// <returns>IQueryable用于从数据库中选择实体</returns>
        public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            if (propertySelectors == null)
            {
                return GetAll(x => true);
            }

            var query = GetAll(x => true);

            foreach (var propertySelector in propertySelectors)
            {
                /**/
                query = query.Include(propertySelector);
            }

            return query;
        }

        /// <summary>
        /// 加载分页实体
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="wherelambda"></param>
        /// <param name="orderByLambda"></param>
        /// <param name="isasc"></param>
        /// <returns></returns>
        public IQueryable<TEntity> LoadPageEntities<s>(int skipCount, int maxResultCount, out int totalCount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, s>> orderByLambda, bool isasc)
        {
            var enyity = _dbContext.Set<TEntity>().AsNoTracking().Where(predicate);
            totalCount = enyity.Count();
            if (isasc)
            {
                enyity = enyity.OrderBy(orderByLambda).Skip<TEntity>(skipCount).Take<TEntity>(maxResultCount);
            }
            else
            {
                enyity = enyity.OrderByDescending(orderByLambda).Skip<TEntity>(skipCount).Take<TEntity>(maxResultCount);
            }
            return enyity;
        }
        #endregion


        #region 更新

        /// <summary>
        /// 更新现有实体
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="updateAction">可用于更改实体值的操作</param>
        /// <returns>更新的实体</returns>
        public void Update(int id, Action<TEntity> updateAction)
        {
            //dbContext.Configuration.AutoDetectChangesEnabled = true;
            var _model = _dbContext.Set<TEntity>().Where(d => d.Id.Equals(id)).AsNoTracking().FirstOrDefault();
            updateAction(_model);
            TEntity entity = Get(id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// 更新现有实体
        /// </summary>
        /// <param name="id">实体的ID</param>
        /// <param name="updateAction">可用于更改实体值的操作</param>
        /// <returns>更新了实体</returns>
        public async Task UpdateAsync(int id, Func<TEntity, Task> updateAction)
        {
            var _model = await _dbContext.Set<TEntity>().Where(d => d.Id.Equals(id)).AsNoTracking().FirstOrDefaultAsync();
            await updateAction(_model);
            TEntity entity = Get(id);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> EditEntityAsync(TEntity entity)
        {
            _dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
            var a = await _dbContext.SaveChangesAsync();
            return a > 0;
        }
        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="updateExpression">更新数据</param>
        /// <returns></returns>
        public bool UpdateEntity(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().UpdateFromQuery<TEntity>(updateExpression);
            return _dbContext.SaveChanges() == 0;
        }
        /// <summary>
        /// 异步批量更新数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="updateExpression">更新数据</param>
        /// <returns></returns>
        public async Task<bool> UpdateEntityAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            await _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().UpdateFromQueryAsync<TEntity>(updateExpression);
            return await _dbContext.SaveChangesAsync() == 0;
        }

        #endregion

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (!_dbContext.Set<TEntity>().Local.Contains(entity))
            {
                _dbContext.Set<TEntity>().Attach(entity);
            }
        }
    }
}
