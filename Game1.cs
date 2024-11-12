using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace topic_3_monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle Window;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;

        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;

        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;

        Color tribblegreymask;

        Random Random = new Random();

        Color backgroudcolor;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Window = new Rectangle(0, 0, 800, 600);

            tribbleGreySpeed = new Vector2 (0, 2);

            tribbleBrownSpeed = new Vector2(3, 1);

            tribbleCreamSpeed = new Vector2(2, 0);

            tribbleGreyRect = new Rectangle(Random.Next(1, 700),Random.Next(1,500),100, 100);

            tribbleCreamRect = new Rectangle(Random.Next(1, 700), Random.Next(1, 500), 100, 100);

            tribbleBrownRect = new Rectangle(Random.Next(1, 700), Random.Next(1, 500), 100, 100);

            tribblegreymask = Color.White;

            backgroudcolor = Color.Green;


            _graphics.PreferredBackBufferWidth = Window.Width;
            _graphics.PreferredBackBufferHeight = Window.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            if (tribbleGreyRect.Right > Window.Width || tribbleGreyRect.Left < 0)
            {
                tribbleGreySpeed.X *= -1;
                tribblegreymask = Color.Orange;
            }
            if (tribbleGreyRect.Bottom > Window.Height || tribbleGreyRect.Top < 0)
            {
                tribbleGreySpeed.Y *= -1;
                tribbleGreyRect.Y = Random.Next(1,801);
                tribbleGreyRect.X = Random.Next(1, 601);
            }
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            if (tribbleBrownRect.Right > Window.Width || tribbleBrownRect.Left < 0)
            {
                tribbleBrownSpeed.X *= -1;
                backgroudcolor = new Color(Random.Next(1, 256), Random.Next(1, 256), Random.Next(1, 256));
            }

            if (tribbleBrownRect.Bottom > Window.Height || tribbleBrownRect.Top < 0)
            {
                backgroudcolor = new Color(Random.Next(1, 256), Random.Next(1, 256), Random.Next(1, 256));
                tribbleBrownSpeed.Y *= -1;
            }

            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            if (tribbleCreamRect.Left > Window.Width )
            {
                tribbleCreamRect.X = -100;
            }
            if (tribbleCreamRect.Bottom > Window.Height || tribbleCreamRect.Top < 0)
            {
                tribbleCreamSpeed.Y *= -1;
            }
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroudcolor);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
