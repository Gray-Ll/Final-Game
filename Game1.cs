﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Final_Game
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        KeyboardState keyboardState;
        MouseState mouseState;

        Song menuMusic;

        //Main Character
        Texture2D beetleup;
        Texture2D beetledown;
        Texture2D beetleleft;
        Texture2D beetleright;
        Texture2D beetleidle;
        Rectangle beetrect;
        Vector2 beetspeed;
        Texture2D beetle;

        //Enemy
        Texture2D mbeetle;
        Texture2D mbeetledown1;
        Texture2D mbeetledown2;
        Rectangle mbeetrect;
        Vector2 mbeetspeed;

        //Environment
        Texture2D dirt;
        Rectangle dirtrect;
        Texture2D shale;
        Rectangle shalerect;

        //Button
        Rectangle Play;
        Rectangle Tutorial;
        Rectangle Settings;
        Rectangle Controls;

        //Background
        Texture2D cavernback;


        enum Screen
        {
            Menu,
            Start,
            L1,
            L2,
        }
        Screen screen;

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
            mbeetrect = new Rectangle(100, 20, 10, 35);
            mbeetspeed = new Vector2();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            menuMusic = Content.Load<Song>("menuMusic");

            cavernback = Content.Load<Texture2D>("cavern");

            shale = Content.Load<Texture2D>("Shale");
            dirt = Content.Load<Texture2D>("dirt");

            beetledown = Content.Load<Texture2D>("beetledown");
            beetleup = Content.Load<Texture2D>("beetleup");
            beetleleft = Content.Load<Texture2D>("beetleleft");
            beetleright = Content.Load<Texture2D>("beetleright");
            beetleidle = Content.Load<Texture2D>("beetleright");
            beetle = beetleidle;

            mbeetle = Content.Load<Texture2D>("mbeetledown1");
            mbeetledown1 = Content.Load<Texture2D>("mbeetledown1");
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

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

            if (screen == Screen.Menu)
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Play(menuMusic);
                }
                mbeetrect.Width = 50;
                mbeetrect.Height = 52;
                mbeetle = mbeetledown1;

                if (mbeetrect.Bottom >= 200)
                {
                    mbeetspeed = new Vector2(7, 0);
                }
            }

            beetrect.X += (int)beetspeed.X;
            beetrect.Y += (int)beetspeed.Y;

            mbeetrect.X += (int)mbeetspeed.X;
            mbeetrect.Y += (int)mbeetspeed.Y;

            // If pacman is not moving make him sleep
            if (!keyboardState.IsKeyDown(Keys.Up) && !keyboardState.IsKeyDown(Keys.Right) && !keyboardState.IsKeyDown(Keys.Left) && !keyboardState.IsKeyDown(Keys.Down))
            {
                
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Menu)
            {
                _spriteBatch.Draw(cavernback, new Rectangle(0, 0, 800, 500), Color.White);

                _spriteBatch.Draw(shale, new Rectangle(200, 100, 400, 50), Color.White);
                _spriteBatch.Draw(shale, new Rectangle(200, 400, 400, 50), Color.White);
                _spriteBatch.Draw(beetle, beetrect, Color.White);
                _spriteBatch.Draw(mbeetledown1, mbeetrect, Color.White);
            }
            else if (screen == Screen.Start)
            {
                _spriteBatch.Draw(cavernback, new Rectangle(0, 0, 800, 500), Color.White);

                _spriteBatch.Draw(beetle, beetrect, Color.White);
            }
            else if (screen == Screen.L1)
            {
                
            }
            else if (screen == Screen.L2)
            {
                
            }


            _spriteBatch.Draw(beetle, beetrect, Color.White);


            _spriteBatch.Draw(beetle, beetrect, Color.White);


            _spriteBatch.Draw(beetle, beetrect, Color.White);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}