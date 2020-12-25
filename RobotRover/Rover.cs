using System;
using System.Collections.Generic;
using System.Text;

namespace WhenMovingRover
{
    public class Rover : IRover
    {
        public int x { get; set; }
        public int y { get; set; }
        public string direction { get; set; }
        public List<IRover> Squadron { get; set; }
       
        private void Location(string location)
        {
            string[] locationSplit = location.Split(' ');
            x = Convert.ToInt32(locationSplit[0]);
            y = Convert.ToInt32(locationSplit[1]);
            direction = locationSplit[2];
        }

        public Rover(List<IRover> squad, IGrid grid, string roverPosition, string roverCommands)
        {
            this.Squadron = squad;

            Location(roverPosition);

            if (!CheckLandingSurfaceCoordinates(grid))
                return;

            this.Move(roverCommands);
        }       

        private bool CheckLandingSurfaceCoordinates(IGrid gird)
        {
            return (this.x >= 0) && (this.x < gird.Width) &&
                (this.y >= 0) && (this.y < gird.Height);
        }

        /// <summary>
        /// rotate left direction rover is facing
        /// </summary>
        public void SpinLeft()
        {
            switch (direction)
            {
                case "N":
                    direction = "W";
                    break;
                case "E":
                    direction = "N";
                    break;
                case "S":
                    direction = "E";
                    break;
                case "W":
                    direction = "S";
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// rotate right direction rover is facing
        /// </summary>
        public void SpinRight()
        {
            switch (direction)
            {
                case "N":
                    direction = "E";
                    break;
                case "E":
                    direction = "S";
                    break;
                case "S":
                    direction = "W";
                    break;
                case "W":
                    direction = "N";
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        /// <summary>
        /// Interprets the rover command and move to command sequences
        /// </summary>
        public void Move(string rovercommand)
        {
            try
            {
                char[] instructions = rovercommand.ToCharArray();

                for (int i = 0; i < instructions.Length; i++)
                {
                    switch (instructions[i])
                    {
                        case 'L':
                            SpinLeft();
                            break;
                        case 'R':
                            SpinRight();
                            break;
                        default:
                            StepForward(int.Parse(instructions[i].ToString()));
                            break;
                    }
                }
            }

            catch (FormatException ex)
            {
                throw new Exception("Impermissible Command");
            }
        }

        /// <summary>
        /// step forward to set rovers x and y co ordinate positions
        /// </summary>
        /// <param name="pos"></param>
        public void StepForward(int pos)
        { 
             switch (direction)
            {
                case "N":
                    y += pos;
                    break;
                case "E":
                    x += pos;
                    break;
                case "S":
                    y -= pos;
                    break;
                case "W":
                    x -= pos;
                    break;
                default:
                    throw new ArgumentException();

            }

        }
    }


    }

