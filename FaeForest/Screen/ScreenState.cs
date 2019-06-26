using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FaeForest.States
{
    interface ScreenState
    {
        void LoadContent(SpriteBatch spriteBatch, ContentManager Content);

        void render(SpriteBatch spriteBatch, GameTime gameTime);
        void update(GameTime gameTime);
    }
}
