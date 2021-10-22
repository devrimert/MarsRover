using System;
using Xunit;
using MarsRover.Objects;
using MarsRover.Enums;
using System.Collections.Generic;

namespace MarsRoverxUnitTest
{
    public class MarsRoverTest
    {
        [Fact]
        public void RoverMoveTest()
        {
            var maxRange = new MaxRange{X = 10, Y = 10};
            List<Rover> rovers = new List<Rover>();

            //Rover1
            Position position1 = new Position { X = 0, Y = 0, Route = RouteEnums.Route.N };
            MoveEnums.MovePath[] movePath1 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.R, MoveEnums.MovePath.M };
            Move move1 = new Move { MovePaths = movePath1 };
            Rover rover1 = new Rover { ID = 1, Position = position1, MovePath = move1, MoveResult = "" };
            rovers.Add(rover1);

            //Plateau
            var plateau = new Plateau { MaxRange = maxRange, Rovers = rovers };

            //Process
            plateau.Rovers[0].Move(plateau);

            //Result
            Assert.Equal(1, plateau.Rovers[0].Position.X);
            Assert.Equal(4, plateau.Rovers[0].Position.Y);
            Assert.Equal(RouteEnums.Route.E, plateau.Rovers[0].Position.Route);
        }
        [Fact]
        public void RoverBlockTest()
        {
            var maxRange = new MaxRange { X = 15, Y = 8 };
            List<Rover> rovers = new List<Rover>();

            //Rover1
            Position position1 = new Position { X = 0, Y = 0, Route = RouteEnums.Route.N };
            MoveEnums.MovePath[] movePath1 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.R, MoveEnums.MovePath.M };
            Move move1 = new Move { MovePaths = movePath1 };
            Rover rover1 = new Rover { ID = 1, Position = position1, MovePath = move1, MoveResult = "" };
            rovers.Add(rover1);
            //Rover2
            Position position2 = new Position { X = 2, Y = 3, Route = RouteEnums.Route.E };
            MoveEnums.MovePath[] movePath2 = { MoveEnums.MovePath.R, MoveEnums.MovePath.R, MoveEnums.MovePath.M, MoveEnums.MovePath.R, MoveEnums.MovePath.M, MoveEnums.MovePath.M };
            Move move2 = new Move { MovePaths = movePath2 };
            Rover rover2 = new Rover { ID = 2, Position = position2, MovePath = move2, MoveResult = "" };
            rovers.Add(rover2);
            //Rover3
            Position position3 = new Position { X = 5, Y = 5, Route = RouteEnums.Route.W };
            MoveEnums.MovePath[] movePath3 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.L, MoveEnums.MovePath.M };
            Move move3 = new Move { MovePaths = movePath3 };
            Rover rover3 = new Rover { ID = 3, Position = position3, MovePath = move3, MoveResult = "" };
            rovers.Add(rover3);
            //Plateau
            var plateau = new Plateau { MaxRange = maxRange, Rovers = rovers };

            //Process
            foreach (Rover rover in plateau.Rovers)
                rover.Move(plateau);

            //Result
            Assert.Equal(1, plateau.Rovers[0].Position.X);
            Assert.Equal(4, plateau.Rovers[0].Position.Y);
            Assert.Equal(RouteEnums.Route.E, plateau.Rovers[0].Position.Route);

            Assert.Equal(1, plateau.Rovers[1].Position.X);
            Assert.Equal(3, plateau.Rovers[1].Position.Y);
            Assert.Equal(RouteEnums.Route.N, plateau.Rovers[1].Position.Route);

            Assert.Equal(1, plateau.Rovers[2].Position.X);
            Assert.Equal(5, plateau.Rovers[2].Position.Y);
            Assert.Equal(RouteEnums.Route.S, plateau.Rovers[2].Position.Route);
        }

        [Fact]

        public void RoverReachedMaxTest()
        {
            var maxRange = new MaxRange { X = 20, Y = 20 };
            List<Rover> rovers = new List<Rover>();

            //Rover1
            Position position1 = new Position { X = 19, Y = 10, Route = RouteEnums.Route.E };
            MoveEnums.MovePath[] movePath1 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.R, MoveEnums.MovePath.M };
            Move move1 = new Move { MovePaths = movePath1 };
            Rover rover1 = new Rover { ID = 1, Position = position1, MovePath = move1, MoveResult = "" };
            rovers.Add(rover1);
            //Rover2
            Position position2 = new Position { X = 12, Y = 17, Route = RouteEnums.Route.N };
            MoveEnums.MovePath[] movePath2 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.L };
            Move move2 = new Move { MovePaths = movePath2 };
            Rover rover2 = new Rover { ID = 2, Position = position2, MovePath = move2, MoveResult = "" };
            rovers.Add(rover2);
            //Rover3
            Position position3 = new Position { X = 5, Y = 2, Route = RouteEnums.Route.S };
            MoveEnums.MovePath[] movePath3 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.L, MoveEnums.MovePath.M };
            Move move3 = new Move { MovePaths = movePath3 };
            Rover rover3 = new Rover { ID = 3, Position = position3, MovePath = move3, MoveResult = "" };
            rovers.Add(rover3);
            //Rover4
            Position position4 = new Position { X = 1, Y = 17, Route = RouteEnums.Route.W };
            MoveEnums.MovePath[] movePath4 = { MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.M, MoveEnums.MovePath.L, MoveEnums.MovePath.M };
            Move move4 = new Move { MovePaths = movePath4 };
            Rover rover4 = new Rover { ID = 4, Position = position4, MovePath = move4, MoveResult = "" };
            rovers.Add(rover4);
            //Plateau
            var plateau = new Plateau { MaxRange = maxRange, Rovers = rovers };

            //Process
            foreach (Rover rover in plateau.Rovers)
                rover.Move(plateau);

            //Result
            Assert.Equal(20, plateau.Rovers[0].Position.X);
            Assert.Equal(10, plateau.Rovers[0].Position.Y);
            Assert.Equal(RouteEnums.Route.E, plateau.Rovers[0].Position.Route);

            Assert.Equal(12, plateau.Rovers[1].Position.X);
            Assert.Equal(20, plateau.Rovers[1].Position.Y);
            Assert.Equal(RouteEnums.Route.N, plateau.Rovers[1].Position.Route);

            Assert.Equal(5, plateau.Rovers[2].Position.X);
            Assert.Equal(0, plateau.Rovers[2].Position.Y);
            Assert.Equal(RouteEnums.Route.S, plateau.Rovers[2].Position.Route);

            Assert.Equal(0, plateau.Rovers[3].Position.X);
            Assert.Equal(17, plateau.Rovers[3].Position.Y);
            Assert.Equal(RouteEnums.Route.W, plateau.Rovers[3].Position.Route);
        }
    }
}
