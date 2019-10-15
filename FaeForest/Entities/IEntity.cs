using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FaeForest.Entities
{
    interface IEntity
    {
        void render(SpriteBatch spriteBatch, GameTime gameTime);
        void update(GameTime gameTime);
    }
}
