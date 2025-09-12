
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public class MovingStaticSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle frame;
        private Vector2 position;
        private Vector2 velocity;

        public MovingStaticSprite(Texture2D texture, Rectangle frame, Vector2 startPosition, Vector2 velocity)
        {
            this.texture = texture;
            this.frame = frame;
            this.position = startPosition;
            this.velocity = velocity;
        }

        public void Update(GameTime gameTime)
        {
            position += velocity;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 positionOverride)
        {
            spriteBatch.Draw(texture, position, frame, Color.White);
        }
    }
}