using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T.STORE.SYSTEM.WebApi.CommonUtils;

namespace T.STORE.SYSTEM.WebApi.Filters
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var statusCode = context.Response.StatusCode;
                //如果异常为提供给方法的参数无效错误
                if (ex is ArgumentException)
                {
                    statusCode = 200;
                }
                var errorMessage = $"接口状态码为{context.Response.StatusCode}";
                NLogUtil.WriteFileLog(NLog.LogLevel.Error, LogType.ApiRequest, errorMessage, new Exception(errorMessage, ex));
                NLogUtil.WriteDBLog(NLog.LogLevel.Error, LogType.ApiRequest, errorMessage, new Exception(errorMessage, ex));
                await HandleExceptionAsync(context, statusCode, ex.Message);
            }
            finally
            {
                var statusCode = context.Response.StatusCode;
                var message = "";
                if (statusCode == 401)
                {
                    message = "未授权";
                }
                else if (statusCode == 404)
                {
                    message = "未找到服务";
                }
                else if (statusCode == 502)
                {
                    message = "请求错误";
                }
                else if (statusCode != 200)
                {
                    message = "未知错误";
                }
                if (!string.IsNullOrWhiteSpace(message))
                {
                    await HandleExceptionAsync(context, statusCode, message);
                }
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, int statusCode, string message)
        {
            var data = new { code = statusCode.ToString(), is_success = false, message = message };
            var result = JsonConvert.SerializeObject(new { data = data });
            context.Response.ContentType = "application/json;charset=utf-8";
            return context.Response.WriteAsync(result);
        }
    }
    public static class ErrorHandlingExtensions
    {
        /// <summary>
        /// 加入中间管道
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
