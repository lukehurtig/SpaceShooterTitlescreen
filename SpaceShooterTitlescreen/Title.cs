using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceShooterTitlescreen
{
    public class Title : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Spaceship spaceship;
        private Bullet[] bullets;
        private Texture2D bg;
        private Texture2D stars;
        private Texture2D planet;
        private SpriteFont titleFont;
        private SpriteFont select;

        private Vector2 shipVelocity = new Vector2(-10, 0);
        private Vector2 shipOrigin = new Vector2(200, 250);
        private double firingTimer;

        public Title()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            bullets = new Bullet[]
            {
                new Bullet(),
                new Bullet(),
                new Bullet(),
                new Bullet()
            };
            spaceship = new Spaceship();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            spaceship.LoadContent(Content);
            foreach (var bullet in bullets) bullet.LoadContent(Content);
            bg = Content.Load<Texture2D>("parallax-space-backgound");
            stars = Content.Load<Texture2D>("parallax-space-stars");
            planet = Content.Load<Texture2D>("parallax-space-big-planet");
            titleFont = Content.Load<SpriteFont>("Title");
            select = Content.Load<SpriteFont>("ButtonPrompt");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            spaceship.Position += (float)gameTime.ElapsedGameTime.TotalSeconds * shipVelocity;

            if (spaceship.Position.X > (shipOrigin.X + 15) || spaceship.Position.X < (shipOrigin.X - 15))
            {
                shipVelocity.X *= -1;
            }

            // TODO: Add your update logic here
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                spaceship.Spin = true;
            }
            else spaceship.Spin = false;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(bg, new Rectangle(0, 0, 800, 490), Color.White);
            spriteBatch.Draw(stars, new Rectangle(0, 0, 800, 490), Color.White);
            spriteBatch.Draw(planet, new Rectangle(450, 190, 200, 200), Color.White);
            foreach (var bullet in bullets) bullet.Draw(gameTime, spriteBatch);
            spaceship.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(titleFont, "Do A Barrel Roll!", new Vector2(135, 25), Color.BurlyWood);
            spriteBatch.DrawString(select, "Press Space or A to do a Barrel Roll!\nPress Esc or Back Button to Exit", new Vector2(250, 120), Color.BurlyWood);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
