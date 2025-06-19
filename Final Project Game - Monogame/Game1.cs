using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Final_Project_Game___Monogame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Rectangle window;

        Texture2D grass;

        Texture2D tracks1;
        Rectangle tracks1Rect;

        Texture2D tracks2;
        Rectangle tracks2Rect;

        Texture2D tracks3;
        Rectangle tracks3Rect;

        Rectangle tracks4Rect;
        Rectangle tracks5Rect;
        Rectangle tracks6Rect;


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

            tracks1Rect = new Rectangle(50, 0, 100, 600);
            tracks2Rect = new Rectangle(150, 0, 100, 600);
            tracks3Rect = new Rectangle(250, 0, 100, 600);
            tracks4Rect = new Rectangle(50, 0, 100, -600);
            tracks5Rect = new Rectangle(150, 0, 100, -600);
            tracks6Rect = new Rectangle(250, 0, 100, -600);
           

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
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);

            _spriteBatch.Begin();

            _spriteBatch.Draw(grass, window, Color.White);
            _spriteBatch.Draw(tracks1, tracks1Rect, Color.White);
            _spriteBatch.Draw(tracks2, tracks2Rect, Color.White);
            _spriteBatch.Draw(tracks3, tracks3Rect, Color.White);
            _spriteBatch.Draw(tracks1, tracks4Rect, Color.White);
            _spriteBatch.Draw(tracks2, tracks5Rect, Color.White);
            _spriteBatch.Draw(tracks3, tracks6Rect, Color.White);
            

            _spriteBatch.End();
        }
    }
}
