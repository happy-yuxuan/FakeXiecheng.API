using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace FakeXiecheng.API.Controllers
{
    [Route("api/shoudongapi")]
    //[Controller]
    //public class ShoudongAPIController
    public class ShoudongAPIController: Controller
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
