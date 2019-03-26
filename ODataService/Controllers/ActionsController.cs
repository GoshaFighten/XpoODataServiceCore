using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;

namespace ODataService.Controllers
{
    public class ActionsController : ODataController
    {
        [ODataRoute("InitializeDatabase")]
        public IActionResult InitializeDatabase()
        {
            return Ok();
        }

        [HttpGet]
        [ODataRoute("TotalSalesByYear(year={year})")]
        public IActionResult TotalSalesByYear(int year)
        {
            return Ok();
        }
    }
}
