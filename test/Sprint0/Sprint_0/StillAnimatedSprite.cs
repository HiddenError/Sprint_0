
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static System.Formats.Asn1.AsnWriter;

namespace Sprint_0
{
    public class StillAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle[] frames;
        private int currentFrame;
        private double timePerFrame;
        private double timer;

        public StillAnimatedSprite(Texture2D texture, Rectangle[] frames, double framesPerSecond = 5)
        {
            this.texture = texture;
            this.frames = frames;
            this.currentFrame = 0;
            this.timePerFrame = 1.0 / framesPerSecond;
        }

        public void Update(GameTime gameTime)
        {
            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer > timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                timer -= timePerFrame;
            }

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            spriteBatch.Draw(texture, position, frames[currentFrame], Color.White);
        }
    }
}