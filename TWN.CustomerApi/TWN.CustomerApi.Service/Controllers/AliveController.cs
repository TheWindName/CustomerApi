using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TWN.CustomerApi.Service.Controllers
{
    /// <summary>
    /// Class Alive which provide us a way to verify the application healthy. 
    /// </summary>
    [ApiVersionNeutral]
    [ApiController]
    [Route("/")]
    [Route("alive")]
    public class AliveController : ControllerBase
    {
        /// <summary>
        /// Get Method which returns api status code 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public OkResult Get()
        {
            return base.Ok();
        }
    }
}
