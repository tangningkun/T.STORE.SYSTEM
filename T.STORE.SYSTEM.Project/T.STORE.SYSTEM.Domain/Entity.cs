using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.Domain
{
    public abstract class Entity<TPrimaryKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        //设置主键为自增
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual TPrimaryKey Id { get; set; }
    }
    public abstract class Entity : Entity<int>
    {

        public Guid? TenantId { get; set; }
        public DateTime? CreateTime { get; set; }
    }
}
