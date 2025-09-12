
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using static System.Net.Mime.MediaTypeNames;

namespace Sprint_0
{
    public class Game1 : Game
    {

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont font;

        private ISprite currentSprite;
        private IController keyboardController;
        private IController mouseController;

        private Vector2 spritePosition;
        private Vector2 fontPos;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spritePosition = new Vector2(400, 240); // default starting position
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Default state: Still + Static sprite
            Texture2D marioTexture = Content.Load<Texture2D>("mario");
            Rectangle standingFrame = new Rectangle(210, 0, 14, 16);
            currentSprite = new StillStaticSprite(marioTexture, standingFrame);

            Viewport viewport = _graphics.GraphicsDevice.Viewport;

            // Create controllers
            keyboardController = new KeyboardController(this);
            mouseController = new MouseController(this);

            font = Content.Load<SpriteFont>("gameFont");
            fontPos = new Vector2(viewport.Width / 2, (viewport.Height / 2) + 100);
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardController.Update();
            mouseController.Update();

            if (currentSprite != null)
                currentSprite.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (currentSprite != null)
                currentSprite.Draw(_spriteBatch, spritePosition);

            string output = "Credits\nProgram Made By: Noah Ruppert\nSprites from: \nhttps://osu.instructure.com/courses/190351/files/folder/Mario%20spritesheets%20in%20different%20formats ";
            Vector2 FontOrigin = font.MeasureString(output) / 2;
            _spriteBatch.DrawString(font, output, fontPos, Color.Black, 0, FontOrigin, 1.0f, SpriteEffects.None, 0.5f);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetSprite(int id)
        {
            Texture2D marioTexture = Content.Load<Texture2D>("mario");

            Viewport viewport = _graphics.GraphicsDevice.Viewport;

            // Define frames for animation (adjust dimensions to match your sprite sheet)
            Rectangle[] runFrames = new Rectangle[]
            {
                new Rectangle(240, 0, 15, 16),
                new Rectangle(271, 0, 13, 16),
                new Rectangle(299, 0, 17, 16),
            };

            Rectangle standingFrame = new Rectangle(210, 0, 14, 16);
            Rectangle fallingFrame = new Rectangle(0, 15, 15, 15);

            switch (id)
            {
                case 1:
                    // Motionless + Non-Animated
                    currentSprite = new StillStaticSprite(marioTexture, standingFrame);
                    break;

                case 2:
                    // Motionless + Animated
                    currentSprite = new StillAnimatedSprite(marioTexture, runFrames);
                    break;

                case 3:
                    // Moving + Non-Animated (up/down)
                    currentSprite = new MovingStaticSprite(
                        marioTexture,
                        fallingFrame,
                        new Vector2(viewport.Width / 2, (viewport.Height / 2)),
                        new Vector2(0, 2)
                    );
                    break;

                case 4:
                    // Moving + Animated (left/right)
                    currentSprite = new MovingAnimatedSprite(
                        marioTexture,
                        runFrames,
                        new Vector2(viewport.Width / 2, (viewport.Height / 2)),
                        new Vector2(2, 0)
                    );
                    break;

                case 0:
                    Exit(); // Quit
                    break;
            }
        }
    }
}