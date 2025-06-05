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

        Texture2D beetle;
        Rectangle beetlerect;
        Vector2 beetlespeed;

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

            beetlerect = new Rectangle(10, 10, 75, 75);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            beetle = Content.Load<Texture2D>("beetleright");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            keyboardState = Keyboard.GetState();

            beetlespeed = new Vector2();

            beetlerect.Offset(beetlespeed);

            beetlespeed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                beetlespeed.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                beetlespeed.Y += 2;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                beetlespeed.X += 2;
            }

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                beetlespeed.X += 2;
            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            base.Draw(gameTime);
        }
    }
}
