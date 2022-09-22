using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace KirbyFloat
{
    class TopWall
    {
        public Texture2D art;

        public Vector2 position;
        public Rectangle collider;

        public TopWall(Texture2D txr, int xPos, int yPos)
        {
            // store txr in the art variable
            art = txr; 
            // Make a new vector2 with the xPos and yPos variables and store it in position
            position = new Vector2(xPos, yPos);
            // Make a new collider rectangle with the xPos and yPos and the width and height from txr
            collider = new Rectangle(xPos, yPos, txr.Width, txr.Width);
        }

        public int UpdateMe()
        {
            // subtract 3 from the X part of position
            
            position.X -= 3;

            // set the collider's X to the same as the position's X
            collider.X = (int)position.X;
            // set the collider's Y to the same as the position's Y
            collider.Y = (int)position.Y;

            // if the X part of position is less than 0 minus the width of the wall
            if (position.X < 0 - art.Width)
            {
                // set the X part of position to 800
                position.X = 800;

                // set the Y part of position to a random value off the top of the screen
                position.Y = Game1.RNG.Next(300) - 500;
                  
                // return 1
                return 1;
            }
            else
            {
                return 0;
            }

           
        }

        public void DrawMe(SpriteBatch sb)
        {
            sb.Draw(art, position, Color.Red);
        }
    }

    class BottomWall
    {
        public Texture2D art;

        public Vector2 position;
        public Rectangle collider;

        public BottomWall(Texture2D txr)
        {
            // store txr in the art variable
            art = txr;
            // set position to Vector2.Zero
            position = Vector2.Zero;
            // Make a new collider rectangle at 0, 0 for x and y and the width and height from txr
            collider = new Rectangle(0, 0, txr.Width, txr.Width);
        }

        public void UpdateMe(float topWall_X, float topWall_Y)
        {
            // Set the X part of position to topWall_X
            position.X = topWall_X;
            // Set the Y part of position to topWall_Y + the height of the top wall + a gap
            position.Y = topWall_Y + art.Height + 100;

            // set the collider's X to the same as the position's X
            collider.X = (int)position.X;

            // set the collider's Y to the same as the position's Y
            collider.Y = (int)position.Y;
        }

        public void DrawMe(SpriteBatch sb)
        {
            // draw the art at position
            sb.Draw(art, position, Color.Blue);
        }
    }

}
