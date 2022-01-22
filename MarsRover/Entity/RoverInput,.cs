using MarsRover.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MarsRover.Utilities.Consts;

namespace MarsRover.Entity
{
    public class RoverInput : ResponseBaseEntity
    {
        public CoordinateEntity Coordinate { get; set; }
        public CoordinateEntity Location { get; set; }
        public MoveConst MoveConstsValue { get; set; }
        public string Destination { get; set; }
    }
}