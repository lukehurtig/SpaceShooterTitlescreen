using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceShooterTitlescreen
{
    public class Bullet
    {
        private Texture2D texture;

        public Vector2 Position;

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Bullet");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.White);
        }
    }
}
