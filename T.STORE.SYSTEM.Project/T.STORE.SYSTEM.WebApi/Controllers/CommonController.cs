using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using T.STORE.SYSTEM.Application.Users;
using T.STORE.SYSTEM.Application.Users.dto;
using T.STORE.SYSTEM.WebApi.Model;

namespace T.STORE.SYSTEM.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly IUserAppService _userAppService;
        public CommonController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromUri]LoginUserDto dto)
        {
            var result = new MessageModel();
            try
            {
                result.data = await _userAppService.CheckLoginUser(dto);
            }
            catch (Exception e)
            {
                result.status = EnResultStatus.失败;
                result.msg = e.Message;
                return new ResponseMessageResult(HttpContext.GetHttpRequestMessage().CreateResponse(HttpStatusCode.InternalServerError, result));
            }
            return new ResponseMessageResult(HttpContext.GetHttpRequestMessage().CreateResponse(HttpStatusCode.OK, result));
        }
    }
}