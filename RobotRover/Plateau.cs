using System;
using System.Collections.Generic;
using System.Text;

namespace WhenMovingRover
{
    public class Plateau : IGrid
    {
        /// <summary>
        /// Set the Grid size 
        /// max size of the grid can be set to 40 X 30. the grid size is fixed to xcorordinate = 40 and ycoordinate = 30
        /// 
        /// </summary>
        /// <param name="xMaxCoordinate"></param>
        /// <param name="yMaxCoordinate"></param>
        public Plateau(int xMaxCoordinate, int yMaxCoordinate)
        {
            if (CheckMaxLandingSurfaceCoordinates(xMaxCoordinate, yMaxCoordinate))
            {
                return;
            }
            this.Width = xMaxCoordinate;
            this.Height = yMaxCoordinate;           
        }

        public bool CheckMaxLandingSurfaceCoordinates(int xMaxCoordinate, int yMaxCoordinate)
        {
            return (xMaxCoordinate > 40) || (yMaxCoordinate > 30);
        }

        public Plateau(string plateauCoordinates)
        {
            if (string.IsNullOrEmpty(plateauCoordinates))
                throw new ArgumentException();

            this.GetCoordinates(plateauCoordinates);
        }

      

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }

        /// <summary>
        /// max width and height of the plateau for the rover to move
        /// </summary>
        /// <param name="plateauCoordinates"></param>
        private void GetCoordinates(string plateauCoordinates)
        {
            string[] coordinate = plateauCoordinates.Split(' ');          

            this.Width = Convert.ToInt32(coordinate[0]);
            this.Height = Convert.ToInt32(coordinate[1]);
        }
    }
}
