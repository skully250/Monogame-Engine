using FaeForest;
using FaeForest.Graphics;
using FaeForest.States;
using FaeForest.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FaeGame
{
    class GameState : ScreenState
    {
        private InputHandler m_input;
        SpriteSheet[] spriteSheets = new SpriteSheet[20];
        World world;
        Animation anim1, anim2;
        int animFrame = 0;
        float timer;

        public GameState(InputHandler input)
        {
            m_input = input;
        }

        public void LoadContent(SpriteBatch spriteBatch, ContentManager Content)
        {
            spriteSheets[0] = new SpriteSheet(new Vector2(12, 8), new Vector2(32, 32), "actor110", Content);
            spriteSheets[1] = new SpriteSheet(new Vector2(11, 3), new Vector2(32, 32), "TileSet", Content);
            spriteSheets[2] = new SpriteSheet(new Vector2(12, 5), new Vector2(377, 377), "107826", Content);
            world = new World(spriteSheets[1].spriteGrid, new Vector2(100, 100), spriteBatch);
            anim1 = new Animation(spriteSheets[0], 32, 0, 0, 3);
            anim2 = new Animation(spriteSheets[2], 377, 0, 0, 11);
        }

        public void render(SpriteBatch spriteBatch, GameTime gameTime)
        {
            world.Draw();
            anim1.Draw(spriteBatch, new Vector2(3, 3), animFrame);
            anim2.ScaledDraw(spriteBatch, new Vector2(10, 10), MathUtility.PixelPercentage(377, 64), animFrame);
            //anim2.Draw(spriteBatch, new Vector2(10, 10), animFrame);
        }

        public void update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (timer > 1f)
            {
                if (animFrame >= 2)
                    animFrame = 0;
                else
                    animFrame++;
                timer = 0;
            }
            Camera.Update(m_input, null, false);
            world.update();
        }
    }
}
