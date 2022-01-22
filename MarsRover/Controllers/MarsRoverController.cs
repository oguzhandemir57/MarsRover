using MarsRover.Entity;
using MarsRover.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarsRover.Controllers
{
    public class MarsRoverController : ApiController
    {
        [HttpGet]
        public List<RoverOutput> Route()
        {
            var result = new MarsRoverOperator().RouteOperator();

            return result;
        }
        
    }
}