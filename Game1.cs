using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Threading.Tasks.Sources;

namespace KirbyFloat
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Random RNG = new Random();

        KeyboardState kb;

        Kirby p1;
        TopWall wall1;
        BottomWall wall2;

        SpriteFont UIFont;

        int score;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            score = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // create a new kirby with the two art files loaded and at position (64, 200) and store it in p1
            p1 = new Kirby(Content.Load<Texture2D>("kirby_float"), Content.Load<Texture2D>("kirby_breathe"), 64, 200);
            // create a new topwall with the art file loaded and at position (800, -500) and store it in wall1
            wall1 = new TopWall(Content.Load<Texture2D>("kirby_veg_valley_wall"), 800, -500);
            // create a new bottomwall with the art file loaded and store it in wall2
            wall2 = new BottomWall(Content.Load<Texture2D>("kirby_veg_valley_wall"));
            // Load the "impact" spritefont and store it in UIFont
            UIFont = Content.Load<SpriteFont>("impact");
        }

        protected override void Update(GameTime gameTime)
        {
            kb = Keyboard.GetState();

            // call the Updateme that belongs to p1 giving it the kb variable
            p1.UpdateMe(kb);
            // call the Updateme that belongs to wall1 and add it's return value to the score
            score += wall1.UpdateMe();
            // call the Updateme that belongs to wall2 giving it the X and Y values that belong to the position of wall1
            wall2.UpdateMe(wall1.position.X, wall1.position.Y);

            // if p1's collider intersects with wall1's collider
            if (p1.collider.Intersects(wall1.collider))
            {
                Exit();
            }


            // if p1's collider intersects with wall2's collider
            if (p1.collider.Intersects(wall2.collider))
            {
                Exit();
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Vector2 nowVector = new Vector2(0, 400);
            _spriteBatch.Begin();
            // call the drawme that belongs to p1
            p1.DrawMe(_spriteBatch);
            // call the drawme that belongs to wall1
            wall1.DrawMe(_spriteBatch);
            // call the drawme that belongs to wall2
            wall2.DrawMe(_spriteBatch);
            // draw the score on screen using UIFont in the bottom left corner
            _spriteBatch.DrawString(UIFont, "Score:"+score, nowVector , Color.Red);
            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
