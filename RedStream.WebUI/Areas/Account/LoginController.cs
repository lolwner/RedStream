﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RedStream.WebUI.Areas.Account
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}