using MarsRover.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static MarsRover.Utilities.Consts;

namespace MarsRover.Operators
{
    public class MarsRoverOperator
    {
        CoordinateEntity coordinate = new CoordinateEntity { XValue = 5, YValue = 5 };

        public List<RoverOutput> RouteOperator()
        {
            List<RoverInput> roverList = new List<RoverInput>();
            RoverOutput output = new RoverOutput();
            List<RoverOutput> outputList = new List<RoverOutput>();
            
        
            var input = FillInput(InputType.First);
            
            var processFirstResult = RouteProcess(input);

            output.Coordinate = processFirstResult.Location;
            output.LastDestination = processFirstResult.MoveConstsValue.ToString();

            outputList.Add(output);

            input = FillInput(InputType.Second);

            var processSecondResult = RouteProcess(input);

            output = new RoverOutput();
            output.Coordinate = processSecondResult.Location;
            output.LastDestination = processSecondResult.MoveConstsValue.ToString();

            outputList.Add(output);

            return outputList;
        }


        public RoverInput RouteProcess(RoverInput roverReq)
        {
            foreach (var item in roverReq.Destination)
            {
                switch (item)
                {
                    case ('L'):
                        roverReq.MoveConstsValue = (roverReq.MoveConstsValue - 1) < MoveConst.N ? MoveConst.W : roverReq.MoveConstsValue - 1;
                        break;
                    case ('R'):
                        roverReq.MoveConstsValue = (roverReq.MoveConstsValue + 1) > MoveConst.W ? MoveConst.N : roverReq.MoveConstsValue + 1;
                        break;
                    case ('M'):
                        roverReq = Move(roverReq);
                        break;
                    default:
                        return roverReq = new RoverInput { ErrorMessage = "Hata oluştu..." };
                }
            }

            return roverReq;
        }

        private RoverInput Move(RoverInput moveReq)
        {
            if (moveReq.MoveConstsValue == MoveConst.N)
            {
                moveReq.Location.YValue++;
            }
            else if (moveReq.MoveConstsValue == MoveConst.E)
            {
                moveReq.Location.XValue++;
            }
            else if (moveReq.MoveConstsValue == MoveConst.S)
            {
                moveReq.Location.YValue--;
            }
            else if (moveReq.MoveConstsValue == MoveConst.W)
            {
                moveReq.Location.XValue--;
            }

            return moveReq;
        }

        private RoverInput FillInput(InputType inputType)
        {
            RoverInput input = new RoverInput();
            if (InputType.First == inputType)
            {
                input = new RoverInput
                {
                    Coordinate = coordinate,
                    Location = new CoordinateEntity { XValue = 1, YValue = 2 },
                    MoveConstsValue = MoveConst.N,
                    Destination = "LMLMLMLMM"
                };
            }
            else
            {

                input = new RoverInput
                {
                    Coordinate = coordinate,
                    Location = new CoordinateEntity { XValue = 3, YValue = 3 },
                    MoveConstsValue = MoveConst.E,
                    Destination = "MMRMMRMRRM"
                };
            }

            return input;
        }

    }
}