using System.Reflection.Emit;
using System;
using System.Security.Cryptography;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Project_Game___Monogame
{
    enum Screen
    {
        Intro,
        Main,
        End
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D grass;
        Rectangle grass1Rect;
        Rectangle grass2Rect;

        Texture2D tracks1;
        Rectangle tracks1Rect;

        Texture2D tracks2;
        Rectangle tracks2Rect;

        Texture2D tracks3;
        Rectangle tracks3Rect;

        Rectangle tracks4Rect;
        Rectangle tracks5Rect;
        Rectangle tracks6Rect;

        Texture2D playTexture;
        Rectangle playRect;

        Rectangle rectangleRect;
        Texture2D rectangleTexture;

        Texture2D trainTexture;
        Rectangle trainRect;

        Texture2D cowTexture;
        Rectangle cowRect;
        Vector2 cowSpeed;

        MouseState mouseState;
        MouseState prevMouseState;

        Texture2D moneyTexture;
        Rectangle moneyRect;
        Vector2 moneySpeed;

        Vector2 trackSpeed;

        SpriteFont titleFont;

        Screen screen;
        Texture2D introScreen;

        Texture2D endScreen;

        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;

        Texture2D endHomeTexture;
        Rectangle endHomeRect;

        Texture2D endPlayTexture;
        Rectangle endPlayRect;

        Texture2D rockTexture;
        Rectangle rockRect;
        Vector2 rockSpeed;

        Texture2D signTexture;
        Rectangle signRect;
        Vector2 signSpeed;

        Random randNum1, randNum2, randNum3;
        int drop1, drop2, drop3;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            window = new Rectangle(0, 0, 400, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here

            screen = Screen.Intro;

            grass1Rect = new Rectangle(0, 0, 400, 600);
            grass2Rect = new Rectangle(0, -600, 400, 600);

            tracks1Rect = new Rectangle(50, 0, 100, 600);
            tracks2Rect = new Rectangle(150, 0, 100, 600);
            tracks3Rect = new Rectangle(250, 0, 100, 600);
            tracks4Rect = new Rectangle(50, -600, 100, 600);
            tracks5Rect = new Rectangle(150, -600, 100, 600);
            tracks6Rect = new Rectangle(250, -600, 100, 600);
            playRect = new Rectangle(75, 300, 250, 100);
            rectangleRect = new Rectangle(89, 302, 221, 97);
            trainRect = new Rectangle(155, 500, 90, 200);
            cowRect = new Rectangle(60, -200, 75, 75);
            moneyRect = new Rectangle(60, -200, 75, 75);
            endPlayRect = new Rectangle(225, 400, 150, 100);
            endHomeRect = new Rectangle(50, 400, 150, 100);
            rockRect = new Rectangle(155, -400, 75, 75);
            signRect = new Rectangle(255, -600, 75, 75);

            trackSpeed = new Vector2(0, 3);
            cowSpeed = new Vector2(0, 3);
            rockSpeed = new Vector2(0, 3);
            signSpeed = new Vector2(0, 3);

            randNum1 = new Random();
            
            randNum2 = new Random();

            randNum3 = new Random();
            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            grass = Content.Load<Texture2D>("grass Texture");

            tracks1 = Content.Load<Texture2D>("Traintracks2");
            tracks2 = Content.Load<Texture2D>("Traintracks2");
            tracks3 = Content.Load<Texture2D>("Traintracks2");
            introScreen = Content.Load<Texture2D>("Blue Backround");
            playTexture = Content.Load<Texture2D>("play-now");
            rectangleTexture = Content.Load<Texture2D>("rectangle");
            titleFont = Content.Load<SpriteFont>("File");
            trainTexture = Content.Load<Texture2D>("train");
            cowTexture = Content.Load<Texture2D>("cow");
            moneyTexture = Content.Load<Texture2D>("money bag");
            endScreen = Content.Load<Texture2D>("you lose");
            endHomeTexture = Content.Load<Texture2D>("buttonHome");
            endPlayTexture = Content.Load<Texture2D>("play-now");
            rockTexture = Content.Load<Texture2D>("stone");
            signTexture = Content.Load<Texture2D>("con sign");
        }

        protected override void Update(GameTime gameTime)
        { 
            prevMouseState = mouseState;
            mouseState = Mouse.GetState();

            prevKeyboardState = keyboardState;
            keyboardState = Keyboard.GetState();


            this.Window.Title = mouseState.Position.ToString();

            

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

        
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (rectangleRect.Contains(mouseState.Position))
                        screen = Screen.Main;
                }
            }
            else if (screen == Screen.Main)
            {
                tracks1Rect.Y += (int)trackSpeed.Y;
                if (tracks1Rect.Top >= window.Height)
                    tracks1Rect.Y = -600;
                tracks4Rect.Y += (int)trackSpeed.Y;
                if (tracks4Rect.Top >= window.Height)
                    tracks4Rect.Y = -600;
                tracks2Rect.Y += (int)trackSpeed.Y;
                if (tracks2Rect.Top >= window.Height)
                    tracks2Rect.Y = -600;
                tracks5Rect.Y += (int)trackSpeed.Y;
                if (tracks5Rect.Top >= window.Height)
                    tracks5Rect.Y = -600;
                tracks3Rect.Y += (int)trackSpeed.Y;
                if (tracks3Rect.Top >= window.Height)
                    tracks3Rect.Y = -600;
                tracks6Rect.Y += (int)trackSpeed.Y;
                if (tracks6Rect.Top >= window.Height)
                    tracks6Rect.Y = -600;

                grass1Rect.Y += (int)trackSpeed.Y;
                if (grass1Rect.Top >= window.Height)
                    grass1Rect.Y = -600;
                grass2Rect.Y += (int)trackSpeed.Y;
                if (grass2Rect.Top >= window.Height)
                    grass2Rect.Y = -600;

                if ((keyboardState.IsKeyDown(Keys.Left)) && prevKeyboardState.IsKeyUp(Keys.Left))
                {
                    if (trainRect.X == 255)
                        trainRect.X = 155;
                    else if (trainRect.X == 155)
                        trainRect.X = 60;

                }
                if ((keyboardState.IsKeyDown(Keys.Right)) && prevKeyboardState.IsKeyUp(Keys.Right))
                {
                    if (trainRect.X == 60)
                        trainRect.X = 155;
                    else if (trainRect.X == 155)
                        trainRect.X = 255;

                }
                cowRect.Y += (int)cowSpeed.Y;
                if (cowRect.Top >= window.Height)
                {
                    drop1 = randNum1.Next(1, 4);
                    if (drop1 == 1)
                        cowRect.Y = -100;
                    if (drop1 == 2)
                    {
                        cowRect.Y = -100;
                        cowRect.X = 155;
                    }
                    if (drop1 == 3)
                    {
                        cowRect.Y = -100;
                        cowRect.X = 255;
                    }
                }
                if (trainRect.Intersects(cowRect))
                    screen = Screen.End;

                rockRect.Y += (int)rockSpeed.Y;
                if (rockRect.Top >= window.Height)
                {
                    drop3 = randNum3.Next(0, 4);
                    if (drop2 == 1)
                        rockRect.Y = -200;
                    if (drop2 == 2)
                    {
                        rockRect.Y = -200;
                        rockRect.X = 155;
                    }
                    if (drop2 == 3)
                    {
                        rockRect.Y = -200;
                        rockRect.X = 255;
                    }
                    
                }
                if (trainRect.Intersects(rockRect))
                    screen = Screen.End;

                signRect.Y += (int)signSpeed.Y;
                if (signRect.Top >= window.Height)
                {
                    drop3 = randNum3.Next(0, 4);
                    if (drop3 == 1)
                        signRect.Y = -200;
                    if (drop3 == 2)
                    {
                        signRect.Y = -200;
                        signRect.X = 155;
                    }
                    if (drop3 == 3)
                    {
                        signRect.Y = -200;
                        signRect.X = 255;
                    }
                }
                if (trainRect.Intersects(signRect))
                    screen = Screen.End;
            }
            if (screen == Screen.End)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    if (endHomeRect.Contains(mouseState.Position))
                    {
                        grass1Rect = new Rectangle(0, 0, 400, 600);
                        grass2Rect = new Rectangle(0, -600, 400, 600);

                        tracks1Rect = new Rectangle(50, 0, 100, 600);
                        tracks2Rect = new Rectangle(150, 0, 100, 600);
                        tracks3Rect = new Rectangle(250, 0, 100, 600);
                        tracks4Rect = new Rectangle(50, -600, 100, 600);
                        tracks5Rect = new Rectangle(150, -600, 100, 600);
                        tracks6Rect = new Rectangle(250, -600, 100, 600);
                        playRect = new Rectangle(75, 300, 250, 100);
                        rectangleRect = new Rectangle(89, 302, 221, 97);
                        trainRect = new Rectangle(155, 500, 90, 200);
                        cowRect = new Rectangle(60, -200, 75, 75);
                        moneyRect = new Rectangle(60, -200, 75, 75);
                        endPlayRect = new Rectangle(225, 400, 150, 100);
                        endHomeRect = new Rectangle(50, 400, 150, 100);
                        rockRect = new Rectangle(155, -400, 75, 75);
                        signRect = new Rectangle(255, -600, 75, 75);

                        trackSpeed = new Vector2(0, 3);
                        cowSpeed = new Vector2(0, 3);
                        rockSpeed = new Vector2(0, 3);
                        signSpeed = new Vector2(0, 3);
                        screen = Screen.Intro;

                    }
                    
                    if (endPlayRect.Contains(mouseState.Position))
                    {
                        grass1Rect = new Rectangle(0, 0, 400, 600);
                        grass2Rect = new Rectangle(0, -600, 400, 600);

                        tracks1Rect = new Rectangle(50, 0, 100, 600);
                        tracks2Rect = new Rectangle(150, 0, 100, 600);
                        tracks3Rect = new Rectangle(250, 0, 100, 600);
                        tracks4Rect = new Rectangle(50, -600, 100, 600);
                        tracks5Rect = new Rectangle(150, -600, 100, 600);
                        tracks6Rect = new Rectangle(250, -600, 100, 600);
                        playRect = new Rectangle(75, 300, 250, 100);
                        rectangleRect = new Rectangle(89, 302, 221, 97);
                        trainRect = new Rectangle(155, 500, 90, 200);
                        cowRect = new Rectangle(60, -200, 75, 75);
                        moneyRect = new Rectangle(60, -200, 75, 75);
                        endPlayRect = new Rectangle(225, 400, 150, 100);
                        endHomeRect = new Rectangle(50, 400, 150, 100);
                        rockRect = new Rectangle(155, -400, 75, 75);
                        signRect = new Rectangle(255, -600, 75, 75);

                        trackSpeed = new Vector2(0, 3);
                        cowSpeed = new Vector2(0, 3);
                        rockSpeed = new Vector2(0, 3);
                        signSpeed = new Vector2(0, 3);
                        screen = Screen.Main;

                    }
                    
                }
            }

                base.Update(gameTime);

            }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin();


            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introScreen, window, Color.White);
                _spriteBatch.Draw(rectangleTexture, rectangleRect, Color.White);
                _spriteBatch.Draw(playTexture, playRect, Color.White);
                _spriteBatch.DrawString(titleFont, "Rail Runners", new Vector2(90, 100), Color.Black);
            }
            else if (screen == Screen.Main)
            {
                _spriteBatch.Draw(grass, grass1Rect, Color.White);
                _spriteBatch.Draw(grass, grass2Rect, Color.White);
                _spriteBatch.Draw(tracks1, tracks1Rect, Color.White);
                _spriteBatch.Draw(tracks2, tracks2Rect, Color.White);
                _spriteBatch.Draw(tracks3, tracks3Rect, Color.White);
                _spriteBatch.Draw(tracks1, tracks4Rect, Color.White);
                _spriteBatch.Draw(tracks2, tracks5Rect, Color.White);
                _spriteBatch.Draw(tracks3, tracks6Rect, Color.White);
                _spriteBatch.Draw(cowTexture, cowRect, Color.White);
                _spriteBatch.Draw(moneyTexture, moneyRect, Color.White);
                _spriteBatch.Draw(rockTexture, rockRect, Color.White);
                _spriteBatch.Draw(signTexture, signRect, Color.White);

                _spriteBatch.Draw(trainTexture, trainRect, Color.White);
            }
            else if (screen == Screen.End)
            {
                _spriteBatch.Draw(endScreen, window, Color.White);
                _spriteBatch.Draw(endPlayTexture, endPlayRect, Color.White);
                _spriteBatch.Draw(endHomeTexture, endHomeRect, Color.White);
            }

            _spriteBatch.End();
        }
    }
}
