﻿using BlogNet.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogNet.Areas.Admin.Controllers
{
    public class DashBoardController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
