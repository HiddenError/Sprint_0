
using Microsoft.Xna.Framework.Input;

namespace Sprint_0
{
    public class KeyboardController : IController
    {
        private Game1 game;

        public KeyboardController(Game1 game)
        {
            this.game = game;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.D0) || state.IsKeyDown(Keys.NumPad0))
                game.SetSprite(0);
            else if (state.IsKeyDown(Keys.D1) || state.IsKeyDown(Keys.NumPad1))
                game.SetSprite(1);
            else if (state.IsKeyDown(Keys.D2) || state.IsKeyDown(Keys.NumPad2))
                game.SetSprite(2);
            else if (state.IsKeyDown(Keys.D3) || state.IsKeyDown(Keys.NumPad3))
                game.SetSprite(3);
            else if (state.IsKeyDown(Keys.D4) || state.IsKeyDown(Keys.NumPad4))
                game.SetSprite(4);
        }
    }
}