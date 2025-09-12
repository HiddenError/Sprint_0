
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public class StillStaticSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle frame;

        public StillStaticSprite(Texture2D texture, Rectangle frame)
        {
            this.texture = texture;
            this.frame = frame;
        }

        public void Update(GameTime gameTime)
        {
            // Nothing to update
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position, frame, Color.White);
        }
    }
}