using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using T.STORE.SYSTEM.Domain;

namespace T.STORE.SYSTEM.Repository.EntityFramework
{
    public interface IStoreSystemRepository<TEntity> where TEntity : Entity
    {
        #region 其他
        /// <summary>
        /// 获取此存储库中所有实体的计数
        /// </summary>
        /// <returns>实体数量</returns>
        int Count();
        /// <summary>
        /// 根据给定的条件获取此存储库中所有实体的计数
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体数量</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 根据给定的条件获取此存储库中所有实体的计数
        /// </summary>
        /// <param name="predicate">过滤计数的方法</param>
        /// <returns>实体数量</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取此存储库中所有实体的计数
        /// </summary>
        /// <returns>实体数量</returns>
        Task<int> CountAsync();
        #endregion

        #region 删除
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">要删除的实体</param>
        bool DeleteEntity(TEntity entity);

        #endregion

        #region 插入
        TEntity InsertEntity(TEntity entity);
        Task<TEntity> InsertEntityAsync(TEntity entity);
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        Task InsertEntitiesAsync(List<TEntity> entities);
        #endregion

        #region 获取

        /// <summary>
        /// 获取具有给定主键的实体
        /// </summary>
        /// <param name="id">获取的实体的主键</param>
        /// <returns>实体</returns>
        TEntity Get(int id);

        /// <summary>
        /// 获取具有给定主键的实体
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>实体</returns>
        Task<TEntity> GetAsync(int id);
        /// <summary>
        /// 获取具有给定谓词的一个实体。 如果没有实体或者引发异常
        /// 多个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体</returns>
        TEntity Single(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取具有给定谓词的一个实体。 如果没有实体或者引发异常
        /// 多个实体
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <returns>实体</returns>
        Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取具有给定给定谓词的实体，如果未找到则获取null
        /// </summary>
        /// <param name="predicate">谓词来过滤实体</param>
        /// <returns>实体或null</returns>
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取具有给定主键的实体，如果未找到则获取null
        /// </summary>
        /// <param name="id">要获取的实体的主键</param>
        /// <returns>实体或null/returns>
        TEntity FirstOrDefault(int id);
        /// <summary>
        /// 获取具有给定给定谓词的实体，如果未找到则获取null
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 获取具有给定主键的实体，如果未找到则获取null
        /// </summary>
        /// <param name="id">获取的实体的主键</param>
        /// <returns>实体</returns>
        Task<TEntity> FirstOrDefaultAsync(int id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 用于根据给定的谓词获取所有实体
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        /// <summary>
        /// 用于根据给定的谓词获取所有实体
        /// </summary>
        /// <param name="predicate">过滤实体的条件</param>
        /// <returns>实体</returns>
        Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 用于获取用于从整个表中检索实体的IQueryable一个或多个
        /// </summary>
        /// <param name="propertySelectors">包含表达式的列表</param>
        /// <returns>IQueryable用于从数据库中选择实体</returns>
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors);

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
        IQueryable<TEntity> LoadPageEntities<s>(int skipCount, int maxResultCount, out int totalCount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, s>> orderByLambda, bool isasc);
        #endregion


        #region 更新


        Task<bool> EditEntityAsync(TEntity entity);


        /// <summary>
        /// 批量更新数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="updateExpression">更新数据</param>
        /// <returns></returns>
        bool EditEntity(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression);
        /// <summary>
        /// 异步批量更新数据
        /// </summary>
        /// <param name="predicate">查询条件</param>
        /// <param name="updateExpression">更新数据</param>
        /// <returns></returns>
        Task<bool> EditEntityAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TEntity>> updateExpression);

        #endregion
    }
}
