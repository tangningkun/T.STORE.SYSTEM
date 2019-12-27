﻿
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.WebApiCompatShim;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using T.STORE.SYSTEM.Application.Users;
using T.STORE.SYSTEM.WebApi.Model;

namespace T.STORE.SYSTEM.WebApi.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAppService _userAppservice;
        public AccountController(IUserAppService userAppservice)
        {
            _userAppservice = userAppservice;
        }
        [HttpPost]
        public async Task<IActionResult> getAllUser()
        {
            var model = new MessageModel();
            try
            {
                model.data =await _userAppservice.GetAll(x => true);
            }
            catch (Exception e)
            {
                model.status = EnResultStatus.失败;
                model.msg = e.Message;
            }
            var responseMessage = HttpContext.GetHttpRequestMessage().CreateResponse(HttpStatusCode.OK, model);
            return new ResponseMessageResult(responseMessage);
        }
    }
}