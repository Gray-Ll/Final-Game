using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;

        Texture2D beetleup;
        Texture2D beetledown;
        Texture2D beetleleft;
        Texture2D beetleright;
        Texture2D beetleidle;
        Texture2D beetle;
        Texture2D cavernback;

        Rectangle beetrect;
        Vector2 beetspeed;

        enum Screen
        {
            Menu,
            Start,
            L1,
            L2,
        }
        Screen screen;
        MouseState mouseState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.ApplyChanges();

            screen = Screen.Menu;

            beetrect = new Rectangle(10, 10, 50, 50);
            beetspeed = new Vector2();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cavernback = Content.Load<Texture2D>("cavern");

            beetledown = Content.Load<Texture2D>("beetledown");
            beetleup = Content.Load<Texture2D>("beetleup");
            beetleleft = Content.Load<Texture2D>("beetleleft");
            beetleright = Content.Load<Texture2D>("beetleright");
            beetleidle = Content.Load<Texture2D>("beetleright");
            beetle = beetleidle;
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            beetspeed.X = 0;
            beetspeed.Y = 0;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                beetrect.Height = 58;
                beetrect.Width = 50;
                beetle = beetleup;
                beetspeed.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                beetrect.Height = 58;
                beetrect.Width = 50;
                beetle = beetledown;
                beetspeed.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                beetrect.Width = 58;
                beetrect.Height = 50;
                beetle = beetleleft;
                beetspeed.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                beetrect.Width = 58;
                beetrect.Height = 50;
                beetle = beetleright;
                beetspeed.X += 2;
            }

            beetrect.X += (int)beetspeed.X;
            beetrect.Y += (int)beetspeed.Y;

            // If pacman is not moving make him sleep
            if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Right) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Down))
            {
                
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(cavernback, new Rectangle(0, 0, 800, 500), Color.White);

            _spriteBatch.Draw(beetle, beetrect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}