
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
    public class MovingAnimatedSprite : ISprite
    {
        private Texture2D texture;
        private Rectangle[] frames;
        private int currentFrame;
        private double timePerFrame;
        private double timer;
        private Vector2 position;
        private Vector2 velocity;

        public MovingAnimatedSprite(Texture2D texture, Rectangle[] frames, Vector2 startPosition, Vector2 velocity, double framesPerSecond = 5)
        {
            this.texture = texture;
            this.frames = frames;
            this.currentFrame = 0;
            this.timePerFrame = 1.0 / framesPerSecond;
            this.position = startPosition;
            this.velocity = velocity;
        }

        public void Update(GameTime gameTime)
        {

            position += velocity;

            timer += gameTime.ElapsedGameTime.TotalSeconds;
            if (timer >= timePerFrame)
            {
                currentFrame = (currentFrame + 1) % frames.Length;
                timer -= timePerFrame;
            }
            if (this.position == new Vector2(800, 240))
            {
                this.position = new Vector2(0, 240);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 positionOverride)
        {
            spriteBatch.Draw(texture, position, frames[currentFrame], Color.White);
        }
    }
}