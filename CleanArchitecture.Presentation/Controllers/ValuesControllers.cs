using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ValuesControllers : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new string[] { "value1", "value2", "value1", "value2", "value1", "value2", "value1", "value2", "value1", "value2" });

        }
    }
}
