
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint_0
{
	public class TextSprite : ISprite
	{

		private SpriteFont font;
		private string text;
		private Color color;
		private Vector2 position;

		public TextSprite(SpriteFont font, string text, Vector2 position, Color color)
		{
			this.font = font;
			this.text = text;
			this.position = position;
			this.color = color;
		}

		public void Update(GameTime gameTime)
		{

		}

		public void Draw(SpriteBatch spriteBatch, Vector2 positionOverride)
		{
			spriteBatch.DrawString(font, text, position, color);
		}
	}
}