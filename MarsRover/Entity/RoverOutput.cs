using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarsRover.Entity
{
    public class RoverOutput
    {
        public CoordinateEntity Coordinate { get; set; }
        public string LastDestination { get; set; }
    }
}