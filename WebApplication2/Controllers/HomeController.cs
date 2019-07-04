using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger logger;
        private readonly IClient client;

        public HomeController(ILogger logger, IClient client)
        {
            this.logger = logger;
            this.client = client;
        }

        public IActionResult Index()
        {
            this.client.DoWork();
            this.logger.Log("from HomeController");
            return View();
        }
    }
}
