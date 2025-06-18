using System.Collections.Generic;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        MouseState prevMouseState;

        Song menuMusic;
        Song gameAmb;
        SoundEffect hit;

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
        Rectangle mbeetrect2;
        Vector2 mbeetspeed;
        Vector2 mbeetspeed2;
        List<Rectangle> mbeetles = new List<Rectangle>();

        //Environment
        Texture2D dirt;
        Rectangle dirtrect;
        Texture2D shale;
        Texture2D tpRock;
        Rectangle tpRockr;
        List<Rectangle> shalerects = new List<Rectangle>();

        //Button
        Rectangle Playrect;
        Texture2D Play;
        Rectangle Tutorialrect;
        Texture2D Tutorial;
        Rectangle Optionsrect;
        Texture2D Options;
        Rectangle Controlsrect;
        Texture2D Controls;

        Rectangle tutControls;

        //Background
        Texture2D cavernback;
        Texture2D tutmap;
        Rectangle tutTunnel;
        Rectangle rect1;


        enum Screen
        {
            Menu,
            Death,
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

            dirtrect = new Rectangle(325, 60, 1, 1);
            tpRockr = new Rectangle(760, 450, 40, 40);

            screen = Screen.Menu;

            beetrect = new Rectangle(100, 250, 50, 50);
            beetspeed = new Vector2();

            mbeetrect = new Rectangle(600, -50, 10, 35);
            mbeetrect2 = new Rectangle(300, -150, 10, 35);
            mbeetspeed = new Vector2();
            mbeetspeed2 = new Vector2();

            Playrect = new Rectangle(550, 125, 200, 75);
            Tutorialrect = new Rectangle(530, 220, 220, 75);
            Optionsrect = new Rectangle(540, 315, 210, 75);
            Controlsrect = new Rectangle(540, 390, 210, 75);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            menuMusic = Content.Load<Song>("menuMusic");
            gameAmb = Content.Load<Song>("gameAmb");
            hit = Content.Load<SoundEffect>("hit");

            beetledown = Content.Load<Texture2D>("beetledown");
            beetleup = Content.Load<Texture2D>("beetleup");
            beetleleft = Content.Load<Texture2D>("beetleleft");
            beetleright = Content.Load<Texture2D>("beetleright");
            beetleidle = Content.Load<Texture2D>("beetleright");
            beetle = beetleidle;

            mbeetle = Content.Load<Texture2D>("mbeetledown1");
            mbeetledown1 = Content.Load<Texture2D>("mbeetledown1");

            tpRock = Content.Load<Texture2D>("tpRock");
            shale = Content.Load<Texture2D>("Shale");
            dirt = Content.Load<Texture2D>("dirt");

            Play = Content.Load<Texture2D>("play");
            Tutorial = Content.Load<Texture2D>("tutorial");
            Options = Content.Load<Texture2D>("options");
            Controls = Content.Load<Texture2D>("controls");

            cavernback = Content.Load<Texture2D>("cavern");
            tutmap = Content.Load<Texture2D>("tutmap");
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
            }
            if (screen == Screen.L1)
            {
                MediaState state = MediaPlayer.State;
                if (state == MediaState.Stopped || state == MediaState.Paused)
                {
                    MediaPlayer.Play(gameAmb);
                }

                dirtrect = new Rectangle(0, 0, 0, 0);


                mbeetrect.Width = 50;
                mbeetrect.Height = 52;

                mbeetrect2.Width = 50;
                mbeetrect2.Height = 52;

                mbeetle = mbeetledown1;

                mbeetspeed.Y = 4;
                if (mbeetrect.Y > 550)
                {
                    mbeetrect.Y = -50;
                }
                mbeetspeed2.Y = 4;
                if (mbeetrect2.Y > 550)
                {
                    mbeetrect2.Y = -50;
                }

                shalerects.Add(new Rectangle(-50, 0, 50, 500));
                shalerects.Add(new Rectangle(800, 0, 50, 500));
                shalerects.Add(new Rectangle(0, -50, 800, 50));
                shalerects.Add(new Rectangle(0, 500, 800, 50));

                shalerects.Add(new Rectangle(300, 70, 50, 430));
                shalerects.Add(new Rectangle(600, 0, 50, 430));
            }
            if (screen == Screen.Death)
            {
                MediaPlayer.Stop();
                
            }

            if (beetrect.Intersects(dirtrect))
            {
                screen = Screen.Menu;
            }
            if (beetrect.Intersects(mbeetrect))
            {
                hit.Play();
                screen = Screen.Death;
            }
            if (beetrect.Intersects(mbeetrect2))
            {
                hit.Play();
                screen = Screen.Death;
            }
            if (beetrect.Intersects(tpRockr))
            {
                screen = Screen.Menu;
            }

            //C
            // Store the original position
            var originalPosition = beetrect.Location;

            // Move on X axis
            beetrect.X += (int)beetspeed.X;
            bool collidedX = false;
            foreach (Rectangle shalerect in shalerects)
            {
                if (beetrect.Intersects(shalerect))
                {
                    // Undo X movement if collision
                    beetrect.X = originalPosition.X;
                    collidedX = true;
                    break;
                }
            }

            // Move on Y axis
            beetrect.Y += (int)beetspeed.Y;
            foreach (Rectangle shalerect in shalerects)
            {
                if (beetrect.Intersects(shalerect))
                {
                    // Undo Y movement if collision
                    beetrect.Y = originalPosition.Y;
                    break;
                }
            }


            if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released)
            {
                if (Tutorialrect.Contains(mouseState.Position))
                {
                    screen = Screen.Start;
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released)
                    {
                        if (Optionsrect.Contains(mouseState.Position))
                        {
                            screen = Screen.L1;
                        }
                    }
                }
            }
            if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released)
            {
                if (Playrect.Contains(mouseState.Position))
                {
                    screen = Screen.L1;
                    if (mouseState.LeftButton == ButtonState.Pressed &&
                    prevMouseState.LeftButton == ButtonState.Released)
                    {
                        if (Optionsrect.Contains(mouseState.Position))
                        {
                            screen = Screen.L2;
                        }
                    }
                }
            }

            mbeetrect.X += (int)mbeetspeed.X;
            mbeetrect.Y += (int)mbeetspeed.Y;

            mbeetrect2.X += (int)mbeetspeed2.X;
            mbeetrect2.Y += (int)mbeetspeed2.Y;

            if (Playrect.Contains(mouseState.Position))
            {
                Playrect = new Rectangle(540, 115, 220, 95);
            }
            else
            {
                Playrect = new Rectangle(550, 125, 200, 75);
            }
            //Tutorial Button
            if (Tutorialrect.Contains(mouseState.Position))
            {
                Tutorialrect = new Rectangle(520, 210, 240, 95);
            }
            else
            {
                Tutorialrect = new Rectangle(530, 220, 220, 75);
            }
            //Options Button
            if (Optionsrect.Contains(mouseState.Position))
            {
                Optionsrect = new Rectangle(530, 305, 230, 95);
            }
            else
            {
                Optionsrect = new Rectangle(540, 315, 210, 75);
            }
            //Controls Button
            if (Controlsrect.Contains(mouseState.Position))
            {
                Controlsrect = new Rectangle(530, 380, 230, 95);
            }
            else
            {
                Controlsrect = new Rectangle(540, 390, 210, 75);
            }
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
                _spriteBatch.Draw(Play, Playrect, Color.White);
                _spriteBatch.Draw(Tutorial, Tutorialrect, Color.White);
                _spriteBatch.Draw(Options, Optionsrect, Color.White);
                _spriteBatch.Draw(Controls, Controlsrect, Color.White);
            }
            else if (screen == Screen.Death)
            {
                _spriteBatch.Draw(Play, Playrect, Color.White);
            }
            else if (screen == Screen.Start)
            {
                _spriteBatch.Draw(tutmap, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.Draw(dirt, dirtrect, Color.White);

                _spriteBatch.Draw(beetle, beetrect, Color.White);
            }
            else if (screen == Screen.L1)
            {
                _spriteBatch.Draw(cavernback, new Rectangle(0, 0, 800, 500), Color.White);

                foreach (Rectangle shalerect in shalerects)
                    _spriteBatch.Draw(shale, shalerect, Color.White);
                _spriteBatch.Draw(tpRock, tpRockr, Color.White);
                _spriteBatch.Draw(beetle, beetrect, Color.White);
                _spriteBatch.Draw(mbeetledown1, mbeetrect, Color.White);
                _spriteBatch.Draw(mbeetledown1, mbeetrect2, Color.White);
            }
            else if (screen == Screen.L2)
            {
                
            }


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
