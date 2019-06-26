using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FaeForest.Entity
{
    interface IEntity
    {
        void render(SpriteBatch spriteBatch, GameTime gameTime);
        void update(GameTime gameTime);
    }
}
