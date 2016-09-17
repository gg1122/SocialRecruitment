using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace Langben.App.Controllers
{
    public class DefaultController : BaseController
    {
        public ActionResult Index(string id)
        {

            return View();
        }
    }
}

