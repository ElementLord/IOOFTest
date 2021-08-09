using System;

namespace IOOFTest
{
    class Robot_Movement
    {
        public enum Direction { NORTH = 0, EAST = 1, SOUTH = 2, WEST = 3 };

        public static int botCurrentX = 0;
        public static int botCurrentY = 0;
        public static Direction botCurrentFacing = Direction.NORTH;
        public static bool placedOnTable = false;

        /* Places the robot on the table at the specified X,Y and Facing */
        public static void Place(string[] position)
        {
            try
            {
                int xPosition = int.Parse(position[1]);
                int yPosition = int.Parse(position[2]);
                string facing = position[3];

                /* Checks if the variables given are valid */
                if (xPosition >= 0 && xPosition <= 4 &&
                    yPosition >= 0 && yPosition <= 4 &&
                    (facing.Equals("NORTH") || facing.Equals("EAST") || facing.Equals("SOUTH") || facing.Equals("WEST")))
                {
                    botCurrentX = xPosition;
                    botCurrentY = yPosition;

                    switch (facing)
                    {
                        case "NORTH":
                            botCurrentFacing = Direction.NORTH;
                            break;
                        case "EAST":
                            botCurrentFacing = Direction.EAST;
                            break;
                        case "SOUTH":
                            botCurrentFacing = Direction.SOUTH;
                            break;
                        case "WEST":
                            botCurrentFacing = Direction.WEST;
                            break;
                    }

                    placedOnTable = true;
                }
                else
                {
                    //Console.WriteLine("--INVALID INPUT VARIABLES: ROBOT WAS NOT PLACED"); //Error Message
                }
            }
            catch
            {
                //Console.WriteLine("--MISSING INPUT VARIABLES: ROBOT WAS NOT PLACED"); //Error Message
            }
        }

        /* Moves robot one space forward in it's current facing */
        public static void Move()
        {
            switch (botCurrentFacing)
            {
                case Direction.NORTH:
                    if (botCurrentY != 4) { botCurrentY++; } 
                    break;
                case Direction.EAST:
                    if (botCurrentX != 4) { botCurrentX++; }
                    break;
                case Direction.SOUTH:
                    if (botCurrentY != 0) { botCurrentY--; }
                    break;
                case Direction.WEST:
                    if (botCurrentX != 0) { botCurrentX--; }
                    break;
            }
        }
        
        /* Turns the robot 90 degrees to the Left of the current Facing */
        public static void Left() 
        {
            switch (botCurrentFacing)
            {
                case Direction.NORTH:
                    botCurrentFacing = Direction.WEST;
                    break;
                case Direction.EAST:
                    botCurrentFacing = Direction.NORTH;
                    break;
                case Direction.SOUTH:
                    botCurrentFacing = Direction.EAST;
                    break;
                case Direction.WEST:
                    botCurrentFacing = Direction.SOUTH;
                    break;
            }
            
        }

        /* Turns the robot 90 degrees to the Right of the current Facing */
        public static void Right() 
        {
            switch (botCurrentFacing)
            {
                case Direction.NORTH:
                    botCurrentFacing = Direction.EAST;
                    break;
                case Direction.EAST:
                    botCurrentFacing = Direction.SOUTH;
                    break;
                case Direction.SOUTH:
                    botCurrentFacing = Direction.WEST;
                    break;
                case Direction.WEST:
                    botCurrentFacing = Direction.NORTH;
                    break;
            }
        }
        
        static void Main()
        {
            char[] spearators = { ' ', ',' };
            string[] command = Console.ReadLine().Split(spearators);

            while (!command[0].Equals("REPORT")) //Leaves loop if REPORT command is given
            {
                if (placedOnTable || command[0].Equals("PLACE")) //Only accepts PLACE command untill the first PLACE command has been used
                {
                    switch (command[0])
                    {
                        case "PLACE":
                            Place(command);
                            break;
                        case "MOVE":
                            Move();
                            break;
                        case "LEFT":
                            Left(); 
                            break;
                        case "RIGHT":
                            Right(); 
                            break;
                        default:
                            //Console.WriteLine("--COMMAND NOT VALID"); //Error Message
                            break;
                    }
                }
                else
                {
                    //Console.WriteLine("--COMMAND NOT VALID: ROBOT NEEDS TO BE PLACED FIRST"); //Error Message
                }

                command = Console.ReadLine().Split(spearators);
            }

            if (placedOnTable == true) //If robot was not placed on the table, displays a different message
            {
                Console.WriteLine("Output: " + botCurrentX + "," + botCurrentY + "," + botCurrentFacing.ToString());
            }
            else
            {
                Console.WriteLine("Output: ROBOT NOT PLACED");
            } 
        }
    }
}
