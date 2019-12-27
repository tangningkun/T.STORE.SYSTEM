using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.WebApi.Model
{
    public class MessageModel
    {
        /// <summary>
        /// 0：失败，1：成功 其他
        /// </summary>
        public EnResultStatus status { get; set; }

        /// <summary>
        /// 错误信息
        /// </summary>
        public object msg { get; set; }

        /// <summary>
        /// 对象信息
        /// </summary>
        public object data { get; set; }
    }

    /// <summary>
    /// 枚举类型
    /// </summary>
    public enum EnResultStatus
    {
        成功 = 0,
        失败 = 1,
        无效key = -1,
        无效时间 = -2
    }
}
