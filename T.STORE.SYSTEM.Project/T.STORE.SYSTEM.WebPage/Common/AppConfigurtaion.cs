﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace T.STORE.SYSTEM.WebPage.Common
{
    public class AppConfigurtaion
    {
        private readonly IConfiguration _configuration;
        public AppConfigurtaion(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string AppConfigurtaionValue(string name)
        {
            return _configuration["Appsettings:" + name.Trim()].ToString();
        }
    }
}
