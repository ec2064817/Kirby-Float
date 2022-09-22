using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace KirbyFloat
{
    class Kirby
    {
        public Texture2D art_float;
        public Texture2D art_breath;

        public Vector2 position;
        public Rectangle collider;
        public float fallspeed;

        public Kirby(Texture2D txr_float, Texture2D txr_breath, int xPos, int yPos)
        {
            // Store txr_float in the art_float variable
            art_float = txr_float; 
            // Store txr_breath in the art_breath variable
            art_breath = txr_breath;
            // Make a new vector2 with the xPos and yPos variables and store it in position
            position = new Vector2(xPos, yPos);
            // Make a new collider rectangle with the xPos and yPos and the width and height from txr_float
            collider = new Rectangle(xPos, yPos, txr_float.Width, txr_float.Height);
            // set the fallspeed to zero
            fallspeed = 0;
        }

        public void UpdateMe(KeyboardState kb)
        {
            // Increase the fallspeed by 0.15f
            fallspeed = +1f;

            // if the y part of position is less than zero
            if (position.Y < 0)
            {
                // Set fallspeed to zero
                fallspeed = 0;
                // set the y part of position to zero
                position.Y = 0;
            }

            // if the y part of position is greater than 460
            if (position.Y > 460)
            {
                // set fallspeed to zero
                fallspeed = 0;
                // set the y part of position to 460
                position.Y = 460;
            }

            // if the space bar is held down
            if (kb.IsKeyDown(Keys.Space))
            {
                // set fallspeed to -4
                fallspeed = -3;

            }

            // Add fallspeed to the y part of position
            // THIS COULD BE WRONG HERE LOOK HERE
            position.Y += fallspeed;

            // set the collider's Y to the same as the position's Y
            collider.Y = (int)position.Y;
        }

        public void DrawMe(SpriteBatch sb)
        {
            // if fallspeed is less than zero
            if (fallspeed < 0)
            {
                // draw kirby with the breath art
                sb.Draw(art_breath, position, Color.White);

            }
            else
            {
                // draw kirby with the float art
                sb.Draw(art_float, position, Color.White);
            }
            
        }
    }
}
