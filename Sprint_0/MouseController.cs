
using Microsoft.Xna.Framework.Input;

namespace Sprint_0
{
    public class MouseController : IController
    {
        private Game1 game;

        public MouseController(Game1 game)
        {
            this.game = game;
        }

        public void Update()
        {
            var state = Mouse.GetState();

            if (state.RightButton == ButtonState.Pressed)
            {
                game.SetSprite(0);
            }
            else if (state.LeftButton == ButtonState.Pressed)
            {
                int width = game.Window.ClientBounds.Width;
                int height = game.Window.ClientBounds.Height;

                if (state.X < width / 2 && state.Y < height / 2)
                    game.SetSprite(1);
                else if (state.X >= width / 2 && state.Y < height / 2)
                    game.SetSprite(2);
                else if (state.X < width / 2 && state.Y >= height / 2)
                    game.SetSprite(3);
                else
                    game.SetSprite(4);
            }
        }
    }
}