using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceShooterTitlescreen
{
    public class Spaceship
    {
        private const float ANIMATION_SPEED = 0.1f;

        private double animationTimer;

        private int animationFrame = 0;        

        private Texture2D texture;

        public Vector2 Position = new Vector2(200,250);

        public bool Spin = false;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("SpinningFighterSpaceship");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Spin)
            {
                animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (animationTimer > 0.25)
                {
                    animationFrame++;
                    if (animationFrame > 3) animationFrame = 0;
                    animationTimer -= 0.25;
                }
            }
            else animationFrame = 0;

            var source = new Rectangle(animationFrame * 32, 0, 32, 32);
            spriteBatch.Draw(texture, Position, source, Color.White, 0f, new Vector2(0, 0), 3.0f, SpriteEffects.None, 0);
        }
    }
}
