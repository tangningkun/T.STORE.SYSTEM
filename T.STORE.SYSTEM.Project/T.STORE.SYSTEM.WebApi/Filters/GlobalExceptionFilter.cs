using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T.STORE.SYSTEM.WebApi.CommonUtils;

namespace T.STORE.SYSTEM.WebApi.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;
            string errorMessage = "后台接口异常！！！";
            NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.ApiRequest, errorMessage, new Exception(errorMessage, ex));
            NLogUtil.WriteDBLog(NLog.LogLevel.Error, LogType.ApiRequest, errorMessage, new Exception(errorMessage, ex));
        }
    }
}
