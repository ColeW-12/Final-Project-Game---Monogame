using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Project_Game___Monogame
{
    enum Screen
    {
        Intro,
        Main
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

        MouseState mouseState;
        MouseState prevMouseState;

        Vector2 trackSpeed;

        SpriteFont titleFont;

        Screen screen;
        Texture2D introScreen;

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
            trainRect = new Rectangle(160, 490, 100, 100);

            trackSpeed = new Vector2(0, 3);

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
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            prevMouseState = mouseState;
            
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
                    tracks3Rect.Y += (int)trackSpeed.Y;
                tracks6Rect.Y += (int)trackSpeed.Y;
                if (tracks6Rect.Top >= window.Height)
                    tracks6Rect.Y = -600;
                
                grass1Rect.Y += (int)trackSpeed.Y;
                if (grass1Rect.Top >= window.Height)
                    grass1Rect.Y = -600;
                grass2Rect.Y += (int)trackSpeed.Y;
                if (grass2Rect.Top >= window.Height)
                    grass2Rect.Y = -600;


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

                _spriteBatch.Draw(trainTexture, trainRect, Color.White);
            }

            _spriteBatch.End();
        }
    }
}
