﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuzelSozler.Areas.Admin.Controllers
{
    public class DashboardController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
